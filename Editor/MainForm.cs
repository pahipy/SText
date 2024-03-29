﻿using System.Text;
using System.Windows.Forms.Integration;
using System.IO;
using SText.Dialogs;
using SText.Conf;
using SText.Formats;
using WPFControls;
using System.Windows.Media;
using System.Windows.Controls;

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
            host.Child = ContentViewer;
            host.Dock = DockStyle.Fill;
            host.Visible = false;

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            SetEncodingMenuItems();

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


            ContentViewer.Inner.MouseWheel += (s, e) =>
            {
                double newsize = e.Delta / 100d + ContentViewer.Inner.FontSize;
                if (newsize > 5 && newsize < 75 && FontSizeChangeByMouseWheelAct)
                {
                    ContentViewer.Inner.FontSize = newsize;
                }
                FontSizeChangeByMouseWheelAct = false;
            };

            ContentViewer.Inner.KeyDown += (s, e) =>
            {
                FontSizeChangeByMouseWheelAct = e.Key == System.Windows.Input.Key.LeftCtrl;
            };

            ContentViewer.Inner.KeyUp += (s, e) =>
            {
                FontSizeChangeByMouseWheelAct = false;
            };

            ContentViewer.Inner.PreviewDragOver += (s, e) => e.Handled = true;

            ContentViewer.Inner.Drop += (s, e) =>
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    string path = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];
                    if (File.Exists(path))
                        OpenFile(false, path);
                }
            };

            ContentViewer.Inner.TextChanged += ContentViewer_TextChanged;



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
        private Textarea ContentViewer = new Textarea();
        private ElementHost host = new ElementHost();
        private string oldContent = "";

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

        private void MainForm_Load(object sender, EventArgs e)
        {
            contentHash = Content.GetHashCode();
            FileName = FileName;
            ContentPanel.Controls.Add(host);
            host.Visible = true;
            ContentViewer.Inner.Focus();
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
            catch { }
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
                        System.Windows.Forms.PrintDialog pd = new System.Windows.Forms.PrintDialog();
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
            string tag = ((ToolStripMenuItem)sender).Tag.ToString();

            switch (tag)
            {
                case "undo":
                    {
                        ContentViewer.Undo();
                        return;
                    }

                case "cut":
                    {
                        ContentViewer.Cut();
                        return;
                    }

                case "copy":
                    {
                        ContentViewer.Copy();
                        return;
                    }

                case "paste":
                    {
                        ContentViewer.Paste();
                        return;
                    }

                case "delete":
                    {
                        try
                        {
                            int start = ContentViewer.Inner.SelectionStart;
                            Content = Content.Remove(ContentViewer.Inner.SelectionStart, ContentViewer.Inner.SelectionLength);
                            ContentViewer.Inner.Select(start, 0);
                        }
                        catch { }

                        return;
                    }

                case "selectAll":
                    {
                        ContentViewer.SelectAll();
                        return;
                    }

                case "dateAndTime":
                    {
                        try
                        {
                            int start = ContentViewer.Inner.SelectionStart;
                            DateTime dt = DateTime.Now;
                            Content = Content.Insert(ContentViewer.SelectionStart, dt.ToShortTimeString() + " "
                                + dt.ToShortDateString());

                            ContentViewer.Inner.Select(start, 0);

                        }
                        catch { }

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

        private void OpenFile(bool dontSaveFile = false, string path = null)
        {

            if (Content.GetHashCode() == contentHash || dontSaveFile)
            {
                openFileDialog.FileName = null;

                if (path is not null && File.Exists(path))
                {
                    OpenFileAndReadContent(path);
                }
                else if (openFileDialog.ShowDialog() == DialogResult.OK)
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

                            OpenFile(false, path);
                            break;
                        }
                    case DialogResult.Cancel: return;
                    case DialogResult.Abort: OpenFile(true, path); return;
                }

            }
        }

        private void About_MenuItem_Click(object sender, EventArgs e)
        {
            AboutDialog ab = new AboutDialog(ProductVersion);
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

                case "ClassicalDarkTheme_MenuItem":
                    {
                        ThemeSelector.CurrentTheme = Theme.ClassicalDark;
                        break;
                    }
            }

            ApplyTheme();
        }

        private void ApplyTheme()
        {
            StatusBar_Theme.Text = $"Theme: {ThemeSelector.CurrentColorSchema.ThemeName}";

            System.Windows.Media.Color bcolor = System.Windows.Media.Color.FromRgb(ThemeSelector.CurrentColorSchema.TextFieldColor.R,
                ThemeSelector.CurrentColorSchema.TextFieldColor.G, ThemeSelector.CurrentColorSchema.TextFieldColor.B);

            System.Windows.Media.Color tcolor = System.Windows.Media.Color.FromRgb(ThemeSelector.CurrentColorSchema.TextFieldFontColor.R,
                ThemeSelector.CurrentColorSchema.TextFieldFontColor.G, ThemeSelector.CurrentColorSchema.TextFieldFontColor.B);

            ContentViewer.Backcolor = new SolidColorBrush(bcolor);
            ContentViewer.Textcolor = new SolidColorBrush(tcolor);
            ContentPanel.BackColor = ThemeSelector.CurrentColorSchema.TextFieldColor;
            this.BackColor = ThemeSelector.CurrentColorSchema.TextFieldColor;
            MainMenu.BackColor = ThemeSelector.CurrentColorSchema.MenuColor;
            MainMenu.ForeColor = ThemeSelector.CurrentColorSchema.MenuFontColor;
            ContentViewer.MenuSeparatorColor = new SolidColorBrush(ThemeSelector.CurrentColorSchema.MenuSeparatorColor);

            ContentViewer.ContextMenuBackground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(
                ThemeSelector.CurrentColorSchema.MenuColor.R, ThemeSelector.CurrentColorSchema.MenuColor.G,
                ThemeSelector.CurrentColorSchema.MenuColor.B));

            ContentViewer.ContextMenuForeground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(
                ThemeSelector.CurrentColorSchema.MenuFontColor.R, ThemeSelector.CurrentColorSchema.MenuFontColor.G,
                ThemeSelector.CurrentColorSchema.MenuFontColor.B));

            ContentViewer.MenuItemColorOnMouseHover = new SolidColorBrush(
                System.Windows.Media.Color.FromRgb(ThemeSelector.CurrentColorSchema.MenuItemSelectedColor.R,
                ThemeSelector.CurrentColorSchema.MenuItemSelectedColor.G, ThemeSelector.CurrentColorSchema.MenuItemSelectedColor.B));

            ContentViewer.MenuItemColorOnMousePressed = new SolidColorBrush(
                System.Windows.Media.Color.FromRgb(ThemeSelector.CurrentColorSchema.MenuItemSelectedColor.R,
                ThemeSelector.CurrentColorSchema.MenuItemSelectedColor.G, ThemeSelector.CurrentColorSchema.MenuItemSelectedColor.B));

            ContentViewer.BackgroundScrollBarColor = new SolidColorBrush(ThemeSelector.CurrentColorSchema.ScrollBarBackgroundColor);
            ContentViewer.ScrollBarThumbColor = ThemeSelector.CurrentColorSchema.ScrollBarThumbColor;
            ContentViewer.ScrollBarGlyphColor = ThemeSelector.CurrentColorSchema.ScrollBarGlyphColor;

            foreach (ToolStripMenuItem item in Theme_MenuItem.DropDownItems)
                item.Checked = false;

            switch (ThemeSelector.CurrentTheme)
            {
                case Theme.Default: DefaultTheme_MenuItem.Checked = true; break;
                case Theme.Dark: DarkTheme_MenuItem.Checked = true; break;
                case Theme.Blue: BlueTheme_MenuItem.Checked = true; break;
                case Theme.ClassicalDark: ClassicalDarkTheme_MenuItem.Checked = true; break;
            }
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

                            if (openPasswordDialog.ShowDialog() == DialogResult.OK)
                            {
                                txtsFile = new TXTSFormat(path, openPasswordDialog.Password);
                                cont = txtsFile.ReadFile();
                                isReadOnly = txtsFile.IsReadOnly;
                                if (autodetectEncoding)
                                    FileEncoding = txtsFile.Encoding;

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
                        else if (setPasswordDialog.ShowDialog() == DialogResult.OK)
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

        private void WordWrap_MenuItem_Click(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;
            WordWrap = item.Checked;
        }

        private void ShowStatusBar_MenuItem_Click(object sender, EventArgs e)
        {
            ShowStatusBar = ((ToolStripMenuItem)sender).Checked;
        }

        private void SetEncodingMenuItems()
        {
            EncodingInfo[] allEnc = Encoding.GetEncodings();
            ToolStripMenuItem[] menuItems = new ToolStripMenuItem[allEnc.Length];

            for (int i = 0; i < allEnc.Length; i++)
            {
                menuItems[i] = new ToolStripMenuItem();
                menuItems[i].Name = $"encodingMenuItem{i}";
                menuItems[i].Text = allEnc[i].Name;
                menuItems[i].Tag = allEnc[i].CodePage;
                menuItems[i].Click += (s, e) =>
                {
                    int code = (int)((ToolStripMenuItem)s).Tag;
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
            }

            DropDownEncodingMenu.Items.AddRange(menuItems);
        }

        private void ContentViewer_TextChanged(object sender, EventArgs e)
        {
            Text = Title;
        }

        #region Debug

        private void DebugMenuItems_Events(object sender, EventArgs e)
        {
            var item = (ToolStripMenuItem)sender;

            switch (item.Name)
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            appWindowIsShown = true;
        }

        private void PrintDoc_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;
            string strToPrint = Content;

            e.Graphics.MeasureString(strToPrint, ContentViewer.Font, e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            e.Graphics.DrawString(strToPrint, ContentViewer.Font, new SolidBrush(System.Drawing.Color.Black), e.MarginBounds,
                StringFormat.GenericTypographic);

            strToPrint = strToPrint.Substring(charactersOnPage);

            e.HasMorePages = (strToPrint.Length > 0);
        }

        private void Tools_EncryptAdnDecrypt_Click(object sender, EventArgs e)
        {
            if (FileName is null)
                return;

            if (!File.Exists(FileName))
                return;

            DialogResult res = SaveFileIfItChanged();

            if (res == DialogResult.Cancel) return;
            if (res == DialogResult.Abort)
                Content = oldContent;

            string oldFile = FileName;

            if (txtsFile is null)
            {
                txtFile?.CloseFile();
                txtFile = null;

                FileName = Path.ChangeExtension(FileName, ".txts");

            }
            else
            {

                Content = txtsFile.ReadFile();

                txtsFile.CloseFile();
                txtsFile = null;

                FileName = Path.ChangeExtension(FileName, ".txt");
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

        private DialogResult SaveFileIfItChanged()
        {
            if (contentHash != Content.GetHashCode())
            {
                SaveDialog saveDialog = new SaveDialog(FileName, saveFileDialog);
                DialogResult res = saveDialog.ShowDialog();

                if (res == DialogResult.OK)
                    SaveFile();

                return res;
            }

            return DialogResult.Ignore;
        }

        private void Tools_MenuItem_DropDownOpening(object sender, EventArgs e)
        {
            string lableText = "Encrypt current file";


            if (txtsFile is not null && txtFile is null)
            {
                lableText = "Dencrypt current file";
            }

            Tools_EncryptAdnDecrypt.Enabled = !(txtsFile is null && txtFile is null);


            Tools_EncryptAdnDecrypt.Text = lableText;
        }
    }
}
