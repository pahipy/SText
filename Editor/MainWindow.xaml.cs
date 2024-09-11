using SText.Conf;
using SText.Dialogs;
using SText.Formats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using MenuItem = System.Windows.Controls.MenuItem;


namespace SText.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : FluentWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplicationThemeManager.Apply(this);

            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();

            openFileDialog.CheckFileExists = false;
            openFileDialog.Filter = "Text Documents|*.txt|SText Documents|*.txts|All Files|*.*";
            openFileDialog.RestoreDirectory = true;
            saveFileDialog.Filter = "Text Documents|*.txt|SText Documents|*.txts|All Files|*.*";
            saveFileDialog.RestoreDirectory = true;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            SetEncodingMenuItems();

            try
            {
                if (Environment.GetCommandLineArgs().Length > 1)
                {
                    string filename = "";
                    string[] cmd = Environment.GetCommandLineArgs();

                    for (int i = 1; i < cmd.Length; i++)
                        filename += $"{cmd[i]} ";

                    if (File.Exists(filename))
                    {
                        OpenFileAndReadContent(filename);
                    }

                }
            }
            catch { }

            FileEncoding = Encoding.UTF8;
            ThemeSelector.CurrentTheme = Theme.Light;

            LoadSettingsToStruct();

            SettingsManager = new GlobalSettingsManager(ProgramSets.ConfigFileName, Settings);

            ApplySettings();

            ContentViewer.TextChanged += (s, e) => { TitleText.Title = Title; };

        }

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;

        private FontDialog fd = new FontDialog();
        private SettingsTemplate Settings;
        private GlobalSettingsManager SettingsManager;
        private bool FontSizeChangeByMouseWheelAct = false;
        private bool isDebug = true;
        private TXTSFormat txtsFile;
        private TXTFormat txtFile;
        private PasswordDialog setPasswordDialog = new PasswordDialog();
        private PasswordDialog openPasswordDialog = new PasswordDialog(false);
        private bool appWindowIsShown = false;
        private bool isReadOnly = false;
        private ElementHost host = new ElementHost();
        private string oldContent = "";

        private Encoding fileEncoding;
        private Encoding FileEncoding
        {
            get => fileEncoding;
            set
            {
                fileEncoding = value;
                DropDownEncodingMenu.Text = fileEncoding.EncodingName;
            }
        }

        private int contentHash = -1;

        private string fileName = ProgramSets.UntitledFileName;
        private string FileName
        {
            get => fileName;
            set
            {
                if (value != null)
                {
                    fileName = value;
                }
                else
                {
                    fileName = ProgramSets.UntitledFileName;
                }
                TitleText.Title = Title;
                StatusBar_File.Content = $"File: {FileName}";
            }
        }

        private string Title
        {
            get
            {
                string title = "";
                string readonlystring = isReadOnly ? "[READ ONLY]" : "";

                if (FileName != null && File.Exists(FileName))
                    title = $"{new FileInfo(FileName).Name} - {ProgramSets.ProgramName} {readonlystring}";
                else
                    title = $"{FileName} - {ProgramSets.ProgramName}";

                if (Content.GetHashCode() != contentHash)
                    title = $"*{title}";

                return title;
            }
        }

        private string Content
        {
            get => ContentViewer.Text;
            set => ContentViewer.Text = value;
        }

        private bool WordWrap
        {
            get => ContentViewer.TextWrapping == TextWrapping.Wrap;
            set
            {
                ContentViewer.TextWrapping = value ? TextWrapping.Wrap : TextWrapping.NoWrap;
                WordWrap_MenuItem.IsChecked = value;
            }
        }


        private void LoadSettingsToStruct()
        {
            Settings.CurrentTheme = ThemeSelector.CurrentTheme;
            Settings.ShowStatusBar = true;
            Settings.WordWrap = WordWrap;
            Settings.OnTop = Topmost;
            Settings.FontSize = (float)ContentViewer.FontSize;
            Settings.FontFamily = ContentViewer.FontFamily.Source;
            Settings.FontStyle = ContentViewer.FontStyle == FontStyles.Normal ? 0 : 1;

            if (WindowState != WindowState.Minimized)
                Settings.WindowState = (int)this.WindowState;

            if (WindowState != WindowState.Maximized && WindowState != WindowState.Minimized)
            {
                Settings.WindowPosition = new System.Drawing.Point((int)Left, (int)Top);
                Settings.WindowSize = new System.Drawing.Size((int)Width, (int)Height);
            }

        }

        private void ApplySettings()
        {
            Settings = SettingsManager.Settings;
            ThemeSelector.CurrentTheme = Settings.CurrentTheme;
            WordWrap = Settings.WordWrap;
            Topmost = Settings.OnTop; alwaysOnTop_MenuItem.IsChecked = Settings.OnTop;
            ContentViewer.FontFamily = new System.Windows.Media.FontFamily(Settings.FontFamily);
            ContentViewer.FontSize = Settings.FontSize;
            ContentViewer.FontStyle = Settings.FontStyle == 0 ? FontStyles.Normal : FontStyles.Italic;
            this.WindowState = (WindowState)Settings.WindowState;
            this.Left = Settings.WindowPosition.X;
            this.Top = Settings.WindowPosition.Y;
            this.Width = Settings.WindowSize.Width;
            this.Height = Settings.WindowSize.Height;
            ApplyTheme();
        }

        private void ApplyTheme()
        {

        }

        private void NewFile(bool dontSaveFile = false)
        {
            if (Content.GetHashCode() == contentHash || dontSaveFile)
            {
                ContentViewer.Text = "";
                contentHash = Content.GetHashCode();
                if (txtFile is not null)
                    txtFile.CloseFile();

                if (txtsFile is not null)
                    txtsFile.CloseFile();

                txtFile = null;
                txtsFile = null;
                FileName = null;
            }
            else
            {
                SaveDialog saveDialog = new SaveDialog(FileName, saveFileDialog);

                switch (saveDialog.ShowDialog())
                {
                    case System.Windows.Forms.DialogResult.OK:
                        {
                            if (!File.Exists(FileName))
                                FileName = saveDialog.FileName;

                            SaveFile();

                            NewFile();
                            break;
                        }
                    case System.Windows.Forms.DialogResult.Cancel: return;
                    case System.Windows.Forms.DialogResult.Abort: NewFile(true); return;
                }
            }
        }

        private void OpenFile(bool dontSaveFile = false, string path = null)
        {

            if (Content.GetHashCode() == contentHash || dontSaveFile)
            {
                openFileDialog.FileName = null;

                if (path is not null && File.Exists(path))
                {
                    OpenFileAndReadContent(path);
                }
                else if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    OpenFileAndReadContent(openFileDialog.FileName);
                }
            }
            else
            {
                SaveDialog saveDialog = new SaveDialog(FileName, saveFileDialog);

                switch (saveDialog.ShowDialog())
                {
                    case System.Windows.Forms.DialogResult.OK:
                        {
                            if (!File.Exists(FileName))
                                FileName = saveDialog.FileName;

                            SaveFile();

                            OpenFile(false, path);
                            break;
                        }
                    case System.Windows.Forms.DialogResult.Cancel: return;
                    case System.Windows.Forms.DialogResult.Abort: OpenFile(true, path); return;
                }

            }
        }

        private void OpenFileAndReadContent(string path, bool autodetectEncoding = true)
        {

            try
            {
                if (path is not null && File.Exists(path))
                {
                    string cont = "";

                    if (txtsFile is not null || TXTSFormat.IsTXTSFile(path))
                    {
                        Func<int> openTxts = () =>
                        {

                            if (!appWindowIsShown)
                                openPasswordDialog.StartPosition = FormStartPosition.CenterScreen;
                            else
                                openPasswordDialog.StartPosition = FormStartPosition.CenterParent;

                            int tries = 3;

                            for (int i = 1; i <= tries; i++)
                            {
                                if (openPasswordDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                                {


                                    txtsFile = new TXTSFormat(path, openPasswordDialog.Password);
                                    cont = txtsFile.ReadFile();
                                    isReadOnly = txtsFile.IsReadOnly;
                                    if (autodetectEncoding)
                                        FileEncoding = txtsFile.Encoding;

                                    if (txtsFile.Code == 0)
                                        return txtsFile.Code;

                                    if (txtsFile.Code == 1)
                                    {
                                        DialogManager.ShowWarningDialogWithText("Wrong password!");
                                        txtsFile.CloseFile();
                                        txtsFile = null;

                                        if (i == tries)
                                        {
                                            DialogManager.ShowWarningDialogWithText($"You had {tries} tries maximum.");
                                            return 1;
                                        }
                                    }
                                }
                                else
                                    return 1;
                            }

                            return 0;
                        };

                        if (txtsFile is not null)
                        {
                            if (txtsFile.Path != path)
                            {
                                txtsFile.CloseFile();
                                txtsFile = null;

                                if (!TXTSFormat.IsTXTSFile(path))
                                {
                                    OpenFileAndReadContent(path, autodetectEncoding);
                                    return;
                                }

                                if (openTxts() == 1)
                                    return;
                            }
                            else if (txtsFile.Password is not null)
                            {
                                cont = txtsFile.ReadFile();
                                isReadOnly = txtsFile.IsReadOnly;
                                if (autodetectEncoding)
                                    FileEncoding = txtsFile.Encoding;
                            }
                            else
                                return;
                        }
                        else
                        {
                            if (openTxts() == 1)
                                return;
                        }
                        if (autodetectEncoding)
                            FileEncoding = txtsFile.Encoding;
                    }
                    else
                    {
                        if (txtFile is not null)
                        {
                            txtFile.CloseFile();
                            txtFile = null;
                        }
                        if (autodetectEncoding)
                            FileEncoding = TXTFormat.GetEncoding(path);
                        txtFile = new TXTFormat(path, fileEncoding);
                        cont = txtFile.ReadFile();
                        isReadOnly = txtFile.IsReadOnly;
                    }

                    Content = cont;
                    oldContent = cont;
                    contentHash = Content.GetHashCode();
                    FileName = path;
                }
            }
            catch (Exception ex)
            {
                DialogManager.ShowWarningDialogWithText(ex.Message);
            }

        }

        private void SaveFile()
        {
            if (File.Exists(FileName) && !isReadOnly)
            {
                SaveFileAndUpdateHash(FileName);
            }
            else SaveFileAs();
        }

        private void SaveFileAs()
        {
            try
            {
                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    SaveFileAndUpdateHash(saveFileDialog.FileName);
                }

                saveFileDialog.FileName = null;
            }
            catch { }
        }

        private bool SaveFileAndUpdateHash(string path)
        {

            try
            {
                if (path is not null)
                {
                    if (!File.Exists(path))
                        File.Create(path).Close();

                    if (txtsFile is not null || new FileInfo(path).Extension.ToLower() == ".txts".ToLower())
                    {
                        if (txtsFile is not null)
                        {
                            if (txtsFile.Path != path)
                            {
                                txtsFile.CloseFile();
                                txtsFile = null;
                                return SaveFileAndUpdateHash(path);
                            }

                            try
                            {
                                txtsFile.WriteFile(Content);
                            }
                            catch (Exception ex)
                            {
                                DialogManager.ShowWarningDialogWithText(ex.Message);
                                return false;
                            }

                            isReadOnly = txtsFile.IsReadOnly;
                        }
                        else if (setPasswordDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            txtsFile = new TXTSFormat(path, setPasswordDialog.Password, FileEncoding);
                            try
                            {
                                txtsFile.WriteFile(Content);
                            }
                            catch (Exception ex)
                            {
                                DialogManager.ShowWarningDialogWithText(ex.Message);
                                return false;
                            }

                            isReadOnly = txtsFile.IsReadOnly;
                        }
                        else
                            return false;
                    }
                    else
                    {
                        if (txtFile is null)
                            txtFile = new TXTFormat(path, fileEncoding);

                        if (txtFile is not null && txtFile.Path != path)
                        {
                            txtFile.CloseFile();
                            txtFile = new TXTFormat(path, fileEncoding);
                        }

                        try
                        {
                            txtFile.WriteFile(Content);
                        }
                        catch (Exception ex)
                        {
                            DialogManager.ShowWarningDialogWithText(ex.Message);
                            return false;
                        }

                        isReadOnly = txtFile.IsReadOnly;
                    }

                    contentHash = Content.GetHashCode();
                    oldContent = Content;
                    FileName = path;
                    return true;
                }

                return false;
            }
            catch (ArgumentException ex)
            {
                DialogManager.ShowWarningDialogWithText(ex.Message);
                return false;
            }

        }

        private DialogResult SaveFileIfItChanged()
        {
            if (contentHash != Content.GetHashCode())
            {
                SaveDialog saveDialog = new SaveDialog(FileName, saveFileDialog);
                DialogResult res = saveDialog.ShowDialog();

                if (res == System.Windows.Forms.DialogResult.OK)
                    SaveFile();

                return res;
            }

            return System.Windows.Forms.DialogResult.Ignore;
        }

        private void MenuFile_Events_Click(object sender, RoutedEventArgs e)
        {
            string name = ((MenuItem)sender).Name;

            switch (name)
            {
                case "New_MenuItem":
                    {
                        NewFile();

                        return;
                    }

                case "Open_MenuItem":
                    {
                        OpenFile();
                        return;
                    }

                case "Save_MenuItem":
                    {
                        SaveFile();
                        return;
                    }

                case "SaveAs_MenuItem":
                    {
                        SaveFileAs();
                        return;
                    }

               /* case "Print_MenuItem":
                    {
                        System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
                        if (pd.ShowDialog() == DialogResult.OK)
                        {
                            PrintDoc.PrinterSettings = pd.PrinterSettings;

                            PrintDoc.DocumentName = File.Exists(FileName) ? new FileInfo(FileName).Name : ProgramSets.UntitledFileName;

                            PrintDoc.Print();
                        }
                        return;
                    }*/

                case "Exit_MenuItem":
                    {
                        Close();
                        return;
                    }
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            contentHash = Content.GetHashCode();
            FileName = FileName;
            ContentViewer.Focus();
        }

        private void FluentWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveDialog s = new SaveDialog(FileName, saveFileDialog);

            if (contentHash != Content.GetHashCode())
            {
                switch (s.ShowDialog())
                {
                    case System.Windows.Forms.DialogResult.OK:
                        {
                            if (!File.Exists(FileName))
                                FileName = s.FileName;

                            SaveFile();
                            e.Cancel = false;
                            break;
                        }

                    case System.Windows.Forms.DialogResult.Cancel:
                        {
                            e.Cancel = true;
                            break;
                        }

                    case System.Windows.Forms.DialogResult.Abort:
                        {
                            e.Cancel = false;
                            break;
                        }
                }
            }
        }

        private void SetEncodingMenuItems()
        {
            EncodingInfo[] allEnc = Encoding.GetEncodings();
            MenuItem[] menuItems = new MenuItem[allEnc.Length];

            for (int i = 0; i < allEnc.Length; i++)
            {
                menuItems[i] = new MenuItem();
                menuItems[i].Name = $"encodingMenuItem{i}";
                menuItems[i].Header = allEnc[i].Name;
                menuItems[i].Tag = allEnc[i].CodePage;
                menuItems[i].Click += (s, e) =>
                {
                    int code = (int)((MenuItem)s).Tag;
                    Encoding enc = FileEncoding;
                    enc = Encoding.GetEncoding(code);

                    if (FileName != null && File.Exists(FileName))
                    {
                        SaveFileIfItChanged();

                        if (txtFile is not null)
                            txtFile.CloseFile();

                        if (txtsFile is not null && txtsFile.Path == FileName)
                        {
                            txtsFile.Encoding = enc;
                        }

                        FileEncoding = enc;
                        OpenFileAndReadContent(FileName, false);

                    }
                    FileEncoding = enc;
                   
                };
                DropDownEncodingMenu.Items.Add(menuItems[i]);
            }
        }

        #region MenuFileCommands
        private void NewFileCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuFile_Events_Click(New_MenuItem, e);
        }
        private void OpenFileCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuFile_Events_Click(Open_MenuItem, e);
        }
        private void SaveFileCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuFile_Events_Click(Save_MenuItem, e);
        }
        private void SaveAsFileCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuFile_Events_Click(SaveAs_MenuItem, e);
        }
        private void PrintFileCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuFile_Events_Click(Print_MenuItem, e);
        }

        #endregion
    }
}