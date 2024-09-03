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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutDialog));
            Content = new Label();
            Author = new Label();
            panel1 = new Panel();
            LicenseLable = new Label();
            ForkMe = new PictureBox();
            VersionLabel = new Label();
            AdditionalContent = new Label();
            Picture = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ForkMe).BeginInit();
            ((System.ComponentModel.ISupportInitialize)Picture).BeginInit();
            SuspendLayout();
            // 
            // Content
            // 
            Content.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Content.Location = new Point(94, 11);
            Content.Name = "Content";
            Content.Size = new Size(292, 57);
            Content.TabIndex = 1;
            Content.Text = "Here is a content";
            // 
            // Author
            // 
            Author.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            Author.AutoSize = true;
            Author.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            Author.ForeColor = Color.Black;
            Author.Location = new Point(12, 110);
            Author.Name = "Author";
            Author.Size = new Size(94, 25);
            Author.TabIndex = 2;
            Author.Text = "by pahipy";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(228, 244, 255);
            panel1.Controls.Add(LicenseLable);
            panel1.Controls.Add(ForkMe);
            panel1.Controls.Add(VersionLabel);
            panel1.Controls.Add(AdditionalContent);
            panel1.Controls.Add(Author);
            panel1.Dock = DockStyle.Bottom;
            panel1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            panel1.Location = new Point(0, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(460, 144);
            panel1.TabIndex = 3;
            // 
            // LicenseLable
            // 
            LicenseLable.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            LicenseLable.AutoSize = true;
            LicenseLable.Location = new Point(14, 84);
            LicenseLable.Name = "LicenseLable";
            LicenseLable.Size = new Size(79, 17);
            LicenseLable.TabIndex = 8;
            LicenseLable.Text = "License: MIT";
            // 
            // ForkMe
            // 
            ForkMe.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            ForkMe.BackgroundImage = (Image)resources.GetObject("ForkMe.BackgroundImage");
            ForkMe.BackgroundImageLayout = ImageLayout.Zoom;
            ForkMe.Cursor = Cursors.Hand;
            ForkMe.Location = new Point(391, 69);
            ForkMe.Name = "ForkMe";
            ForkMe.Size = new Size(67, 72);
            ForkMe.TabIndex = 7;
            ForkMe.TabStop = false;
            ForkMe.Click += ForkMe_Click;
            // 
            // VersionLabel
            // 
            VersionLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            VersionLabel.AutoSize = true;
            VersionLabel.Location = new Point(14, 63);
            VersionLabel.Name = "VersionLabel";
            VersionLabel.Size = new Size(51, 17);
            VersionLabel.TabIndex = 6;
            VersionLabel.Text = "Version";
            // 
            // AdditionalContent
            // 
            AdditionalContent.Location = new Point(14, 7);
            AdditionalContent.Name = "AdditionalContent";
            AdditionalContent.Size = new Size(372, 41);
            AdditionalContent.TabIndex = 5;
            AdditionalContent.Text = "This app was created to be created. If you do not know how to close this window, press escape.";
            // 
            // Picture
            // 
            Picture.BackgroundImage = Resource.STextIcon_Big;
            Picture.BackgroundImageLayout = ImageLayout.Zoom;
            Picture.Location = new Point(12, 6);
            Picture.Name = "Picture";
            Picture.Size = new Size(64, 64);
            Picture.SizeMode = PictureBoxSizeMode.Zoom;
            Picture.TabIndex = 4;
            Picture.TabStop = false;
            // 
            // AboutDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(460, 220);
            Controls.Add(Picture);
            Controls.Add(panel1);
            Controls.Add(Content);
            Font = new Font("Lucida Sans Unicode", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutDialog";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "AboutDialog";
            TopMost = true;
            KeyDown += AboutDialog_KeyDown;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ForkMe).EndInit();
            ((System.ComponentModel.ISupportInitialize)Picture).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label Content;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Panel panel1;
        private Label AdditionalContent;
        private PictureBox Picture;
        private Label VersionLabel;
        private PictureBox ForkMe;
        private Label LicenseLable;
    }
}