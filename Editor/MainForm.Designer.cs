namespace SText.Editor
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region The code was created by WinForms constructor

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            MainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            New_MenuItem = new ToolStripMenuItem();
            Open_MenuItem = new ToolStripMenuItem();
            Save_MenuItem = new ToolStripMenuItem();
            SaveAs_MenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            Print_MenuItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            Exit_MenuItem = new ToolStripMenuItem();
            editToolStripMenuItem = new ToolStripMenuItem();
            Undo_MenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            Cut_MenuItem = new ToolStripMenuItem();
            Copy_MenuItem = new ToolStripMenuItem();
            Paste_MenuItem = new ToolStripMenuItem();
            Delete_MenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            SelectAll_MenuItem = new ToolStripMenuItem();
            DateAndTime_MenuItem = new ToolStripMenuItem();
            formatToolStripMenuItem = new ToolStripMenuItem();
            WordWrap_MenuItem = new ToolStripMenuItem();
            fontToolStripMenuItem = new ToolStripMenuItem();
            viewToolStripMenuItem = new ToolStripMenuItem();
            ShowStatusBar_MenuItem = new ToolStripMenuItem();
            Theme_MenuItem = new ToolStripMenuItem();
            DefaultTheme_MenuItem = new ToolStripMenuItem();
            DarkTheme_MenuItem = new ToolStripMenuItem();
            BlueTheme_MenuItem = new ToolStripMenuItem();
            ClassicalDarkTheme_MenuItem = new ToolStripMenuItem();
            Tools_MenuItem = new ToolStripMenuItem();
            Tools_EncryptAdnDecrypt = new ToolStripMenuItem();
            debugToolStripMenuItem = new ToolStripMenuItem();
            ShowCMD_DebugMenuItem = new ToolStripMenuItem();
            ShowSetPasswordDialog_DebugMenuItem = new ToolStripMenuItem();
            ShowOpenPasswordDialog_DebugMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem1 = new ToolStripMenuItem();
            About_MenuItem = new ToolStripMenuItem();
            openFileDialog = new OpenFileDialog();
            saveFileDialog = new SaveFileDialog();
            StatusBar = new ToolStrip();
            StatusBar_Theme = new ToolStripStatusLabel();
            StatusBar_File = new ToolStripStatusLabel();
            EncodingMenuButton = new ToolStripDropDownButton();
            DropDownEncodingMenu = new ContextMenuStrip(components);
            UTF8_MenuItem = new ToolStripMenuItem();
            UTF16_MenuItem = new ToolStripMenuItem();
            UTF32_MenuItem = new ToolStripMenuItem();
            ASCII_MenuItem = new ToolStripMenuItem();
            ANSIEuro_MenuItem = new ToolStripMenuItem();
            ANSICyrillic_MenuItem = new ToolStripMenuItem();
            KOI8R_MenuItem = new ToolStripMenuItem();
            ContentPanel = new Panel();
            PrintDoc = new System.Drawing.Printing.PrintDocument();
            MainMenu.SuspendLayout();
            StatusBar.SuspendLayout();
            SuspendLayout();
            // 
            // MainMenu
            // 
            MainMenu.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            MainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, editToolStripMenuItem, formatToolStripMenuItem, viewToolStripMenuItem, Tools_MenuItem, debugToolStripMenuItem, helpToolStripMenuItem1 });
            MainMenu.Location = new Point(0, 0);
            MainMenu.Name = "MainMenu";
            MainMenu.Padding = new Padding(7, 0, 0, 0);
            MainMenu.RenderMode = ToolStripRenderMode.Professional;
            MainMenu.Size = new Size(1115, 24);
            MainMenu.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { New_MenuItem, Open_MenuItem, Save_MenuItem, SaveAs_MenuItem, toolStripSeparator1, Print_MenuItem, toolStripSeparator2, Exit_MenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // New_MenuItem
            // 
            New_MenuItem.Name = "New_MenuItem";
            New_MenuItem.ShortcutKeys = Keys.Control | Keys.N;
            New_MenuItem.Size = new Size(195, 22);
            New_MenuItem.Text = "New";
            New_MenuItem.Click += MenuFile_Events_Click;
            // 
            // Open_MenuItem
            // 
            Open_MenuItem.Name = "Open_MenuItem";
            Open_MenuItem.ShortcutKeys = Keys.Control | Keys.O;
            Open_MenuItem.Size = new Size(195, 22);
            Open_MenuItem.Text = "Open...";
            Open_MenuItem.Click += MenuFile_Events_Click;
            // 
            // Save_MenuItem
            // 
            Save_MenuItem.Name = "Save_MenuItem";
            Save_MenuItem.ShortcutKeys = Keys.Control | Keys.S;
            Save_MenuItem.Size = new Size(195, 22);
            Save_MenuItem.Text = "Save";
            Save_MenuItem.Click += MenuFile_Events_Click;
            // 
            // SaveAs_MenuItem
            // 
            SaveAs_MenuItem.Name = "SaveAs_MenuItem";
            SaveAs_MenuItem.ShortcutKeys = Keys.Control | Keys.Shift | Keys.S;
            SaveAs_MenuItem.Size = new Size(195, 22);
            SaveAs_MenuItem.Text = "Save As...";
            SaveAs_MenuItem.Click += MenuFile_Events_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(192, 6);
            // 
            // Print_MenuItem
            // 
            Print_MenuItem.Name = "Print_MenuItem";
            Print_MenuItem.ShortcutKeys = Keys.Control | Keys.P;
            Print_MenuItem.Size = new Size(195, 22);
            Print_MenuItem.Text = "Print";
            Print_MenuItem.Click += MenuFile_Events_Click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(192, 6);
            // 
            // Exit_MenuItem
            // 
            Exit_MenuItem.Name = "Exit_MenuItem";
            Exit_MenuItem.Size = new Size(195, 22);
            Exit_MenuItem.Text = "Exit";
            Exit_MenuItem.Click += MenuFile_Events_Click;
            // 
            // editToolStripMenuItem
            // 
            editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { Undo_MenuItem, toolStripSeparator3, Cut_MenuItem, Copy_MenuItem, Paste_MenuItem, Delete_MenuItem, toolStripSeparator4, SelectAll_MenuItem, DateAndTime_MenuItem });
            editToolStripMenuItem.Name = "editToolStripMenuItem";
            editToolStripMenuItem.Size = new Size(39, 24);
            editToolStripMenuItem.Text = "Edit";
            // 
            // Undo_MenuItem
            // 
            Undo_MenuItem.Name = "Undo_MenuItem";
            Undo_MenuItem.ShortcutKeys = Keys.Control | Keys.Z;
            Undo_MenuItem.Size = new Size(164, 22);
            Undo_MenuItem.Tag = "undo";
            Undo_MenuItem.Text = "Undo";
            Undo_MenuItem.Click += MenuEdit_Events_Click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(161, 6);
            // 
            // Cut_MenuItem
            // 
            Cut_MenuItem.Name = "Cut_MenuItem";
            Cut_MenuItem.ShortcutKeys = Keys.Control | Keys.X;
            Cut_MenuItem.Size = new Size(164, 22);
            Cut_MenuItem.Tag = "cut";
            Cut_MenuItem.Text = "Cut";
            Cut_MenuItem.Click += MenuEdit_Events_Click;
            // 
            // Copy_MenuItem
            // 
            Copy_MenuItem.Name = "Copy_MenuItem";
            Copy_MenuItem.ShortcutKeys = Keys.Control | Keys.C;
            Copy_MenuItem.Size = new Size(164, 22);
            Copy_MenuItem.Tag = "copy";
            Copy_MenuItem.Text = "Copy";
            Copy_MenuItem.Click += MenuEdit_Events_Click;
            // 
            // Paste_MenuItem
            // 
            Paste_MenuItem.Name = "Paste_MenuItem";
            Paste_MenuItem.ShortcutKeys = Keys.Control | Keys.V;
            Paste_MenuItem.Size = new Size(164, 22);
            Paste_MenuItem.Tag = "paste";
            Paste_MenuItem.Text = "Paste";
            Paste_MenuItem.Click += MenuEdit_Events_Click;
            // 
            // Delete_MenuItem
            // 
            Delete_MenuItem.Name = "Delete_MenuItem";
            Delete_MenuItem.Size = new Size(164, 22);
            Delete_MenuItem.Tag = "delete";
            Delete_MenuItem.Text = "Delete";
            Delete_MenuItem.Click += MenuEdit_Events_Click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(161, 6);
            // 
            // SelectAll_MenuItem
            // 
            SelectAll_MenuItem.Name = "SelectAll_MenuItem";
            SelectAll_MenuItem.ShortcutKeys = Keys.Control | Keys.A;
            SelectAll_MenuItem.Size = new Size(164, 22);
            SelectAll_MenuItem.Tag = "selectAll";
            SelectAll_MenuItem.Text = "Select All";
            SelectAll_MenuItem.Click += MenuEdit_Events_Click;
            // 
            // DateAndTime_MenuItem
            // 
            DateAndTime_MenuItem.Name = "DateAndTime_MenuItem";
            DateAndTime_MenuItem.ShortcutKeys = Keys.F5;
            DateAndTime_MenuItem.Size = new Size(164, 22);
            DateAndTime_MenuItem.Tag = "dateAndTime";
            DateAndTime_MenuItem.Text = "Date/Time";
            DateAndTime_MenuItem.Click += MenuEdit_Events_Click;
            // 
            // formatToolStripMenuItem
            // 
            formatToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { WordWrap_MenuItem, fontToolStripMenuItem });
            formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            formatToolStripMenuItem.Size = new Size(57, 24);
            formatToolStripMenuItem.Text = "Format";
            // 
            // WordWrap_MenuItem
            // 
            WordWrap_MenuItem.CheckOnClick = true;
            WordWrap_MenuItem.Name = "WordWrap_MenuItem";
            WordWrap_MenuItem.Size = new Size(134, 22);
            WordWrap_MenuItem.Text = "Word Wrap";
            WordWrap_MenuItem.Click += WordWrap_MenuItem_Click;
            // 
            // fontToolStripMenuItem
            // 
            fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            fontToolStripMenuItem.Size = new Size(134, 22);
            fontToolStripMenuItem.Text = "Font...";
            fontToolStripMenuItem.Click += ChangeFont_MenuItem_Click;
            // 
            // viewToolStripMenuItem
            // 
            viewToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ShowStatusBar_MenuItem, Theme_MenuItem });
            viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            viewToolStripMenuItem.Size = new Size(44, 24);
            viewToolStripMenuItem.Text = "View";
            // 
            // ShowStatusBar_MenuItem
            // 
            ShowStatusBar_MenuItem.Checked = true;
            ShowStatusBar_MenuItem.CheckOnClick = true;
            ShowStatusBar_MenuItem.CheckState = CheckState.Checked;
            ShowStatusBar_MenuItem.Name = "ShowStatusBar_MenuItem";
            ShowStatusBar_MenuItem.Size = new Size(126, 22);
            ShowStatusBar_MenuItem.Text = "Status Bar";
            ShowStatusBar_MenuItem.Click += ShowStatusBar_MenuItem_Click;
            // 
            // Theme_MenuItem
            // 
            Theme_MenuItem.DropDownItems.AddRange(new ToolStripItem[] { DefaultTheme_MenuItem, DarkTheme_MenuItem, BlueTheme_MenuItem, ClassicalDarkTheme_MenuItem });
            Theme_MenuItem.Name = "Theme_MenuItem";
            Theme_MenuItem.Size = new Size(126, 22);
            Theme_MenuItem.Text = "Theme";
            // 
            // DefaultTheme_MenuItem
            // 
            DefaultTheme_MenuItem.Name = "DefaultTheme_MenuItem";
            DefaultTheme_MenuItem.Size = new Size(146, 22);
            DefaultTheme_MenuItem.Tag = "0";
            DefaultTheme_MenuItem.Text = "Default";
            DefaultTheme_MenuItem.Click += MenuTheme_Events_Click;
            // 
            // DarkTheme_MenuItem
            // 
            DarkTheme_MenuItem.Name = "DarkTheme_MenuItem";
            DarkTheme_MenuItem.Size = new Size(146, 22);
            DarkTheme_MenuItem.Tag = "1";
            DarkTheme_MenuItem.Text = "Dark";
            DarkTheme_MenuItem.Click += MenuTheme_Events_Click;
            // 
            // BlueTheme_MenuItem
            // 
            BlueTheme_MenuItem.Name = "BlueTheme_MenuItem";
            BlueTheme_MenuItem.Size = new Size(146, 22);
            BlueTheme_MenuItem.Tag = "2";
            BlueTheme_MenuItem.Text = "Blue";
            BlueTheme_MenuItem.Click += MenuTheme_Events_Click;
            // 
            // ClassicalDarkTheme_MenuItem
            // 
            ClassicalDarkTheme_MenuItem.Name = "ClassicalDarkTheme_MenuItem";
            ClassicalDarkTheme_MenuItem.Size = new Size(146, 22);
            ClassicalDarkTheme_MenuItem.Text = "Classical Dark";
            ClassicalDarkTheme_MenuItem.Click += MenuTheme_Events_Click;
            // 
            // Tools_MenuItem
            // 
            Tools_MenuItem.DropDownItems.AddRange(new ToolStripItem[] { Tools_EncryptAdnDecrypt });
            Tools_MenuItem.Name = "Tools_MenuItem";
            Tools_MenuItem.Size = new Size(46, 24);
            Tools_MenuItem.Text = "Tools";
            Tools_MenuItem.DropDownOpening += Tools_MenuItem_DropDownOpening;
            // 
            // Tools_EncryptAdnDecrypt
            // 
            Tools_EncryptAdnDecrypt.Name = "Tools_EncryptAdnDecrypt";
            Tools_EncryptAdnDecrypt.ShortcutKeys = Keys.Control | Keys.E;
            Tools_EncryptAdnDecrypt.Size = new Size(200, 22);
            Tools_EncryptAdnDecrypt.Text = "Encrypt/Decrypt";
            Tools_EncryptAdnDecrypt.Click += Tools_EncryptAdnDecrypt_Click;
            // 
            // debugToolStripMenuItem
            // 
            debugToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ShowCMD_DebugMenuItem, ShowSetPasswordDialog_DebugMenuItem, ShowOpenPasswordDialog_DebugMenuItem });
            debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            debugToolStripMenuItem.Size = new Size(54, 24);
            debugToolStripMenuItem.Text = "Debug";
            // 
            // ShowCMD_DebugMenuItem
            // 
            ShowCMD_DebugMenuItem.Name = "ShowCMD_DebugMenuItem";
            ShowCMD_DebugMenuItem.Size = new Size(250, 22);
            ShowCMD_DebugMenuItem.Text = "Show Command Line Arguments";
            ShowCMD_DebugMenuItem.Click += DebugMenuItems_Events;
            // 
            // ShowSetPasswordDialog_DebugMenuItem
            // 
            ShowSetPasswordDialog_DebugMenuItem.Name = "ShowSetPasswordDialog_DebugMenuItem";
            ShowSetPasswordDialog_DebugMenuItem.Size = new Size(250, 22);
            ShowSetPasswordDialog_DebugMenuItem.Text = "Show SetPasswordDialog";
            ShowSetPasswordDialog_DebugMenuItem.Click += DebugMenuItems_Events;
            // 
            // ShowOpenPasswordDialog_DebugMenuItem
            // 
            ShowOpenPasswordDialog_DebugMenuItem.Name = "ShowOpenPasswordDialog_DebugMenuItem";
            ShowOpenPasswordDialog_DebugMenuItem.Size = new Size(250, 22);
            ShowOpenPasswordDialog_DebugMenuItem.Text = "Show OpenPasswordDialog";
            ShowOpenPasswordDialog_DebugMenuItem.Click += DebugMenuItems_Events;
            // 
            // helpToolStripMenuItem1
            // 
            helpToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { About_MenuItem });
            helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            helpToolStripMenuItem1.Size = new Size(44, 24);
            helpToolStripMenuItem1.Text = "Help";
            // 
            // About_MenuItem
            // 
            About_MenuItem.Name = "About_MenuItem";
            About_MenuItem.Size = new Size(137, 22);
            About_MenuItem.Text = "About SText";
            About_MenuItem.Click += About_MenuItem_Click;
            // 
            // openFileDialog
            // 
            openFileDialog.CheckFileExists = false;
            openFileDialog.Filter = "Text Documents|*.txt|SText Documents|*.txts|All Files|*.*";
            openFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            saveFileDialog.Filter = "Text Documents|*.txt|SText Documents|*.txts|All Files|*.*";
            saveFileDialog.RestoreDirectory = true;
            // 
            // StatusBar
            // 
            StatusBar.AutoSize = false;
            StatusBar.BackgroundImageLayout = ImageLayout.None;
            StatusBar.Dock = DockStyle.Bottom;
            StatusBar.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            StatusBar.GripStyle = ToolStripGripStyle.Hidden;
            StatusBar.Items.AddRange(new ToolStripItem[] { StatusBar_Theme, StatusBar_File, EncodingMenuButton });
            StatusBar.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            StatusBar.Location = new Point(0, 540);
            StatusBar.Name = "StatusBar";
            StatusBar.Padding = new Padding(1, 0, 16, 0);
            StatusBar.RenderMode = ToolStripRenderMode.Professional;
            StatusBar.Size = new Size(1115, 29);
            StatusBar.TabIndex = 3;
            // 
            // StatusBar_Theme
            // 
            StatusBar_Theme.Margin = new Padding(0);
            StatusBar_Theme.Name = "StatusBar_Theme";
            StatusBar_Theme.Size = new Size(46, 29);
            StatusBar_Theme.Text = "Theme:";
            // 
            // StatusBar_File
            // 
            StatusBar_File.Margin = new Padding(0);
            StatusBar_File.Name = "StatusBar_File";
            StatusBar_File.Size = new Size(28, 29);
            StatusBar_File.Text = "File:";
            // 
            // EncodingMenuButton
            // 
            EncodingMenuButton.Alignment = ToolStripItemAlignment.Right;
            EncodingMenuButton.BackgroundImageLayout = ImageLayout.None;
            EncodingMenuButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            EncodingMenuButton.DropDown = DropDownEncodingMenu;
            EncodingMenuButton.ImageTransparentColor = Color.Magenta;
            EncodingMenuButton.Margin = new Padding(0);
            EncodingMenuButton.Name = "EncodingMenuButton";
            EncodingMenuButton.Size = new Size(70, 29);
            EncodingMenuButton.Text = "Encoding";
            EncodingMenuButton.ToolTipText = "Encoding";
            // 
            // DropDownEncodingMenu
            // 
            DropDownEncodingMenu.BackgroundImageLayout = ImageLayout.None;
            DropDownEncodingMenu.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
            DropDownEncodingMenu.Name = "DropDownEncodingMenu";
            DropDownEncodingMenu.OwnerItem = EncodingMenuButton;
            DropDownEncodingMenu.RenderMode = ToolStripRenderMode.Professional;
            DropDownEncodingMenu.ShowItemToolTips = false;
            DropDownEncodingMenu.Size = new Size(61, 4);
            // 
            // UTF8_MenuItem
            // 
            UTF8_MenuItem.Name = "UTF8_MenuItem";
            UTF8_MenuItem.Size = new Size(32, 19);
            // 
            // UTF16_MenuItem
            // 
            UTF16_MenuItem.Name = "UTF16_MenuItem";
            UTF16_MenuItem.Size = new Size(32, 19);
            // 
            // UTF32_MenuItem
            // 
            UTF32_MenuItem.Name = "UTF32_MenuItem";
            UTF32_MenuItem.Size = new Size(32, 19);
            // 
            // ASCII_MenuItem
            // 
            ASCII_MenuItem.Name = "ASCII_MenuItem";
            ASCII_MenuItem.Size = new Size(32, 19);
            // 
            // ANSIEuro_MenuItem
            // 
            ANSIEuro_MenuItem.Name = "ANSIEuro_MenuItem";
            ANSIEuro_MenuItem.Size = new Size(32, 19);
            // 
            // ANSICyrillic_MenuItem
            // 
            ANSICyrillic_MenuItem.Name = "ANSICyrillic_MenuItem";
            ANSICyrillic_MenuItem.Size = new Size(32, 19);
            // 
            // KOI8R_MenuItem
            // 
            KOI8R_MenuItem.Name = "KOI8R_MenuItem";
            KOI8R_MenuItem.Size = new Size(32, 19);
            // 
            // ContentPanel
            // 
            ContentPanel.Dock = DockStyle.Fill;
            ContentPanel.Location = new Point(0, 24);
            ContentPanel.Margin = new Padding(4, 3, 4, 3);
            ContentPanel.Name = "ContentPanel";
            ContentPanel.Size = new Size(1115, 516);
            ContentPanel.TabIndex = 4;
            // 
            // PrintDoc
            // 
            PrintDoc.PrintPage += PrintDoc_PrintPage;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1115, 569);
            Controls.Add(ContentPanel);
            Controls.Add(MainMenu);
            Controls.Add(StatusBar);
            DoubleBuffered = true;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = MainMenu;
            Margin = new Padding(4, 3, 4, 3);
            MinimumSize = new Size(200, 100);
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "SText";
            FormClosing += Form1_FormClosing;
            Load += MainForm_Load;
            Shown += MainForm_Shown;
            MainMenu.ResumeLayout(false);
            MainMenu.PerformLayout();
            StatusBar.ResumeLayout(false);
            StatusBar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem New_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Open_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Save_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveAs_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Print_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exit_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Undo_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Cut_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Copy_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Paste_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem Delete_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem SelectAll_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DateAndTime_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem WordWrap_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ShowStatusBar_MenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem Theme_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem About_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DefaultTheme_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DarkTheme_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlueTheme_MenuItem;
        private System.Windows.Forms.ToolStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Theme;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_File;
        private System.Windows.Forms.Panel ContentPanel;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem ShowCMD_DebugMenuItem;
        private System.Drawing.Printing.PrintDocument PrintDoc;
        private ToolStripDropDownButton EncodingMenuButton;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ContextMenuStrip DropDownEncodingMenu;
        private ToolStripMenuItem UTF8_MenuItem;
        private ToolStripMenuItem UTF16_MenuItem;
        private ToolStripMenuItem UTF32_MenuItem;
        private ToolStripMenuItem ASCII_MenuItem;
        private ToolStripMenuItem ANSIEuro_MenuItem;
        private ToolStripMenuItem ANSICyrillic_MenuItem;
        private ToolStripMenuItem KOI8R_MenuItem;
        private ToolStripMenuItem ShowSetPasswordDialog_DebugMenuItem;
        private ToolStripMenuItem ShowOpenPasswordDialog_DebugMenuItem;
        private ToolStripMenuItem ClassicalDarkTheme_MenuItem;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem Tools_MenuItem;
        private ToolStripMenuItem Tools_EncryptAdnDecrypt;
    }
}

