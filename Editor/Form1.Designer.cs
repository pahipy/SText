namespace SText.Editor
{
    partial class Form1
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.New_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Print_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Undo_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cut_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAll_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateAndTime_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.encodingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UTF8_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UTF16_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UTF32_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ASCII_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ANSIEuro_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ANSICyrillic_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WordWrap_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowStatusBar_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Theme_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DefaultTheme_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DarkTheme_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BlueTheme_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowCMD_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentViewer = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBar_Theme = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_File = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_Encoding = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PrintDoc = new System.Drawing.Printing.PrintDocument();
            this.MainMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.helpToolStripMenuItem1});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Padding = new System.Windows.Forms.Padding(7, 0, 0, 0);
            this.MainMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.MainMenu.Size = new System.Drawing.Size(1115, 24);
            this.MainMenu.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New_MenuItem,
            this.Open_MenuItem,
            this.Save_MenuItem,
            this.SaveAs_MenuItem,
            this.Print_MenuItem,
            this.Exit_MenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // New_MenuItem
            // 
            this.New_MenuItem.Name = "New_MenuItem";
            this.New_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.New_MenuItem.Size = new System.Drawing.Size(155, 22);
            this.New_MenuItem.Text = "New";
            this.New_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // Open_MenuItem
            // 
            this.Open_MenuItem.Name = "Open_MenuItem";
            this.Open_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open_MenuItem.Size = new System.Drawing.Size(155, 22);
            this.Open_MenuItem.Text = "Open...";
            this.Open_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // Save_MenuItem
            // 
            this.Save_MenuItem.Name = "Save_MenuItem";
            this.Save_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save_MenuItem.Size = new System.Drawing.Size(155, 22);
            this.Save_MenuItem.Text = "Save";
            this.Save_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // SaveAs_MenuItem
            // 
            this.SaveAs_MenuItem.Name = "SaveAs_MenuItem";
            this.SaveAs_MenuItem.Size = new System.Drawing.Size(155, 22);
            this.SaveAs_MenuItem.Text = "Save As...";
            this.SaveAs_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // Print_MenuItem
            // 
            this.Print_MenuItem.Name = "Print_MenuItem";
            this.Print_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.Print_MenuItem.Size = new System.Drawing.Size(155, 22);
            this.Print_MenuItem.Text = "Print";
            this.Print_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // Exit_MenuItem
            // 
            this.Exit_MenuItem.Name = "Exit_MenuItem";
            this.Exit_MenuItem.Size = new System.Drawing.Size(155, 22);
            this.Exit_MenuItem.Text = "Exit";
            this.Exit_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Undo_MenuItem,
            this.Cut_MenuItem,
            this.Copy_MenuItem,
            this.Paste_MenuItem,
            this.Delete_MenuItem,
            this.SelectAll_MenuItem,
            this.DateAndTime_MenuItem,
            this.encodingToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // Undo_MenuItem
            // 
            this.Undo_MenuItem.Name = "Undo_MenuItem";
            this.Undo_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Undo_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Undo_MenuItem.Text = "Undo";
            this.Undo_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // Cut_MenuItem
            // 
            this.Cut_MenuItem.Name = "Cut_MenuItem";
            this.Cut_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.Cut_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Cut_MenuItem.Text = "Cut";
            this.Cut_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // Copy_MenuItem
            // 
            this.Copy_MenuItem.Name = "Copy_MenuItem";
            this.Copy_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Copy_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Copy_MenuItem.Text = "Copy";
            this.Copy_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // Paste_MenuItem
            // 
            this.Paste_MenuItem.Name = "Paste_MenuItem";
            this.Paste_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.Paste_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Paste_MenuItem.Text = "Paste";
            this.Paste_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // Delete_MenuItem
            // 
            this.Delete_MenuItem.Name = "Delete_MenuItem";
            this.Delete_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Delete_MenuItem.Text = "Delete";
            this.Delete_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // SelectAll_MenuItem
            // 
            this.SelectAll_MenuItem.Name = "SelectAll_MenuItem";
            this.SelectAll_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAll_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.SelectAll_MenuItem.Text = "Select All";
            this.SelectAll_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // DateAndTime_MenuItem
            // 
            this.DateAndTime_MenuItem.Name = "DateAndTime_MenuItem";
            this.DateAndTime_MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.DateAndTime_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.DateAndTime_MenuItem.Text = "Date/Time";
            this.DateAndTime_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // encodingToolStripMenuItem
            // 
            this.encodingToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UTF8_MenuItem,
            this.UTF16_MenuItem,
            this.UTF32_MenuItem,
            this.ASCII_MenuItem,
            this.ANSIEuro_MenuItem,
            this.ANSICyrillic_MenuItem});
            this.encodingToolStripMenuItem.Name = "encodingToolStripMenuItem";
            this.encodingToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.encodingToolStripMenuItem.Text = "Encoding";
            // 
            // UTF8_MenuItem
            // 
            this.UTF8_MenuItem.Name = "UTF8_MenuItem";
            this.UTF8_MenuItem.Size = new System.Drawing.Size(161, 22);
            this.UTF8_MenuItem.Text = "UTF-8";
            this.UTF8_MenuItem.Click += new System.EventHandler(this.EncodingMenu_Events_Click);
            // 
            // UTF16_MenuItem
            // 
            this.UTF16_MenuItem.Name = "UTF16_MenuItem";
            this.UTF16_MenuItem.Size = new System.Drawing.Size(161, 22);
            this.UTF16_MenuItem.Text = "UTF-16";
            this.UTF16_MenuItem.Click += new System.EventHandler(this.EncodingMenu_Events_Click);
            // 
            // UTF32_MenuItem
            // 
            this.UTF32_MenuItem.Name = "UTF32_MenuItem";
            this.UTF32_MenuItem.Size = new System.Drawing.Size(161, 22);
            this.UTF32_MenuItem.Text = "UTF-32";
            this.UTF32_MenuItem.Click += new System.EventHandler(this.EncodingMenu_Events_Click);
            // 
            // ASCII_MenuItem
            // 
            this.ASCII_MenuItem.Name = "ASCII_MenuItem";
            this.ASCII_MenuItem.Size = new System.Drawing.Size(161, 22);
            this.ASCII_MenuItem.Text = "ASCII";
            this.ASCII_MenuItem.Click += new System.EventHandler(this.EncodingMenu_Events_Click);
            // 
            // ANSIEuro_MenuItem
            // 
            this.ANSIEuro_MenuItem.Name = "ANSIEuro_MenuItem";
            this.ANSIEuro_MenuItem.Size = new System.Drawing.Size(161, 22);
            this.ANSIEuro_MenuItem.Text = "ANSI (European)";
            this.ANSIEuro_MenuItem.Click += new System.EventHandler(this.EncodingMenu_Events_Click);
            // 
            // ANSICyrillic_MenuItem
            // 
            this.ANSICyrillic_MenuItem.Name = "ANSICyrillic_MenuItem";
            this.ANSICyrillic_MenuItem.Size = new System.Drawing.Size(161, 22);
            this.ANSICyrillic_MenuItem.Text = "ANSI (Cyrillic)";
            this.ANSICyrillic_MenuItem.Click += new System.EventHandler(this.EncodingMenu_Events_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.WordWrap_MenuItem,
            this.fontToolStripMenuItem});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 24);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // WordWrap_MenuItem
            // 
            this.WordWrap_MenuItem.CheckOnClick = true;
            this.WordWrap_MenuItem.Name = "WordWrap_MenuItem";
            this.WordWrap_MenuItem.Size = new System.Drawing.Size(134, 22);
            this.WordWrap_MenuItem.Text = "Word Wrap";
            this.WordWrap_MenuItem.Click += new System.EventHandler(this.WordWrap_MenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.fontToolStripMenuItem.Text = "Font...";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.ChangeFont_MenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowStatusBar_MenuItem,
            this.Theme_MenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // ShowStatusBar_MenuItem
            // 
            this.ShowStatusBar_MenuItem.Checked = true;
            this.ShowStatusBar_MenuItem.CheckOnClick = true;
            this.ShowStatusBar_MenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ShowStatusBar_MenuItem.Name = "ShowStatusBar_MenuItem";
            this.ShowStatusBar_MenuItem.Size = new System.Drawing.Size(180, 22);
            this.ShowStatusBar_MenuItem.Text = "Status Bar";
            this.ShowStatusBar_MenuItem.Click += new System.EventHandler(this.ShowStatusBar_MenuItem_Click);
            // 
            // Theme_MenuItem
            // 
            this.Theme_MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.DefaultTheme_MenuItem,
            this.DarkTheme_MenuItem,
            this.BlueTheme_MenuItem});
            this.Theme_MenuItem.Name = "Theme_MenuItem";
            this.Theme_MenuItem.Size = new System.Drawing.Size(180, 22);
            this.Theme_MenuItem.Text = "Theme";
            // 
            // DefaultTheme_MenuItem
            // 
            this.DefaultTheme_MenuItem.Name = "DefaultTheme_MenuItem";
            this.DefaultTheme_MenuItem.Size = new System.Drawing.Size(180, 22);
            this.DefaultTheme_MenuItem.Tag = "0";
            this.DefaultTheme_MenuItem.Text = "Default";
            this.DefaultTheme_MenuItem.Click += new System.EventHandler(this.MenuTheme_Events_Click);
            // 
            // DarkTheme_MenuItem
            // 
            this.DarkTheme_MenuItem.Name = "DarkTheme_MenuItem";
            this.DarkTheme_MenuItem.Size = new System.Drawing.Size(180, 22);
            this.DarkTheme_MenuItem.Tag = "1";
            this.DarkTheme_MenuItem.Text = "Dark";
            this.DarkTheme_MenuItem.Click += new System.EventHandler(this.MenuTheme_Events_Click);
            // 
            // BlueTheme_MenuItem
            // 
            this.BlueTheme_MenuItem.Name = "BlueTheme_MenuItem";
            this.BlueTheme_MenuItem.Size = new System.Drawing.Size(180, 22);
            this.BlueTheme_MenuItem.Tag = "2";
            this.BlueTheme_MenuItem.Text = "Blue";
            this.BlueTheme_MenuItem.Click += new System.EventHandler(this.MenuTheme_Events_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowCMD_MenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // ShowCMD_MenuItem
            // 
            this.ShowCMD_MenuItem.Name = "ShowCMD_MenuItem";
            this.ShowCMD_MenuItem.Size = new System.Drawing.Size(250, 22);
            this.ShowCMD_MenuItem.Text = "Show Command Line Arguments";
            this.ShowCMD_MenuItem.Click += new System.EventHandler(this.DebugMenuItems_Events);
            // 
            // helpToolStripMenuItem1
            // 
            this.helpToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.About_MenuItem});
            this.helpToolStripMenuItem1.Name = "helpToolStripMenuItem1";
            this.helpToolStripMenuItem1.Size = new System.Drawing.Size(44, 24);
            this.helpToolStripMenuItem1.Text = "Help";
            // 
            // About_MenuItem
            // 
            this.About_MenuItem.Name = "About_MenuItem";
            this.About_MenuItem.Size = new System.Drawing.Size(137, 22);
            this.About_MenuItem.Text = "About SText";
            this.About_MenuItem.Click += new System.EventHandler(this.About_MenuItem_Click);
            // 
            // ContentViewer
            // 
            this.ContentViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContentViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentViewer.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ContentViewer.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ContentViewer.Location = new System.Drawing.Point(0, 0);
            this.ContentViewer.Margin = new System.Windows.Forms.Padding(4, 0, 0, 3);
            this.ContentViewer.MaxLength = 32767000;
            this.ContentViewer.Multiline = true;
            this.ContentViewer.Name = "ContentViewer";
            this.ContentViewer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ContentViewer.Size = new System.Drawing.Size(1115, 516);
            this.ContentViewer.TabIndex = 2;
            this.ContentViewer.WordWrap = false;
            this.ContentViewer.TextChanged += new System.EventHandler(this.ContentViewer_TextChanged);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.CheckFileExists = false;
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text Documents|*.txt|All Files|*.*";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "Text Documents|*.txt|All Files|*.*";
            this.saveFileDialog1.RestoreDirectory = true;
            // 
            // StatusBar
            // 
            this.StatusBar.AutoSize = false;
            this.StatusBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar_Theme,
            this.StatusBar_File,
            this.StatusBar_Encoding});
            this.StatusBar.Location = new System.Drawing.Point(0, 540);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.Size = new System.Drawing.Size(1115, 29);
            this.StatusBar.TabIndex = 3;
            // 
            // StatusBar_Theme
            // 
            this.StatusBar_Theme.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_Theme.Name = "StatusBar_Theme";
            this.StatusBar_Theme.Size = new System.Drawing.Size(46, 29);
            this.StatusBar_Theme.Text = "Theme:";
            // 
            // StatusBar_File
            // 
            this.StatusBar_File.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_File.Name = "StatusBar_File";
            this.StatusBar_File.Size = new System.Drawing.Size(28, 29);
            this.StatusBar_File.Text = "File:";
            // 
            // StatusBar_Encoding
            // 
            this.StatusBar_Encoding.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StatusBar_Encoding.Margin = new System.Windows.Forms.Padding(0);
            this.StatusBar_Encoding.Name = "StatusBar_Encoding";
            this.StatusBar_Encoding.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StatusBar_Encoding.Size = new System.Drawing.Size(60, 29);
            this.StatusBar_Encoding.Text = "Encoding:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ContentViewer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1115, 516);
            this.panel1.TabIndex = 4;
            // 
            // PrintDoc
            // 
            this.PrintDoc.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDoc_PrintPage);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1115, 569);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.MainMenu);
            this.Controls.Add(this.StatusBar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SText";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.TextBox ContentViewer;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem Theme_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem About_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DefaultTheme_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem DarkTheme_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem BlueTheme_MenuItem;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Theme;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_File;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Encoding;
        private System.Windows.Forms.ToolStripMenuItem encodingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem UTF8_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem UTF16_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ASCII_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ANSIEuro_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem UTF32_MenuItem;
        private System.Windows.Forms.ToolStripMenuItem ANSICyrillic_MenuItem;
        private ToolStripMenuItem debugToolStripMenuItem;
        private ToolStripMenuItem ShowCMD_MenuItem;
        private System.Drawing.Printing.PrintDocument PrintDoc;
    }
}

