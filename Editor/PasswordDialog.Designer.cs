namespace Editor
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
            this.label1 = new System.Windows.Forms.Label();
            this.passwordPanel = new System.Windows.Forms.Panel();
            this.Passwd = new System.Windows.Forms.TextBox();
            this.retypePasswordPanel = new System.Windows.Forms.Panel();
            this.RetyperPasswd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.OK = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.passwordPanel.SuspendLayout();
            this.retypePasswordPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Password:";
            // 
            // passwordPanel
            // 
            this.passwordPanel.Controls.Add(this.Passwd);
            this.passwordPanel.Controls.Add(this.label1);
            this.passwordPanel.Location = new System.Drawing.Point(12, 12);
            this.passwordPanel.Name = "passwordPanel";
            this.passwordPanel.Size = new System.Drawing.Size(344, 38);
            this.passwordPanel.TabIndex = 1;
            // 
            // Passwd
            // 
            this.Passwd.Location = new System.Drawing.Point(108, 7);
            this.Passwd.Name = "Passwd";
            this.Passwd.Size = new System.Drawing.Size(218, 23);
            this.Passwd.TabIndex = 0;
            this.Passwd.UseSystemPasswordChar = true;
            // 
            // retypePasswordPanel
            // 
            this.retypePasswordPanel.Controls.Add(this.RetyperPasswd);
            this.retypePasswordPanel.Controls.Add(this.label2);
            this.retypePasswordPanel.Location = new System.Drawing.Point(12, 56);
            this.retypePasswordPanel.Name = "retypePasswordPanel";
            this.retypePasswordPanel.Size = new System.Drawing.Size(344, 38);
            this.retypePasswordPanel.TabIndex = 1;
            // 
            // RetyperPasswd
            // 
            this.RetyperPasswd.Location = new System.Drawing.Point(108, 7);
            this.RetyperPasswd.Name = "RetyperPasswd";
            this.RetyperPasswd.Size = new System.Drawing.Size(218, 23);
            this.RetyperPasswd.TabIndex = 1;
            this.RetyperPasswd.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Retype password:";
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(200, 100);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(281, 100);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cancel.TabIndex = 3;
            this.Cancel.Text = "Cancel";
            this.Cancel.UseVisualStyleBackColor = true;
            // 
            // PasswordDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 136);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.OK);
            this.Controls.Add(this.retypePasswordPanel);
            this.Controls.Add(this.passwordPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PasswordDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Enter password";
            this.TopMost = true;
            this.passwordPanel.ResumeLayout(false);
            this.passwordPanel.PerformLayout();
            this.retypePasswordPanel.ResumeLayout(false);
            this.retypePasswordPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Panel passwordPanel;
        private TextBox Passwd;
        private Panel retypePasswordPanel;
        private TextBox RetyperPasswd;
        private Label label2;
        private Button OK;
        private Button Cancel;
    }
}