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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.New_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Open_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Save_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAs_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Print_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Exit_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Undo_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cut_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Copy_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Paste_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Delete_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAll_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DateAndTime_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.ShowCMD_DebugMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowSetPasswordDialog_DebugMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ShowOpenPasswordDialog_DebugMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.About_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentViewer = new System.Windows.Forms.TextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.StatusBar = new System.Windows.Forms.ToolStrip();
            this.StatusBar_Theme = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_File = new System.Windows.Forms.ToolStripStatusLabel();
            this.EncodingMenuButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.DropDownEncodingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.UTF8_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UTF16_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UTF32_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ASCII_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ANSIEuro_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ANSICyrillic_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KOI8R_MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PrintDoc = new System.Drawing.Printing.PrintDocument();
            this.ContentViewer_ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContentViewer_ContextMenu_Undo = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentViewer_ContextMenu_Separator0 = new System.Windows.Forms.ToolStripSeparator();
            this.ContentViewer_ContextMenu_Cut = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentViewer_ContextMenu_Copy = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentViewer_ContextMenu_Paste = new System.Windows.Forms.ToolStripMenuItem();
            this.ContentViewer_ContextMenu_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContentViewer_ContextMenu_SelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.DropDownEncodingMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ContentViewer_ContextMenu.SuspendLayout();
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
            this.toolStripSeparator1,
            this.Print_MenuItem,
            this.toolStripSeparator2,
            this.Exit_MenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // New_MenuItem
            // 
            this.New_MenuItem.Name = "New_MenuItem";
            this.New_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.New_MenuItem.Size = new System.Drawing.Size(195, 22);
            this.New_MenuItem.Text = "New";
            this.New_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // Open_MenuItem
            // 
            this.Open_MenuItem.Name = "Open_MenuItem";
            this.Open_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.Open_MenuItem.Size = new System.Drawing.Size(195, 22);
            this.Open_MenuItem.Text = "Open...";
            this.Open_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // Save_MenuItem
            // 
            this.Save_MenuItem.Name = "Save_MenuItem";
            this.Save_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.Save_MenuItem.Size = new System.Drawing.Size(195, 22);
            this.Save_MenuItem.Text = "Save";
            this.Save_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // SaveAs_MenuItem
            // 
            this.SaveAs_MenuItem.Name = "SaveAs_MenuItem";
            this.SaveAs_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.SaveAs_MenuItem.Size = new System.Drawing.Size(195, 22);
            this.SaveAs_MenuItem.Text = "Save As...";
            this.SaveAs_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(192, 6);
            // 
            // Print_MenuItem
            // 
            this.Print_MenuItem.Name = "Print_MenuItem";
            this.Print_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.P)));
            this.Print_MenuItem.Size = new System.Drawing.Size(195, 22);
            this.Print_MenuItem.Text = "Print";
            this.Print_MenuItem.Click += new System.EventHandler(this.MenuFile_Events_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // Exit_MenuItem
            // 
            this.Exit_MenuItem.Name = "Exit_MenuItem";
            this.Exit_MenuItem.Size = new System.Drawing.Size(195, 22);
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
            this.DateAndTime_MenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // Undo_MenuItem
            // 
            this.Undo_MenuItem.Name = "Undo_MenuItem";
            this.Undo_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.Undo_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Undo_MenuItem.Tag = "undo";
            this.Undo_MenuItem.Text = "Undo";
            this.Undo_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // Cut_MenuItem
            // 
            this.Cut_MenuItem.Name = "Cut_MenuItem";
            this.Cut_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.Cut_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Cut_MenuItem.Tag = "cut";
            this.Cut_MenuItem.Text = "Cut";
            this.Cut_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // Copy_MenuItem
            // 
            this.Copy_MenuItem.Name = "Copy_MenuItem";
            this.Copy_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.Copy_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Copy_MenuItem.Tag = "copy";
            this.Copy_MenuItem.Text = "Copy";
            this.Copy_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // Paste_MenuItem
            // 
            this.Paste_MenuItem.Name = "Paste_MenuItem";
            this.Paste_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.Paste_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Paste_MenuItem.Tag = "paste";
            this.Paste_MenuItem.Text = "Paste";
            this.Paste_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // Delete_MenuItem
            // 
            this.Delete_MenuItem.Name = "Delete_MenuItem";
            this.Delete_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.Delete_MenuItem.Tag = "delete";
            this.Delete_MenuItem.Text = "Delete";
            this.Delete_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // SelectAll_MenuItem
            // 
            this.SelectAll_MenuItem.Name = "SelectAll_MenuItem";
            this.SelectAll_MenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.SelectAll_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.SelectAll_MenuItem.Tag = "selectAll";
            this.SelectAll_MenuItem.Text = "Select All";
            this.SelectAll_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // DateAndTime_MenuItem
            // 
            this.DateAndTime_MenuItem.Name = "DateAndTime_MenuItem";
            this.DateAndTime_MenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.DateAndTime_MenuItem.Size = new System.Drawing.Size(164, 22);
            this.DateAndTime_MenuItem.Tag = "dateAndTime";
            this.DateAndTime_MenuItem.Text = "Date/Time";
            this.DateAndTime_MenuItem.Click += new System.EventHandler(this.MenuEdit_Events_Click);
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
            this.ShowStatusBar_MenuItem.Size = new System.Drawing.Size(126, 22);
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
            this.Theme_MenuItem.Size = new System.Drawing.Size(126, 22);
            this.Theme_MenuItem.Text = "Theme";
            // 
            // DefaultTheme_MenuItem
            // 
            this.DefaultTheme_MenuItem.Name = "DefaultTheme_MenuItem";
            this.DefaultTheme_MenuItem.Size = new System.Drawing.Size(112, 22);
            this.DefaultTheme_MenuItem.Tag = "0";
            this.DefaultTheme_MenuItem.Text = "Default";
            this.DefaultTheme_MenuItem.Click += new System.EventHandler(this.MenuTheme_Events_Click);
            // 
            // DarkTheme_MenuItem
            // 
            this.DarkTheme_MenuItem.Name = "DarkTheme_MenuItem";
            this.DarkTheme_MenuItem.Size = new System.Drawing.Size(112, 22);
            this.DarkTheme_MenuItem.Tag = "1";
            this.DarkTheme_MenuItem.Text = "Dark";
            this.DarkTheme_MenuItem.Click += new System.EventHandler(this.MenuTheme_Events_Click);
            // 
            // BlueTheme_MenuItem
            // 
            this.BlueTheme_MenuItem.Name = "BlueTheme_MenuItem";
            this.BlueTheme_MenuItem.Size = new System.Drawing.Size(112, 22);
            this.BlueTheme_MenuItem.Tag = "2";
            this.BlueTheme_MenuItem.Text = "Blue";
            this.BlueTheme_MenuItem.Click += new System.EventHandler(this.MenuTheme_Events_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowCMD_DebugMenuItem,
            this.ShowSetPasswordDialog_DebugMenuItem,
            this.ShowOpenPasswordDialog_DebugMenuItem});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // ShowCMD_DebugMenuItem
            // 
            this.ShowCMD_DebugMenuItem.Name = "ShowCMD_DebugMenuItem";
            this.ShowCMD_DebugMenuItem.Size = new System.Drawing.Size(250, 22);
            this.ShowCMD_DebugMenuItem.Text = "Show Command Line Arguments";
            this.ShowCMD_DebugMenuItem.Click += new System.EventHandler(this.DebugMenuItems_Events);
            // 
            // ShowSetPasswordDialog_DebugMenuItem
            // 
            this.ShowSetPasswordDialog_DebugMenuItem.Name = "ShowSetPasswordDialog_DebugMenuItem";
            this.ShowSetPasswordDialog_DebugMenuItem.Size = new System.Drawing.Size(250, 22);
            this.ShowSetPasswordDialog_DebugMenuItem.Text = "Show SetPasswordDialog";
            this.ShowSetPasswordDialog_DebugMenuItem.Click += new System.EventHandler(this.DebugMenuItems_Events);
            // 
            // ShowOpenPasswordDialog_DebugMenuItem
            // 
            this.ShowOpenPasswordDialog_DebugMenuItem.Name = "ShowOpenPasswordDialog_DebugMenuItem";
            this.ShowOpenPasswordDialog_DebugMenuItem.Size = new System.Drawing.Size(250, 22);
            this.ShowOpenPasswordDialog_DebugMenuItem.Text = "Show OpenPasswordDialog";
            this.ShowOpenPasswordDialog_DebugMenuItem.Click += new System.EventHandler(this.DebugMenuItems_Events);
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
            this.ContentViewer.AcceptsTab = true;
            this.ContentViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContentViewer.ContextMenuStrip = this.ContentViewer_ContextMenu;
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
            // openFileDialog
            // 
            this.openFileDialog.CheckFileExists = false;
            this.openFileDialog.Filter = "Text Documents|*.txt|SText Documents|*.txts|All Files|*.*";
            this.openFileDialog.RestoreDirectory = true;
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "Text Documents|*.txt|SText Documents|*.txts|All Files|*.*";
            this.saveFileDialog.RestoreDirectory = true;
            // 
            // StatusBar
            // 
            this.StatusBar.AutoSize = false;
            this.StatusBar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.StatusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StatusBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.StatusBar.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar_Theme,
            this.StatusBar_File,
            this.EncodingMenuButton});
            this.StatusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.StatusBar.Location = new System.Drawing.Point(0, 540);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.StatusBar.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
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
            // EncodingMenuButton
            // 
            this.EncodingMenuButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.EncodingMenuButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.EncodingMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.EncodingMenuButton.DropDown = this.DropDownEncodingMenu;
            this.EncodingMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EncodingMenuButton.Margin = new System.Windows.Forms.Padding(0);
            this.EncodingMenuButton.Name = "EncodingMenuButton";
            this.EncodingMenuButton.Size = new System.Drawing.Size(70, 29);
            this.EncodingMenuButton.Text = "Encoding";
            this.EncodingMenuButton.ToolTipText = "Encoding";
            // 
            // DropDownEncodingMenu
            // 
            this.DropDownEncodingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UTF8_MenuItem,
            this.UTF16_MenuItem,
            this.UTF32_MenuItem,
            this.ASCII_MenuItem,
            this.ANSIEuro_MenuItem,
            this.ANSICyrillic_MenuItem,
            this.KOI8R_MenuItem});
            this.DropDownEncodingMenu.Name = "DropDownEncodingMenu";
            this.DropDownEncodingMenu.OwnerItem = this.EncodingMenuButton;
            this.DropDownEncodingMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.DropDownEncodingMenu.Size = new System.Drawing.Size(162, 158);
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
            // KOI8R_MenuItem
            // 
            this.KOI8R_MenuItem.Name = "KOI8R_MenuItem";
            this.KOI8R_MenuItem.Size = new System.Drawing.Size(161, 22);
            this.KOI8R_MenuItem.Text = "KOI8 R";
            this.KOI8R_MenuItem.Click += new System.EventHandler(this.EncodingMenu_Events_Click);
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
            // ContentViewer_ContextMenu
            // 
            this.ContentViewer_ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContentViewer_ContextMenu_Undo,
            this.ContentViewer_ContextMenu_Separator0,
            this.ContentViewer_ContextMenu_Cut,
            this.ContentViewer_ContextMenu_Copy,
            this.ContentViewer_ContextMenu_Paste,
            this.ContentViewer_ContextMenu_Separator1,
            this.ContentViewer_ContextMenu_SelectAll});
            this.ContentViewer_ContextMenu.Name = "ContentViewer_ContextMenu";
            this.ContentViewer_ContextMenu.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.ContentViewer_ContextMenu.Size = new System.Drawing.Size(123, 126);
            // 
            // ContentViewer_ContextMenu_Undo
            // 
            this.ContentViewer_ContextMenu_Undo.Name = "ContentViewer_ContextMenu_Undo";
            this.ContentViewer_ContextMenu_Undo.Size = new System.Drawing.Size(122, 22);
            this.ContentViewer_ContextMenu_Undo.Tag = "undo";
            this.ContentViewer_ContextMenu_Undo.Text = "Undo";
            this.ContentViewer_ContextMenu_Undo.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // ContentViewer_ContextMenu_Separator0
            // 
            this.ContentViewer_ContextMenu_Separator0.Name = "ContentViewer_ContextMenu_Separator0";
            this.ContentViewer_ContextMenu_Separator0.Size = new System.Drawing.Size(119, 6);
            // 
            // ContentViewer_ContextMenu_Cut
            // 
            this.ContentViewer_ContextMenu_Cut.Name = "ContentViewer_ContextMenu_Cut";
            this.ContentViewer_ContextMenu_Cut.Size = new System.Drawing.Size(122, 22);
            this.ContentViewer_ContextMenu_Cut.Tag = "cut";
            this.ContentViewer_ContextMenu_Cut.Text = "Cut";
            this.ContentViewer_ContextMenu_Cut.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // ContentViewer_ContextMenu_Copy
            // 
            this.ContentViewer_ContextMenu_Copy.Name = "ContentViewer_ContextMenu_Copy";
            this.ContentViewer_ContextMenu_Copy.Size = new System.Drawing.Size(122, 22);
            this.ContentViewer_ContextMenu_Copy.Tag = "copy";
            this.ContentViewer_ContextMenu_Copy.Text = "Copy";
            this.ContentViewer_ContextMenu_Copy.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // ContentViewer_ContextMenu_Paste
            // 
            this.ContentViewer_ContextMenu_Paste.Name = "ContentViewer_ContextMenu_Paste";
            this.ContentViewer_ContextMenu_Paste.Size = new System.Drawing.Size(122, 22);
            this.ContentViewer_ContextMenu_Paste.Tag = "paste";
            this.ContentViewer_ContextMenu_Paste.Text = "Paste";
            this.ContentViewer_ContextMenu_Paste.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // ContentViewer_ContextMenu_Separator1
            // 
            this.ContentViewer_ContextMenu_Separator1.Name = "ContentViewer_ContextMenu_Separator1";
            this.ContentViewer_ContextMenu_Separator1.Size = new System.Drawing.Size(119, 6);
            // 
            // ContentViewer_ContextMenu_SelectAll
            // 
            this.ContentViewer_ContextMenu_SelectAll.Name = "ContentViewer_ContextMenu_SelectAll";
            this.ContentViewer_ContextMenu_SelectAll.Size = new System.Drawing.Size(122, 22);
            this.ContentViewer_ContextMenu_SelectAll.Tag = "selectAll";
            this.ContentViewer_ContextMenu_SelectAll.Text = "Select All";
            this.ContentViewer_ContextMenu_SelectAll.Click += new System.EventHandler(this.MenuEdit_Events_Click);
            // 
            // MainForm
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
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SText";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.DropDownEncodingMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ContentViewer_ContextMenu.ResumeLayout(false);
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
        private System.Windows.Forms.Panel panel1;
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
        private ContextMenuStrip ContentViewer_ContextMenu;
        private ToolStripMenuItem ContentViewer_ContextMenu_Undo;
        private ToolStripSeparator ContentViewer_ContextMenu_Separator0;
        private ToolStripMenuItem ContentViewer_ContextMenu_Cut;
        private ToolStripMenuItem ContentViewer_ContextMenu_Copy;
        private ToolStripMenuItem ContentViewer_ContextMenu_Paste;
        private ToolStripSeparator ContentViewer_ContextMenu_Separator1;
        private ToolStripMenuItem ContentViewer_ContextMenu_SelectAll;
    }
}

