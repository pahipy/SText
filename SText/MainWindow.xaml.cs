using SText.Conf;
using SText.Dialogs;
using SText.Formats;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using MenuItem = System.Windows.Controls.MenuItem;
using Microsoft.Win32;

using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using System.Drawing.Imaging;
using System.Xml.Linq;
using System.Diagnostics;

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

            AppIcon.Source = Tools.BitmapConverter.BitmapToBitmapImage(SText.Resources.STextIcon_Big, ImageFormat.Png);

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
            CurrentTheme = Theme.Light;

            LoadSettingsToStruct();

            SettingsManager = new GlobalSettingsManager(ProgramSets.ConfigFileName, Settings);

            ApplySettings();

            ContentViewer.TextChanged += (s, e) => { TitleText.Title = Title; };

            ContentViewer.PreviewMouseWheel += (s, e) =>
            {
                double newsize = e.Delta / 100d + ContentViewer.FontSize;
                if (newsize > 5 && newsize < 75 && FontSizeChangeByMouseWheelAct)
                {
                    if (ContentViewer.FontSize < newsize)
                        ContentViewer.LineDown();
                    else
                        ContentViewer.LineUp();

                    ContentViewer.FontSize = newsize;
                }
                FontSizeChangeByMouseWheelAct = false;
            };

            ContentViewer.KeyDown += (s, e) =>
            {
                FontSizeChangeByMouseWheelAct = e.Key == System.Windows.Input.Key.LeftCtrl;
            };

            ContentViewer.KeyUp += (s, e) =>
            {
                FontSizeChangeByMouseWheelAct = false;
            };

            ContentViewer.PreviewDragOver += (s, e) => e.Handled = true;

            ContentViewer.Drop += (s, e) =>
            {
                if (e.Data.GetDataPresent(System.Windows.DataFormats.FileDrop))
                {
                    string path = ((string[])e.Data.GetData(System.Windows.DataFormats.FileDrop))[0];
                    if (File.Exists(path))
                        OpenFile(false, path);
                }
            };

        }

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        private FontDialog fd = new FontDialog();
        private SettingsTemplate Settings;
        private GlobalSettingsManager SettingsManager;
        private bool FontSizeChangeByMouseWheelAct = false;
        private bool isDebug = true;
        private TXTSFormat txtsFile;
        private TXTFormat txtFile;
        private PasswordDialog setPasswordDialog;
        private PasswordDialog openPasswordDialog;
        private bool appWindowIsShown = false;
        private bool isReadOnly = false;
        private string oldContent = "";

        private Encoding fileEncoding;
        private Encoding FileEncoding
        {
            get => fileEncoding;
            set
            {
                fileEncoding = value;
                //DropDownEncodingMenu.Text = fileEncoding.EncodingName;
                foreach (ComboBoxItem cbi in DropDownEncodingMenu.Items)
                {
                    if (int.Parse(cbi.Tag.ToString()) == value.CodePage)
                        DropDownEncodingMenu.SelectedItem = cbi;
                }
            }
        }

        private System.Drawing.FontStyle FontStyleAsSystemDrawingFromContentViewer
        {
            get
            {
                switch (ContentViewer.FontWeight.ToString())
                {
                    case "Bold": return System.Drawing.FontStyle.Bold;
                }

                switch (ContentViewer.FontStyle.ToString())
                {
                    case "Normal": return System.Drawing.FontStyle.Regular;
                    case "Italic" or "Oblique": return System.Drawing.FontStyle.Italic;
                    
                }

                return System.Drawing.FontStyle.Regular;
            }
        }

        private System.Drawing.Font FontAsSystemDrawingFromContentViewer
        {
            get
            {
                System.Drawing.Font font = new Font(ContentViewer.FontFamily.Source, 
                    (float)(ContentViewer.FontSize / 96 * 72), FontStyleAsSystemDrawingFromContentViewer);

                return font;
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
                    title = $"●{title}";

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
            /*get => ContentViewer.TextWrapping == TextWrapping.Wrap;
            set
            {
                ContentViewer.TextWrapping = value ? TextWrapping.Wrap : TextWrapping.NoWrap;
                WordWrap_MenuItem.IsChecked = value;
            }*/

            get => ContentViewer.WordWrap;
            set => ContentViewer.WordWrap = value;
        }

        private Theme _currentTheme;
        private Theme CurrentTheme
        {
            get => _currentTheme;
            set
            {
                _currentTheme = value;

                switch (value)
                {
                    case Theme.Light:
                        {
                            ApplicationThemeManager.Apply(ApplicationTheme.Light);
                            ApplicationThemeManager.Apply(this);
                            ApplicationThemeManager.Apply(ApplicationTheme.Light);
                            ContentViewer.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                            ContentViewer.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
                            ThemeDark_MenuItem.IsChecked = false;
                            ThemeLight_MenuItem.IsChecked = true;
                            StatusBar_Theme.Content = "Theme: Light";
                            break;
                        }

                    case Theme.Dark:
                        {
                            ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                            ApplicationThemeManager.Apply(this);
                            ApplicationThemeManager.Apply(ApplicationTheme.Dark);
                            ContentViewer.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(25, 25, 25));
                            ContentViewer.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                            ThemeLight_MenuItem.IsChecked = false;
                            ThemeDark_MenuItem.IsChecked = true;
                            StatusBar_Theme.Content = "Theme: Dark";
                            break;
                        }
                }
            }
        }

        private void LoadSettingsToStruct()
        {
            Settings.CurrentTheme = CurrentTheme;
            Settings.ShowStatusBar = true;
            Settings.WordWrap = WordWrap;
            Settings.OnTop = Topmost;

            Settings.FontSize = FontAsSystemDrawingFromContentViewer.Size;
            Settings.FontFamily = FontAsSystemDrawingFromContentViewer.FontFamily.Name;
            Settings.FontStyle = (int)FontStyleAsSystemDrawingFromContentViewer;

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
            CurrentTheme = Settings.CurrentTheme;
            WordWrap = Settings.WordWrap;
            Topmost = Settings.OnTop; AlwaysOnTop_MenuItem.IsChecked = Settings.OnTop;
            ContentViewer.FontFamily = new System.Windows.Media.FontFamily(Settings.FontFamily);
            ContentViewer.FontSize = Settings.FontSize * 96 / 72;

            switch (Settings.FontStyle)
            {
                case 0: ContentViewer.FontStyle = FontStyles.Normal; break;
                case 1: ContentViewer.FontStyle = FontStyles.Italic; break;
                case 2: ContentViewer.FontWeight = FontWeights.Bold; break;
            }

            this.WindowState = (WindowState)Settings.WindowState;
            int left = Settings.WindowPosition.X < 0 ? -1 : Settings.WindowPosition.X;
            int top = Settings.WindowPosition.Y < 0 ? -1 : Settings.WindowPosition.Y;
            this.WindowStartupLocation = left < 0 && top < 0 ? WindowStartupLocation.CenterScreen
                : WindowStartupLocation.Manual;
            this.Left = left;
            this.Top = top;
            this.Width = Settings.WindowSize.Width;
            this.Height = Settings.WindowSize.Height;
            CurrentTheme = Settings.CurrentTheme;
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
                SaveDialog saveDialog = new SaveDialog(this, FileName, saveFileDialog);

                switch (saveDialog.ShowSDialog())
                {
                    case SDialogResult.Save:
                        {
                            if (!File.Exists(FileName))
                                FileName = saveDialog.FileName;

                            SaveFile();

                            NewFile();
                            break;
                        }
                    case SDialogResult.Cancel: return;
                    case SDialogResult.Abort: NewFile(true); return;
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
                else if (openFileDialog.ShowDialog() ?? false)
                {
                    OpenFileAndReadContent(openFileDialog.FileName);
                }
            }
            else
            {
                SaveDialog saveDialog = new SaveDialog(this, FileName, saveFileDialog);

                switch (saveDialog.ShowSDialog())
                {
                    case SDialogResult.Save:
                        {
                            if (!File.Exists(FileName))
                                FileName = saveDialog.FileName;

                            SaveFile();

                            OpenFile(false, path);
                            break;
                        }
                    case SDialogResult.Cancel: return;
                    case SDialogResult.Abort: OpenFile(true, path); return;
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
                        Action initAndGetOpenPassDlg = () =>
                        {
                            if (appWindowIsShown)
                            {
                                openPasswordDialog = new PasswordDialog(this, false);
                                openPasswordDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
                            }
                            else
                            {
                                openPasswordDialog = new PasswordDialog(null, false);
                                openPasswordDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                            }
                        };

                        Func<int> openTxts = () =>
                        {
                            
                            int tries = 3;

                            for (int i = 1; i <= tries; i++)
                            {
                                initAndGetOpenPassDlg();

                                if (openPasswordDialog.ShowSDialog() == SDialogResult.OK)
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
                if (saveFileDialog.ShowDialog() ?? false)
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
                setPasswordDialog = new PasswordDialog(this);

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
                        else if (setPasswordDialog.ShowSDialog() == SDialogResult.OK)
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
            catch (Exception ex)
            {
                DialogManager.ShowWarningDialogWithText(ex.Message);
                return false;
            }

        }

        private SDialogResult SaveFileIfItChanged()
        {
            if (contentHash != Content.GetHashCode())
            {
                SaveDialog saveDialog = new SaveDialog(this, FileName, saveFileDialog);
                SDialogResult res = saveDialog.ShowSDialog();

                if (res == SDialogResult.Save)
                    SaveFile();

                return res;
            }

            return SDialogResult.Ignore;
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

                case "Print_MenuItem":
                    {
                        var pd = new System.Windows.Controls.PrintDialog();
                        if (pd.ShowDialog() == true)
                        {
                            FlowDocument flowDocument = new FlowDocument();

                            flowDocument.PagePadding = new Thickness(50);
                            flowDocument.Blocks.Add(new Paragraph(new Run(ContentViewer.Text)));

                            string fileName = File.Exists(FileName) ? new FileInfo(FileName).Name : ProgramSets.UntitledFileName;

                            pd.PrintDocument((((IDocumentPaginatorSource)flowDocument).DocumentPaginator), fileName);

                        }
                        return;
                    }

                case "Exit_MenuItem":
                    {
                        Close();
                        return;
                    }
            }
        }

        private void MenuEdit_Events_Click(object sender, RoutedEventArgs e)
        {
            string name = ((MenuItem)sender).Name;

            switch (name)
            {
                case "Undo_MenuItem":
                    {
                        ContentViewer.Undo();
                        return;
                    }

                case "Cut_MenuItem":
                    {
                        ContentViewer.Cut();
                        return;
                    }

                case "Copy_MenuItem":
                    {
                        ContentViewer.Copy();
                        return;
                    }

                case "Paste_MenuItem":
                    {
                        ContentViewer.Paste();
                        return;
                    }

                case "Delete_MenuItem":
                    {
                        try
                        {
                            int start = ContentViewer.SelectionStart;
                            Content = Content.Remove(ContentViewer.SelectionStart, ContentViewer.SelectionLength);
                            ContentViewer.Select(start, 0);
                        }
                        catch { }

                        return;
                    }

                case "SelectAll_MenuItem":
                    {
                        ContentViewer.SelectAll();
                        return;
                    }

                case "DateTime_MenuItem":
                    {
                        try
                        {
                            int start = ContentViewer.SelectionStart;
                            DateTime dt = DateTime.Now;
                            Content = Content.Insert(ContentViewer.SelectionStart, dt.ToShortTimeString() + " "
                                + dt.ToShortDateString());

                            ContentViewer.Select(start, 0);

                        }
                        catch { }

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
            LoadSettingsToStruct();
            SettingsManager.Settings = Settings;
            SettingsManager.SaveConfig();

            SaveDialog s = new SaveDialog(this, FileName, saveFileDialog);

            if (contentHash != Content.GetHashCode())
            {
                switch (s.ShowSDialog())
                {
                    case SDialogResult.Save:
                        {
                            if (!File.Exists(FileName))
                                FileName = s.FileName;

                            SaveFile();
                            e.Cancel = false;
                            break;
                        }

                    case SDialogResult.Cancel:
                        {
                            e.Cancel = true;
                            break;
                        }

                    case SDialogResult.Abort:
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
            ComboBoxItem[] menuItems = new ComboBoxItem[allEnc.Length];

            for (int i = 0; i < allEnc.Length; i++)
            {
                menuItems[i] = new ComboBoxItem();
                menuItems[i].Name = $"encodingMenuItem{i}";
                menuItems[i].Content = allEnc[i].Name;
                menuItems[i].Tag = allEnc[i].CodePage;
                menuItems[i].Selected += (s, e) =>
                {
                    int code = (int)((ComboBoxItem)s).Tag;
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

#region MenuEditCommands
        private void DateTimeEditCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuEdit_Events_Click(DateTime_MenuItem, e);
        }
        #endregion

        private void WordWrap_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (MenuItem)sender;
            WordWrap = item.IsChecked;
        }

        private void ChangeFont_MenuItem_Click(object sender, RoutedEventArgs e)
        { 
            FontDialog fd = new FontDialog();

            fd.Font = FontAsSystemDrawingFromContentViewer;

            if (fd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ContentViewer.FontFamily = new System.Windows.Media.FontFamily(fd.Font.Name);
                ContentViewer.FontSize = fd.Font.Size * 96.0 / 72.0;
                ContentViewer.FontWeight = fd.Font.Bold ? FontWeights.Bold : FontWeights.Regular;
                ContentViewer.FontStyle = fd.Font.Italic ? FontStyles.Italic : FontStyles.Normal;

                TextDecorationCollection tdc = new TextDecorationCollection();
                if (fd.Font.Underline) tdc.Add(TextDecorations.Underline);
                if (fd.Font.Strikeout) tdc.Add(TextDecorations.Strikethrough);
               // ContentViewer.TextDecorations = tdc;
            }
        }

        private void AlwaysOnTop_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Topmost = ((MenuItem)sender).IsChecked;
        }

        private void TopmostMenuItemCommand(object sender, ExecutedRoutedEventArgs e)
        {
            AlwaysOnTop_MenuItem.IsChecked = !AlwaysOnTop_MenuItem.IsChecked;
            AlwaysOnTop_MenuItem_Click(AlwaysOnTop_MenuItem, e);
        }

        private void EncryptionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (FileName is null)
                return;

            if (!File.Exists(FileName))
                return;

            SDialogResult res = SaveFileIfItChanged();

            if (res == SDialogResult.Cancel) return;
            if (res == SDialogResult.Abort)
                Content = oldContent;

            string oldFile = FileName;

            if (txtsFile is null)
            {
                txtFile?.CloseFile();
                txtFile = null;

                FileName = System.IO.Path.ChangeExtension(FileName, ".txts");

            }
            else
            {

                Content = txtsFile.ReadFile();

                txtsFile.CloseFile();
                txtsFile = null;

                FileName = System.IO.Path.ChangeExtension(FileName, ".txt");
            }

            try
            {
                if (SaveFileAndUpdateHash(FileName))
                {
                    File.Delete(oldFile);
                }
                else
                {
                    File.Delete(FileName);
                    SaveFileAndUpdateHash(oldFile);
                }
            }
            catch (Exception ex)
            {
                DialogManager.ShowWarningDialogWithText(ex.Message);
            }

        }
        private void ToolsMemuItem_SubmenuOpened(object sender, RoutedEventArgs e)
        {
            string lableText = "Encrypt current file";


            if (txtsFile is not null && txtFile is null)
            {
                lableText = "Decrypt current file";
            }

            EncryptionMenuItem.IsEnabled = !(txtsFile is null && txtFile is null);


            EncryptionMenuItem.Header = lableText;
        }

        private void Help_MenuItems_Click(object sender, RoutedEventArgs e)
        {
            string name = ((MenuItem)sender).Name;

            switch (name)
            {
                case "About_MenuItem":
                    {
                        AboutDialog about = new AboutDialog(this);
                        about.ShowDialog();
                        break;
                    }

                case "Github_MenuItem":
                    {
                        try
                        {
                            var uri = ProgramSets.GitHubLink;
                            var psi = new ProcessStartInfo();
                            psi.UseShellExecute = true;
                            psi.FileName = uri;
                            Process.Start(psi);
                        }
                        catch { }
                        break;
                    }
            }
            
        }

        private void ThemeItems_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var sndr = (MenuItem)sender;
            sndr.IsChecked = true;
            string name = sndr.Name;
            
            CurrentTheme = name == "ThemeLight_MenuItem" ? Theme.Light : Theme.Dark;

        }

        private void ContextMenuItems_Click(object sender, RoutedEventArgs e)
        {
            string name = ((MenuItem)sender).Name;

            switch (name)
            {
                case "Undo_ContextMenuItem": ContentViewer.Undo(); break;
                case "Cut_ContextMenuItem": ContentViewer.Cut(); break;
                case "Copy_ContextMenuItem": ContentViewer.Copy(); break;
                case "Paste_ContextMenuItem": ContentViewer.Paste(); break;
                case "SelectAll_ContextMenuItem": ContentViewer.SelectAll(); break;
            }
        }

    }
}