namespace SText.Dialogs
{
    partial class AboutDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Content = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AdditionalContent = new System.Windows.Forms.Label();
            this.ForkMe = new System.Windows.Forms.Label();
            this.Picture = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).BeginInit();
            this.SuspendLayout();
            // 
            // Content
            // 
            this.Content.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Content.Location = new System.Drawing.Point(94, 11);
            this.Content.Name = "Content";
            this.Content.Size = new System.Drawing.Size(292, 57);
            this.Content.TabIndex = 1;
            this.Content.Text = "Here is a content";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Author.ForeColor = System.Drawing.Color.Black;
            this.Author.Location = new System.Drawing.Point(14, 100);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(94, 25);
            this.Author.TabIndex = 2;
            this.Author.Text = "by pahipy";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.VersionLabel);
            this.panel1.Controls.Add(this.AdditionalContent);
            this.panel1.Controls.Add(this.Author);
            this.panel1.Controls.Add(this.ForkMe);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.panel1.Location = new System.Drawing.Point(0, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(398, 132);
            this.panel1.TabIndex = 3;
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(344, 108);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(51, 17);
            this.VersionLabel.TabIndex = 6;
            this.VersionLabel.Text = "Version";
            // 
            // AdditionalContent
            // 
            this.AdditionalContent.Location = new System.Drawing.Point(14, 14);
            this.AdditionalContent.Name = "AdditionalContent";
            this.AdditionalContent.Size = new System.Drawing.Size(242, 86);
            this.AdditionalContent.TabIndex = 5;
            this.AdditionalContent.Text = "This app was created to be created. If you do not know how to close this window, " +
    "press escape.";
            // 
            // ForkMe
            // 
            this.ForkMe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ForkMe.BackColor = System.Drawing.Color.Transparent;
            this.ForkMe.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForkMe.Image = global::Dialogs.Resource.forkme_light_background;
            this.ForkMe.Location = new System.Drawing.Point(263, 1);
            this.ForkMe.Name = "ForkMe";
            this.ForkMe.Size = new System.Drawing.Size(136, 132);
            this.ForkMe.TabIndex = 4;
            this.ForkMe.Click += new System.EventHandler(this.ForkMe_Click);
            // 
            // Picture
            // 
            this.Picture.Image = global::Editor.Resource.STextIcon_Big;
            this.Picture.Location = new System.Drawing.Point(12, 6);
            this.Picture.Name = "Picture";
            this.Picture.Size = new System.Drawing.Size(64, 64);
            this.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Picture.TabIndex = 4;
            this.Picture.TabStop = false;
            // 
            // AboutDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(398, 208);
            this.Controls.Add(this.Picture);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Content);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "AboutDialog";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AboutDialog_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Picture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Content;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Panel panel1;
        private Label ForkMe;
        private Label AdditionalContent;
        private PictureBox Picture;
        private Label VersionLabel;
    }
}