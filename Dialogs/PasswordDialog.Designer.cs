namespace SText.Dialogs
{
    partial class PasswordDialog
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
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.Passwd = new System.Windows.Forms.TextBox();
            this.retypePasswordPanel = new System.Windows.Forms.Panel();
            this.RetyperPasswd = new System.Windows.Forms.TextBox();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.BottomPanel = new System.Windows.Forms.Panel();
            this.passwordPanel.SuspendLayout();
            this.retypePasswordPanel.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // passwordPanel
            // 
            this.passwordPanel.Controls.Add(this.Passwd);
            this.passwordPanel.Location = new System.Drawing.Point(14, 13);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(253, 41);
            this.passwordPanel.TabIndex = 0;
            // 
            // Passwd
            // 
            this.Passwd.BackColor = System.Drawing.Color.White;
            this.Passwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Passwd.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Passwd.Location = new System.Drawing.Point(3, 3);
            this.Passwd.Name = "Passwd";
            this.Passwd.PlaceholderText = "Password";
            this.Passwd.Size = new System.Drawing.Size(249, 27);
            this.Passwd.TabIndex = 0;
            this.Passwd.UseSystemPasswordChar = true;
            this.Passwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordDialog_KeyDown);
            // 
            // retypePasswordPanel
            // 
            this.retypePasswordPanel.Controls.Add(this.RetyperPasswd);
            this.retypePasswordPanel.Location = new System.Drawing.Point(14, 60);
            this.retypePasswordPanel.Name = "retypePasswordPanel";
            this.retypePasswordPanel.Size = new System.Drawing.Size(253, 41);
            this.retypePasswordPanel.TabIndex = 1;
            // 
            // RetyperPasswd
            // 
            this.RetyperPasswd.BackColor = System.Drawing.Color.White;
            this.RetyperPasswd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RetyperPasswd.Location = new System.Drawing.Point(3, 3);
            this.RetyperPasswd.Name = "RetyperPasswd";
            this.RetyperPasswd.PlaceholderText = "Retype password";
            this.RetyperPasswd.Size = new System.Drawing.Size(249, 27);
            this.RetyperPasswd.TabIndex = 1;
            this.RetyperPasswd.UseSystemPasswordChar = true;
            this.RetyperPasswd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordDialog_KeyDown);
            // 
            // OK
            // 
            this.OK.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(163)))), ((int)(((byte)(230)))));
            this.OK.FlatAppearance.BorderSize = 0;
            this.OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OK.Location = new System.Drawing.Point(87, 18);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(86, 25);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = false;
            this.OK.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // Cancel
            // 
            this.Cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(118)))), ((int)(((byte)(163)))), ((int)(((byte)(230)))));
            this.Cancel.FlatAppearance.BorderSize = 0;
            this.Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cancel.Location = new System.Drawing.Point(180, 18);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(86, 25);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = false;
            this.Cancel.Click += new System.EventHandler(this.Buttons_Click);
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(244)))), ((int)(((byte)(255)))));
            this.BottomPanel.Controls.Add(this.Cancel);
            this.BottomPanel.Controls.Add(this.OK);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(0, 106);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(287, 62);
            this.BottomPanel.TabIndex = 2;
            // 
            // PasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(287, 168);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.retypePasswordPanel);
            this.Controls.Add(this.passwordPanel);
            this.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter password";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.PasswordDialog_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordDialog_KeyDown);
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            this.retypePasswordPanel.ResumeLayout(false);
            this.retypePasswordPanel.PerformLayout();
            this.BottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Panel passwordPanel;
        private TextBox Passwd;
        private Panel retypePasswordPanel;
        private TextBox RetyperPasswd;
        private Button OK;
        private Button Cancel;
        private Panel BottomPanel;
    }
}