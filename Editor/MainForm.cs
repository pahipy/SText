using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SText.Dialogs;
using SText.Conf;
using SText.Formats;

namespace SText.Editor
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

#if !DEBUG
            debugToolStripMenuItem.Visible = false;
            isDebug = false;
#endif

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            About_MenuItem.Text = $"About {ProgramSets.ProgramName}";

            MainMenu.Renderer = new CustomRenderForMenu();
            DropDownEncodingMenu.Renderer = new CustomRenderForMenu();
            StatusBar.Renderer = new CustomRenderForStatusBar();

            
            FileEncoding = Encoding.UTF8;
            ShowStatusBar = true;
            ThemeSelector.CurrentTheme = Theme.Default;

            LoadSettingsToStruct();

            SettingsManager = new GlobalSettingsManager(ProgramSets.ConfigFileName, Settings);

            ApplySettings();

            try {
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
            

            ContentViewer.MouseWheel += (s, e) =>
            {
                float newsize = e.Delta / 100 + ContentViewer.Font.Size;
                if ( newsize > 5 && newsize < 75 && FontSizeChangeByMouseWheelAct)
                {
                    ContentViewer.Font = new Font(ContentViewer.Font.FontFamily, newsize);
                }
                FontSizeChangeByMouseWheelAct = false;
            };

            ContentViewer.KeyDown += (s, e) =>
            {
                FontSizeChangeByMouseWheelAct = e.Control;
            };

            ContentViewer.KeyUp += (s, e) =>
            {
                FontSizeChangeByMouseWheelAct = e.Control;
            };

        }

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

        private Encoding fileEncoding;
        private Encoding FileEncoding
        {
            get => fileEncoding;
            set
            {
                fileEncoding = value;
                EncodingMenuButton.Text = fileEncoding.EncodingName;
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
                this.Text = Title;
                StatusBar_File.Text = $"File: {FileName}";
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

        private bool ShowStatusBar
        {
            get => ShowStatusBar_MenuItem.Checked;
            set
            {
                if (value)
                {
                    ShowStatusBar_MenuItem.Checked = true;
                    StatusBar.Visible = true;
                    ContentViewer.Height -= (ContentViewer.Height - StatusBar.Height);
                }
                else
                {
                    ShowStatusBar_MenuItem.Checked = false;
                    StatusBar.Visible = false;
                    ContentViewer.Height += (ContentViewer.Height - StatusBar.Height);
                }
            }
        }

        private bool WordWrap
        {
            get => ContentViewer.WordWrap;
            set
            {
                ContentViewer.WordWrap = value;
                WordWrap_MenuItem.Checked = value;
            }
        }

        private void LoadSettingsToStruct()
        {
            Settings.CurrentTheme = ThemeSelector.CurrentTheme;
            Settings.ShowStatusBar = ShowStatusBar;
            Settings.WordWrap = WordWrap;
            Settings.FontSize = ContentViewer.Font.Size;
            Settings.FontFamily = ContentViewer.Font.FontFamily.Name;
            Settings.FontStyle = (int)ContentViewer.Font.Style;
            
            if (WindowState != FormWindowState.Minimized)
                Settings.WindowState = (int)this.WindowState;

            if (WindowState != FormWindowState.Maximized && WindowState != FormWindowState.Minimized)
            {
                Settings.WindowPosition = new Point(Left, Top);
                Settings.WindowSize = this.Size;
            }
                
        }

        private void ApplySettings()
        {
            Settings = SettingsManager.Settings;
            ThemeSelector.CurrentTheme = Settings.CurrentTheme;
            ShowStatusBar = Settings.ShowStatusBar;
            WordWrap = Settings.WordWrap;
            ContentViewer.Font = new Font(Settings.FontFamily, Settings.FontSize, (FontStyle)Settings.FontStyle);
            this.WindowState = (FormWindowState)Settings.WindowState;
            this.Location = new Point(Settings.WindowPosition.X, Settings.WindowPosition.Y);
            this.Size = Settings.WindowSize;
            ApplyTheme();
        }

        private void ChangeFont_MenuItem_Click(object sender, EventArgs e)
        {
            fd.Font = ContentViewer.Font;
            fd.ShowDialog();
            ContentViewer.Font = fd.Font;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contentHash = Content.GetHashCode();
            FileName = FileName;
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
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveFileAndUpdateHash(saveFileDialog.FileName);
                }
                
                saveFileDialog.FileName = null;
            }
            catch{ }
        }

        private void MenuFile_Events_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).Name;

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
                        PrintDialog pd = new PrintDialog();
                        if (pd.ShowDialog() == DialogResult.OK)
                        {
                            PrintDoc.PrinterSettings = pd.PrinterSettings;

                            PrintDoc.DocumentName = File.Exists(FileName) ? new FileInfo(FileName).Name : ProgramSets.UntitledFileName;

                            PrintDoc.Print();
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

        private void MenuEdit_Events_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).Name;

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
                        /*int begin = ContentViewer.SelectionStart,
                            end = ContentViewer.SelectionLength + ContentViewer.SelectionStart;
                        ContentViewer.DeselectAll();
                        if (end < begin)
                        {
                            int k = begin;
                            begin = end;
                            end = k;
                        }

                        end = end < 0 ? -end : end;
                        begin = begin < 0 ? -begin : begin;

                        Content = Content.Remove(begin, end - 1);*/
                        if (ContentViewer.SelectedText.Length > 0)
                            Content = Content.Replace(ContentViewer.SelectedText, "");

                        return;
                    }

                case "SelectAll_MenuItem":
                    {
                        ContentViewer.SelectAll();
                        return;
                    }

                case "DateAndTime_MenuItem":
                    {
                        DateTime dt = DateTime.Now;
                        Content = Content.Insert(ContentViewer.SelectionStart, dt.ToShortTimeString() + " "
                            + dt.ToShortDateString());
                        return;
                    }
            }
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
                    case DialogResult.OK:
                        {
                            if (!File.Exists(FileName))
                                FileName = saveDialog.FileName;

                            SaveFile();

                            NewFile();
                            break;
                        }
                    case DialogResult.Cancel: return;
                    case DialogResult.Abort: NewFile(true); return;
                }
            }
        }

        private void OpenFile(bool dontSaveFile = false)
        {
            if (Content.GetHashCode() == contentHash || dontSaveFile)
            {
                openFileDialog.FileName = null;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    OpenFileAndReadContent(openFileDialog.FileName);
                }
            } 
            else
            {
                SaveDialog saveDialog = new SaveDialog(FileName, saveFileDialog);

                switch (saveDialog.ShowDialog())
                {
                    case DialogResult.OK: 
                        {
                            if (!File.Exists(FileName))
                                FileName = saveDialog.FileName;

                            SaveFile();

                            OpenFile();
                            break; 
                        }
                    case DialogResult.Cancel: return;
                    case DialogResult.Abort: OpenFile(true); return;
                }
                
            }
        }

        private void About_MenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog ab = new AboutDialog();
            ab.ShowDialog();
        }

        private void MenuTheme_Events_Click(object sender, EventArgs e)
        {
            string name = ((ToolStripMenuItem)sender).Name;

            switch (name)
            {
                case "DefaultTheme_MenuItem":
                    {
                        ThemeSelector.CurrentTheme = Theme.Default;
                        break;
                    }

                case "DarkTheme_MenuItem":
                    {
                        ThemeSelector.CurrentTheme = Theme.Dark;
                        break;
                    }

                case "BlueTheme_MenuItem":
                    {
                        ThemeSelector.CurrentTheme = Theme.Blue;
                        break;
                    }
            }

            ApplyTheme();
        }

        private void ApplyTheme()
        {
            switch (ThemeSelector.CurrentTheme)
            {
                case Theme.Default:
                    {
                        StatusBar_Theme.Text = "Theme: Default";
                        break;
                    }

                case Theme.Dark:
                    {
                        StatusBar_Theme.Text = "Theme: Dark";
                        break;
                    }

                case Theme.Blue:
                    {
                        StatusBar_Theme.Text = "Theme: Blue";
                        break;
                    }
            }

            ContentViewer.BackColor = ThemeSelector.CurrentColorSchema.TextFieldColor;
            ContentViewer.ForeColor = ThemeSelector.CurrentColorSchema.TextFieldFontColor;
            MainMenu.BackColor = ThemeSelector.CurrentColorSchema.MenuColor;
            MainMenu.ForeColor = ThemeSelector.CurrentColorSchema.MenuFontColor;
            
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadSettingsToStruct();
            SettingsManager.Settings = Settings;
            SettingsManager.SaveConfig();

            SaveDialog s = new SaveDialog(FileName, saveFileDialog);

            if (contentHash != Content.GetHashCode())
            {
                switch (s.ShowDialog())
                {
                    case DialogResult.OK:
                        {
                            if (!File.Exists(FileName))
                                FileName = s.FileName;

                            SaveFile();
                            e.Cancel = false;
                            break;
                        }

                    case DialogResult.Cancel:
                        {
                            e.Cancel = true;
                            break;
                        }

                    case DialogResult.Abort:
                        {
                            e.Cancel = false;
                            break;
                        }
                }
            }

        }

        private void OpenFileAndReadContent(string path)
        {

            try
            {
                if (path is not null && File.Exists(path))
                {
                    string cont = "";

                    if (txtsFile is not null || TXTSFormat.IsStxtFile(path))
                    {
                        Func<int> openTxts = () =>
                        {

                            if (!appWindowIsShown)
                                openPasswordDialog.StartPosition = FormStartPosition.CenterScreen;
                            else
                                openPasswordDialog.StartPosition = FormStartPosition.CenterParent;

                            if (openPasswordDialog.ShowDialog() == DialogResult.OK)
                            {
                                txtsFile = new TXTSFormat(path, openPasswordDialog.Password);
                                cont = txtsFile.ReadFile();

                                if (txtsFile.Code == 1)
                                {
                                    DialogManager.ShowWarningDialogWithText("Wrong password!");
                                    txtsFile.CloseFile();
                                    txtsFile = null;
                                    return 1;
                                }
                            }
                            else
                                return 1;

                            return 0;
                        };

                        if (txtsFile is not null)
                        {
                            if (txtsFile.Path != path)
                            {
                                txtsFile.CloseFile();
                                txtsFile = null;

                                if (!TXTSFormat.IsStxtFile(path))
                                {
                                    OpenFileAndReadContent(path);
                                    return;
                                }

                                if (openTxts() == 1)
                                    return;
                            }
                            else if (txtsFile.Password is not null)
                            {
                                cont = txtsFile.ReadFile();
                                isReadOnly = txtsFile.IsReadOnly;
                            }
                            else
                                return;
                        }
                        else
                        {
                            if (openTxts() == 1)
                                return;
                        }

                        FileEncoding = txtsFile.Encoding;
                    }
                    else
                    {
                        if (txtFile is not null)
                        {
                            txtFile.CloseFile();
                            txtFile = null;
                        }

                        txtFile = new TXTFormat(path, fileEncoding);
                        cont = txtFile.ReadFile();
                        isReadOnly = txtFile.IsReadOnly;
                    }

                    Content = cont;
                    contentHash = Content.GetHashCode();
                    FileName = path;
                }
            }
            catch (Exception ex)
            {
                DialogManager.ShowWarningDialogWithText(ex.Message);
            }
            
        }

        private void SaveFileAndUpdateHash(string path)
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
                                SaveFileAndUpdateHash(path);
                                return;
                            }

                            txtsFile.WriteFile(Content);
                            isReadOnly = txtsFile.IsReadOnly;
                        }
                        else if (setPasswordDialog.ShowDialog() == DialogResult.OK)
                        {
                            txtsFile = new TXTSFormat(path, setPasswordDialog.Password, FileEncoding);

                            txtsFile.WriteFile(Content);
                            isReadOnly = txtsFile.IsReadOnly;
                        }
                        else
                            return;
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

                        txtFile.WriteFile(Content);
                        isReadOnly = txtFile.IsReadOnly;
                    }

                    contentHash = Content.GetHashCode();
                    FileName = path;
                }
            }
            catch (ArgumentException ex)
            {
                DialogManager.ShowWarningDialogWithText(ex.Message);
            }
           
        }

        private void WordWrap_MenuItem_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            WordWrap = item.Checked;
        }

        private void ShowStatusBar_MenuItem_Click(object sender, EventArgs e)
        {
            ShowStatusBar = ((ToolStripMenuItem)sender).Checked;
        }

        private void EncodingMenu_Events_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            Encoding enc = FileEncoding;

            switch (item.Name)
            {
                case "UTF8_MenuItem":
                    {
                        enc = Encoding.UTF8;
                        break;
                    }

                case "UTF16_MenuItem":
                    {
                        enc = Encoding.Unicode;
                        break;
                    }

                case "ASCII_MenuItem":
                    {
                        enc = Encoding.ASCII;
                        break;
                    }

                case "UTF32_MenuItem":
                    {
                        enc = Encoding.UTF32;
                        break;
                    }

                case "ANSIEuro_MenuItem":
                    {
                        enc = Encoding.GetEncoding("Windows-1252");
                        break;
                    }

                case "ANSICyrillic_MenuItem":
                    {
                        enc = Encoding.GetEncoding("Windows-1251");
                        break;
                    }

                case "KOI8R_MenuItem":
                    {
                        enc = Encoding.GetEncoding("koi8-r");
                        break;
                    }
            }


            if (FileName != null && File.Exists(FileName))
            {
                if (contentHash != Content.GetHashCode())
                {
                    SaveDialog saveDialog = new SaveDialog(FileName, saveFileDialog);

                    switch (saveDialog.ShowDialog())
                    {
                        case DialogResult.OK: SaveFile(); break;
                        case DialogResult.Cancel: return;
                    }

                }
                if (txtFile is not null)
                    txtFile.CloseFile();

                if (txtsFile is not null && txtsFile.Path == FileName)
                {
                    txtsFile.Encoding = enc;
                }

                FileEncoding = enc;
                OpenFileAndReadContent(FileName);
                
            }
            FileEncoding = enc;
        }

        private void ContentViewer_TextChanged(object sender, EventArgs e)
        {
            Text = Title;
        }

        #region Debug
         
        private void DebugMenuItems_Events(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;

            switch(item.Name)
            {
                case "ShowCMD_DebugMenuItem":
                    {
                        string cmd = "";
                        foreach (string s in Environment.GetCommandLineArgs())
                            cmd += $"{s} ";
                        Content = cmd;
                        return;
                    }
                case "ShowSetPasswordDialog_DebugMenuItem":
                    {
                        setPasswordDialog.ShowDialog();
                        return;
                    }

                case "ShowOpenPasswordDialog_DebugMenuItem":
                    {
                        openPasswordDialog.ShowDialog();
                        return;
                    }
            }
        }

        #endregion

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (ContentViewer.SelectedText.Length > 0)
                ContentViewer.DeselectAll();

            appWindowIsShown = true;
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            string strToPrint = Content;

            e.Graphics.MeasureString(strToPrint, ContentViewer.Font, e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(strToPrint, ContentViewer.Font, new SolidBrush(Color.Black), e.MarginBounds,
                StringFormat.GenericTypographic);

            strToPrint = strToPrint.Substring(charactersOnPage);

            e.HasMorePages = (strToPrint.Length > 0);
        }
    }
}