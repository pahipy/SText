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

namespace SText.Editor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

#if !DEBUG
            debugToolStripMenuItem.Visible = false;
#endif

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            About_MenuItem.Text = $"About {ProgramSets.ProgramName}";

            MainMenu.Renderer = new CustomRender();
            
            FileEncoding = Encoding.UTF8;
            ShowStatusBar = true;
            ThemeSelector.CurrentTheme = Theme.Default;

            try {
                if (Environment.GetCommandLineArgs().Length > 1)
                {
                    string filename = "";
                    string[] cmd = Environment.GetCommandLineArgs();

                    for (int i = 1; i < cmd.Length; i++)
                        filename += $"{cmd[i]} ";

                    if (File.Exists(filename))
                    {
                        FileName = filename;
                        OpenFileAndReadContent(FileName);
                    }
 
                }
            }
            catch { }
            
            LoadSettingsToStruct();

            SettingsManager = new GlobalSettingsManager(ProgramSets.SettingsPath, Settings);

            ApplySettings();

            ContentViewer.MouseWheel += (sender, e) =>
            {
                float newsize = e.Delta / 100 + ContentViewer.Font.Size;
                if ( newsize > 5 && newsize < 75 && FontSizeChangeByMouseWheelAct)
                {
                    ContentViewer.Font = new Font(ContentViewer.Font.FontFamily, newsize);
                }
            };

            ContentViewer.KeyDown += (s, e) =>
            {
                if (e.Control)
                    FontSizeChangeByMouseWheelAct = true;
            };

            ContentViewer.KeyUp += (s, e) =>
            {
                if (e.KeyData == Keys.ControlKey)
                    FontSizeChangeByMouseWheelAct = false;
            };

        }

        private FontDialog fd = new FontDialog();
        private TextReader tr;
        private TextWriter tw;
        private SettingsTemplate Settings;
        private GlobalSettingsManager SettingsManager;
        private bool FontSizeChangeByMouseWheelAct = false;
        
        private Encoding fileEncoding;
        private Encoding FileEncoding
        {
            get => fileEncoding;
            set
            {
                fileEncoding = value;
                StatusBar_Encoding.Text = $"Encoding: {fileEncoding.EncodingName}";
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
                if (FileName != null && File.Exists(FileName))
                    title = $"{new FileInfo(FileName).Name} - {ProgramSets.ProgramName}";
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
            Settings = new SettingsTemplate();
            Settings.CurrentTheme = ThemeSelector.CurrentTheme;
            Settings.ShowStatusBar = ShowStatusBar;
            Settings.WordWrap = WordWrap;
            Settings.FontSize = ContentViewer.Font.Size;
            Settings.FontFamily = ContentViewer.Font.FontFamily.Name;
            Settings.WindowState = (int)this.WindowState;
            Settings.WindowPosition = new Point(Left, Top);
            Settings.WindowSize = this.Size;
        }

        private void ApplySettings()
        {
            Settings = SettingsManager.Settings;
            ThemeSelector.CurrentTheme = Settings.CurrentTheme;
            ShowStatusBar = Settings.ShowStatusBar;
            WordWrap = Settings.WordWrap;
            ContentViewer.Font = new Font(Settings.FontFamily, Settings.FontSize);
            this.WindowState = (FormWindowState)Settings.WindowState;
            if (WindowState != FormWindowState.Maximized)
            {
                this.Location = new Point(Settings.WindowPosition.X, Settings.WindowPosition.Y);
                this.Size = Settings.WindowSize;
            }
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
            if (File.Exists(FileName))
            {
                SaveFileAndUpdateHash(FileName);
            }
            else SaveFileAs();
        }

        private void SaveFileAs()
        {
            try
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    SaveFileAndUpdateHash(saveFileDialog1.FileName);
                }
                
                saveFileDialog1.FileName = null;
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
                        /* PrintDialog pd = new PrintDialog();
                        if(pd.ShowDialog()==DialogResult.OK)
                        {
                            PrintControllerWithStatusDialog pr;
                            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                            //pr.OnStartPrint(textBox1.Text,pd);
                        */
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
                        ContentViewer.Text += dt.ToShortTimeString() + " " + dt.ToShortDateString();
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
                FileName = null;
            }
            else
            {
                SaveDialog saveDialog = new SaveDialog(FileName, saveFileDialog1);

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
                openFileDialog1.FileName = null;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    OpenFileAndReadContent(openFileDialog1.FileName);
                }
            } 
            else
            {
                SaveDialog saveDialog = new SaveDialog(FileName, saveFileDialog1);

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

                case "CustomTheme_MenuItem":
                    {
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
                        ContentViewer.BackColor = Color.FromArgb(255, 255, 255);
                        ContentViewer.ForeColor = Color.FromArgb(0, 0, 0);
                        MainMenu.BackColor = Color.FromArgb(240, 240, 240);
                        MainMenu.ForeColor = Color.FromArgb(0, 0, 0);
                        StatusBar.BackColor = Color.FromArgb(240, 240, 240);
                        StatusBar.ForeColor = Color.FromArgb(0, 0, 0);
                        StatusBar_Theme.Text = "Theme: Default";
                        return;
                    }

                case Theme.Dark:
                    {
                        ContentViewer.BackColor = Color.FromArgb(66, 66, 66);
                        ContentViewer.ForeColor = Color.FromArgb(213, 213, 213);
                        MainMenu.BackColor = Color.FromArgb(52, 52, 52);
                        MainMenu.ForeColor = Color.White;
                        StatusBar.BackColor = Color.FromArgb(25, 60, 149);
                        StatusBar.ForeColor = Color.FromArgb(255, 255, 255);
                        StatusBar_Theme.Text = "Theme: Dark";
                        return;
                    }

                case Theme.Blue:
                    {
                        ContentViewer.BackColor = Color.FromArgb(231, 236, 255);
                        ContentViewer.ForeColor = Color.FromArgb(25, 69, 180);
                        MainMenu.BackColor = Color.FromArgb(35, 139, 255);
                        MainMenu.ForeColor = Color.White;
                        StatusBar.BackColor = Color.FromArgb(179, 208, 255);
                        StatusBar.ForeColor = Color.FromArgb(0, 0, 0);
                        StatusBar_Theme.Text = "Theme: Blue";
                        return;
                    }
            }
        }

        private void textBox1_VisibleChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            LoadSettingsToStruct();
            SettingsManager.Settings = Settings;
            SettingsManager.SaveConfig();

            SaveDialog s = new SaveDialog(FileName, saveFileDialog1);

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
            if (path != null && File.Exists(path))
            {
                //FileEncoding = EncodingHelper.GetFileEncoding(path);
                tr = new StreamReader(path, FileEncoding);
                //string buff = tr.ReadToEnd();
                Content = tr.ReadToEnd();
                contentHash = Content.GetHashCode();
                tr.Close();
                FileName = path;
            }
        }

        private void SaveFileAndUpdateHash(string path)
        {
            if (path != null)
            {
                //tw = File.Exists(path) ? new StreamWriter(path) : new StreamWriter(File.Create(path));
                if (File.Exists(path))
                {
                    tw = new StreamWriter(new FileStream(path, FileMode.Open, FileAccess.ReadWrite), FileEncoding);
                }
                else
                {
                    tw = new StreamWriter(File.Create(path), FileEncoding);
                }
                tw.Write(Content);
                tw.Close();
                contentHash = Content.GetHashCode();
                FileName = path;
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

            switch (item.Name)
            {
                case "UTF8_MenuItem":
                    {
                        FileEncoding = Encoding.UTF8;
                        break;
                    }

                case "UTF16_MenuItem":
                    {
                        FileEncoding = Encoding.Unicode;
                        break;
                    }

                case "ASCII_MenuItem":
                    {
                        FileEncoding = Encoding.ASCII;
                        break;
                    }

                case "UTF32_MenuItem":
                    {
                        FileEncoding = Encoding.UTF32;
                        break;
                    }

                case "ANSIEuro_MenuItem":
                    {
                        FileEncoding = Encoding.GetEncoding("Windows-1252");
                        break;
                    }

                case "ANSICyrillic_MenuItem":
                    {
                        FileEncoding = Encoding.GetEncoding("Windows-1251");
                        break;
                    }
            }

            if (FileName != null && File.Exists(FileName))
                OpenFileAndReadContent(FileName);

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
                case "ShowCMD_MenuItem":
                    {
                        string cmd = "";
                        foreach (string s in Environment.GetCommandLineArgs())
                            cmd += $"{s} ";
                        Content = cmd;
                        return;
                    }
            }
        }

        #endregion

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (ContentViewer.SelectedText.Length > 0)
                ContentViewer.DeselectAll();
        }
    }
}
