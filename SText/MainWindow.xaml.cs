using ICSharpCode.AvalonEdit.Document;
using Microsoft.Win32;
using Newtonsoft.Json.Bson;
using Newtonsoft.Json.Linq;
using SText.Conf;
using SText.Dialogs;
using SText.Formats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
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
using System.Xml.Linq;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;
using static System.Net.Mime.MediaTypeNames;
using Font = System.Drawing.Font;
using MenuItem = System.Windows.Controls.MenuItem;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
using SaveFileDialog = Microsoft.Win32.SaveFileDialog;

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
            ApplicationThemeManager.Apply(ApplicationTheme.Light, WindowBackdropType.Mica);

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
            FileEncoding = Encoding.UTF8;

            CurrentTheme = Theme.Light;

            LoadSettingsToStruct();
            
            SettingsManager = new GlobalSettingsManager(ProgramSets.ConfigFileName, Settings);

            ApplySettings();

            ContentViewer.TextChanged += (s, e) =>
            {
                TitleText.Title = Title;
            };

            ContentViewer.PreviewKeyDown += (s, e) =>
            {
                if (Keyboard.Modifiers == ModifierKeys.Control)
                {
                    if (e.Key == Key.Z || e.Key == Key.Y)
                    {
                        e.Handled = true;

                        if (e.Key == Key.Z)
                            ContentViewer.Undo();

                        if (e.Key == Key.Y)
                            ContentViewer.Redo();

                        if (EndOfLineSequence.SelectedIndex == 0 && SDocumentText.EndOfLineType == EndOfLineType.CRLF)
                            EndOfLineSequence.SelectedIndex = 1;

                        if (EndOfLineSequence.SelectedIndex == 1 && SDocumentText.EndOfLineType == EndOfLineType.LF)
                            EndOfLineSequence.SelectedIndex = 0;

                    }
                }
            };

            ContentViewer.PreviewMouseWheel += (s, e) =>
            {
                double newsize = e.Delta / 100d + ContentViewer.FontSize;
                if (newsize > 5 && newsize < 75 && LeftCtrlIsPressing)
                {
                    if (ContentViewer.FontSize < newsize)
                        ContentViewer.LineDown();
                    else
                        ContentViewer.LineUp();

                    ContentViewer.FontSize = newsize;
                    RefreshHyperlinkStyle();
                }
                LeftCtrlIsPressing = false;
            };

            ContentViewer.KeyDown += (s, e) =>
            {
                LeftCtrlIsPressing = e.Key == System.Windows.Input.Key.LeftCtrl;
            };

            ContentViewer.KeyUp += (s, e) =>
            {
                LeftCtrlIsPressing = false;
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

            this.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Escape)
                {
                    if (SearchBox.Visibility == Visibility.Visible)
                    {
                        SearchBox.Visibility = Visibility.Hidden;
                        ContentViewer.Focus();
                    }
                }
            };

            EndOfLineSequence.SelectedIndex = 0;

            ContentViewer.Document.TextChanged += (s, e) =>
            {
                SDocumentText.SetText(ContentViewer.Document.Text);
                
            };

            SDocumentText.TextChanged += (s, e) =>
            {
                this.TitleText.Title = Title;
            };

            SDocumentText.TextCommited += (s, e) =>
            {
                this.TitleText.Title = Title;
            };
        }

        private OpenFileDialog openFileDialog;
        private SaveFileDialog saveFileDialog;

        private FontDialog fd = new FontDialog();
        private SettingsTemplate Settings;
        private GlobalSettingsManager SettingsManager;
        private bool LeftCtrlIsPressing = false;
        private bool isDebug = true;
        private Format TextFile;
        private PasswordDialog setPasswordDialog;
        private PasswordDialog openPasswordDialog;
        private bool appWindowIsShown = false;
        private bool isReadOnly = false;
        private bool lockEncodingChange = true;
        private string ShortFileName = ProgramSets.UntitledFileName;
        private SDocument SDocumentText = new SDocument("");
        private System.Windows.Media.Color hyperlinkColor = System.Windows.Media.Color.FromRgb(9, 40, 139);


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
                    ShortFileName = ProgramSets.UntitledFileName;
                }
                TitleText.Title = Title;
                StatusBar_File.Content = $"File: {ShortFileName}";
            }
        }

        private new string Title
        {
            get
            {
                string title = "";
                string readonlystring = isReadOnly ? "[READ ONLY]" : "";

                title = $"{ShortFileName} - {ProgramSets.ProgramName} {readonlystring}";
                StatusBar_File.Content = $"{ShortFileName} {readonlystring}";

                if (SDocumentText.IsChanged)
                {
                    StatusBar_File.Content = $"● {StatusBar_File.Content}";
                    title = $"● {title}";
                }

                StatusBar_File.Content = $"File: {StatusBar_File.Content}";

                base.Title = title;

                return title;
            }
        }


        private bool WordWrap
        {
            get => ContentViewer.WordWrap;
            set
            {
                ContentViewer.WordWrap = value;
                WordWrap_MenuItem.IsChecked = value;
            }
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
                            ApplicationThemeManager.Apply(ApplicationTheme.Light, WindowBackdropType.Mica);
                            ApplicationThemeManager.Apply(this);
                            ApplicationThemeManager.Apply(ApplicationTheme.Light, WindowBackdropType.Mica);
                            ContentViewer.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                            ContentViewer.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(0, 0, 0));
                            hyperlinkColor = System.Windows.Media.Color.FromRgb(9, 40, 139);
                            ThemeDark_MenuItem.IsChecked = false;
                            ThemeLight_MenuItem.IsChecked = true;
                            StatusBar_Theme.Content = "Theme: Light";
                            break;
                        }

                    case Theme.Dark:
                        {
                            ApplicationThemeManager.Apply(ApplicationTheme.Dark, WindowBackdropType.Mica);
                            ApplicationThemeManager.Apply(this);
                            ApplicationThemeManager.Apply(ApplicationTheme.Dark, WindowBackdropType.Mica);
                            ContentViewer.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(25, 25, 25));
                            ContentViewer.Foreground = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 255, 255));
                            hyperlinkColor = System.Windows.Media.Color.FromRgb(139, 167, 249);
                            ThemeLight_MenuItem.IsChecked = false;
                            ThemeDark_MenuItem.IsChecked = true;
                            StatusBar_Theme.Content = "Theme: Dark";
                            break;
                        }
                }

                RefreshHyperlinkStyle();
            }
        }

        private void RefreshHyperlinkStyle()
        {
            ContentViewer.TextArea.TextView.ElementGenerators.Clear();
            ContentViewer.TextArea.TextView.ElementGenerators.Add(new CustomLinkElementGeneratorColor(hyperlinkColor, ContentViewer.FontFamily,
                ContentViewer.FontSize));
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
            this.WindowStartupLocation = left < 0 && top < 0 || Settings.IsFirstStart ? WindowStartupLocation.CenterScreen
                : WindowStartupLocation.Manual;
            this.Left = left;
            this.Top = top;
            this.Width = Settings.WindowSize.Width;
            this.Height = Settings.WindowSize.Height;
            ContentViewer.Options.EnableHyperlinks = false;
            CurrentTheme = Settings.CurrentTheme;
        }

        private void NewFile(bool dontSaveFile = false)
        {
            if (!SDocumentText.IsChanged || dontSaveFile)
            {
                TextFile = null;
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

            if (!SDocumentText.IsChanged || dontSaveFile)
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
                string cont = "";

                if (TXTSFormat.IsTXTSFile(path))
                {
                    Action wnd = () =>
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

                    int tries = 3;
                    for (int i = 1; i <= tries; i++)
                    {
                        if (TextFile is TXTSFormat && !autodetectEncoding)
                        {
                            TextFile = new TXTSFormat(path, (TextFile as TXTSFormat).Password, FileEncoding);
                            break;
                        }

                        wnd();

                        if (openPasswordDialog.ShowSDialog() == SDialogResult.OK)
                        {
                            if (autodetectEncoding)
                                TextFile = new TXTSFormat(path, openPasswordDialog.Password);
                            else
                                TextFile = new TXTSFormat(path, openPasswordDialog.Password, fileEncoding);

                            if ((TextFile as TXTSFormat).Code == 1)
                            {
                                DialogManager.ShowWarningDialogWithText("Wrong password!");
                            }

                            if ((TextFile as TXTSFormat).Code == 0)
                            {
                                //success
                                break;
                            }

                            if (i == tries)
                            {
                                DialogManager.ShowDialogWithText($"You had {tries} only!");
                                return;
                            }

                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (autodetectEncoding)
                        TextFile = new TXTFormat(path);
                    else
                        TextFile = new TXTFormat(path, FileEncoding);
                }

                ShortFileName = new FileInfo(path).Name;
                cont = TextFile.Content;
                ContentViewer.Document.Text = cont;
                SDocumentText.EndOfLineType = cont.Contains("\r\n") ? EndOfLineType.CRLF : EndOfLineType.LF;
                SDocumentText.Commit();
                FileName = path;
                lockEncodingChange = true;
                FileEncoding = TextFile.FileEncoding;

                if (SDocumentText.EndOfLineType == EndOfLineType.CRLF)
                    EndOfLineSequence.SelectedIndex = 1;
                else
                    EndOfLineSequence.SelectedIndex = 0;

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
                SaveFileAndConfirm(FileName);
            }
            else SaveFileAs();
        }

        private void SaveFileAs()
        {
            try
            {
                if (saveFileDialog.ShowDialog() ?? false)
                {
                    SaveFileAndConfirm(saveFileDialog.FileName);
                }

                saveFileDialog.FileName = null;
            }
            catch { }
        }

        private bool SaveFileAndConfirm(string path)
        {

            try
            {
                setPasswordDialog = new PasswordDialog(this);

                SDocumentText.EndOfLineType = EndOfLineSequence.SelectedIndex == 0 ? EndOfLineType.LF : EndOfLineType.CRLF;

                if (path is not null)
                {
                    if (TextFile is TXTSFormat || new FileInfo(path).Extension.ToLower() == ".txts")
                    {
                        if (TextFile is TXTSFormat)
                        {
                            if (TextFile.Path != path)
                            {
                                TextFile = null;
                                return SaveFileAndConfirm(path);
                            }

                            try
                            {
                                TextFile.WriteFile(SDocumentText.CurrentFullText);
                            }
                            catch (Exception ex)
                            {
                                DialogManager.ShowWarningDialogWithText(ex.Message);
                                return false;
                            }
                        }
                        else if (setPasswordDialog.ShowSDialog() == SDialogResult.OK)
                        {
                            TextFile = new TXTSFormat(path, setPasswordDialog.Password, FileEncoding);
                            try
                            {
                                TextFile.WriteFile(SDocumentText.CurrentFullText);
                            }
                            catch (Exception ex)
                            {
                                DialogManager.ShowWarningDialogWithText(ex.Message);
                                return false;
                            }
                        }
                        else
                            return false;
                    }
                    else
                    {
                        if (TextFile is null)
                            TextFile = new TXTFormat(path, fileEncoding);

                        if (TextFile is not null && TextFile.Path != path)
                        {
                            TextFile = new TXTFormat(path, fileEncoding);
                        }

                        try
                        {
                            TextFile.WriteFile(SDocumentText.CurrentFullText);
                        }
                        catch (Exception ex)
                        {
                            DialogManager.ShowWarningDialogWithText(ex.Message);
                            return false;
                        }

                    }

                    isReadOnly = TextFile.IsReadOnly;
                    ShortFileName = new FileInfo(path).Name;
                    FileName = path;
                    SDocumentText.Commit();
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
            if (SDocumentText.IsChanged)
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

            if (name == "ToggleFind_MenuItem" || name == "ToggleReplace_MenuItem")
                SearchBox.Visibility = Visibility.Visible;

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
                            ContentViewer.Text = ContentViewer.Text.Remove(ContentViewer.SelectionStart, ContentViewer.SelectionLength);
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
                            ContentViewer.Text = ContentViewer.Text.Insert(ContentViewer.SelectionStart, dt.ToShortTimeString() + " "
                                + dt.ToShortDateString());

                            ContentViewer.Select(start, 0);

                        }
                        catch { }

                        return;
                    }

                case "ToggleFind_MenuItem":
                    {
                        if (ContentViewer.SelectionLength > 0)
                            SearchTextInput.Text = ContentViewer.SelectedText;

                        SearchTextInput.Focus();

                        ReplaceActivated = false;

                        return;
                    }

                case "ToggleReplace_MenuItem":
                    {
                        ReplaceActivated = true;
                        if (SearchTextInput.Text.Length < 1 || ContentViewer.SelectionLength > 0)
                        {
                            if (ContentViewer.SelectionLength > 0)
                            {
                                SearchTextInput.Text = ContentViewer.SelectedText;
                                ReplaceTextInput.Focus();
                                break;
                            }

                            SearchTextInput.Focus();
                        }
                        else
                        {
                            ReplaceTextInput.Focus();
                        }

                            return;
                    }
            }
        }

        private void ToggleFindCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuEdit_Events_Click(ToggleFind_MenuItem, e);
        }

        private void ToggleReplaceCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuEdit_Events_Click(ToggleReplace_MenuItem, e);
        }
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
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

            FileName = FileName;
            ContentViewer.Focus();
        }

        private void FluentWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadSettingsToStruct();
            SettingsManager.Settings = Settings;
            SettingsManager.SaveConfig();

            SaveDialog s = new SaveDialog(this, FileName, saveFileDialog);

            if (SDocumentText.IsChanged)
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

                    if (FileName is not null && File.Exists(FileName) && !lockEncodingChange)
                    {
                        SaveFileIfItChanged();

                        FileEncoding = enc;
                        OpenFileAndReadContent(FileName, false);
                        
                    }
                    FileEncoding = enc;
                    lockEncodingChange = false;
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
        private void WordWrap_MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (MenuItem)sender;
            WordWrap = item.IsChecked;
        }

        private void DateTimeEditCommand(object sender, ExecutedRoutedEventArgs e)
        {
            MenuEdit_Events_Click(DateTime_MenuItem, e);
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

                RefreshHyperlinkStyle();
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

        #endregion

        #region TextEditorMenuItems


        private void Undo_ContextMenuItemCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ContentViewer.Undo();
        }

        private void Cut_ContextMenuItemCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ContentViewer.Cut();
        }

        private void Copy_ContextMenuItemCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ContentViewer.Copy();
        }

        private void Paste_ContextMenuItemCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ContentViewer.Paste();
        }

        private void SelectAll_ContextMenuItemCommand(object sender, ExecutedRoutedEventArgs e)
        {
            ContentViewer.SelectAll();
        }

#endregion

        private void EncryptionMenuItem_Click(object sender, RoutedEventArgs e)
        {
            if (FileName is null)
                return;

            if (!File.Exists(FileName))
                return;

            SDialogResult res = SaveFileIfItChanged();

            if (res == SDialogResult.Cancel) return;
            if (res == SDialogResult.Abort)
            {
          
                /*Document.RollBack();
                ContentViewer.Text = Document.StrContent;*/
            }

            string oldFile = FileName;

            if (TextFile is not TXTSFormat)
            {
                FileName = System.IO.Path.ChangeExtension(FileName, ".txts");

            }
            else
            {

                ContentViewer.Document.Text = TextFile.Content;
                SDocumentText.EndOfLineType = TextFile.Content.Contains("\r\n") ? EndOfLineType.CRLF : EndOfLineType.LF;
                SDocumentText.Commit();

                FileName = System.IO.Path.ChangeExtension(FileName, ".txt");
            }

            try
            {
                if (SaveFileAndConfirm(FileName))
                {
                    File.Delete(oldFile);
                }
                else
                {
                    File.Delete(FileName);
                    SaveFileAndConfirm(oldFile);
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


            if (TextFile is TXTSFormat)
            {
                lableText = "Decrypt current file";
            }

            EncryptionMenuItem.IsEnabled = !(TextFile is null);


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

        private void EndOfLineSequence_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SDocumentText.EndOfLineType = EndOfLineSequence.SelectedIndex == 0 ? EndOfLineType.LF : EndOfLineType.CRLF;
            TitleText.Title = Title;
        }
    }
}