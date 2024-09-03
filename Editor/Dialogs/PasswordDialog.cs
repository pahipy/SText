using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SText.Dialogs
{
    public partial class PasswordDialog : Form
    {
        public PasswordDialog()
        {
            InitializeComponent();
        }

        public PasswordDialog(bool SetPasswordMode) : this()
        {
            setPasswordMode = SetPasswordMode;
            if (!SetPasswordMode)
            {
                retypePasswordPanel.Visible = false;
                Height -= retypePasswordPanel.Height;
            }
        }

        private bool setPasswordMode = true;

        public string Password
        {
            get => Passwd.Text;
        }

        private void Buttons_Click(object sender, EventArgs e)
        {
            string name = ((Button)sender).Name;

            switch (name)
            {
                case "OK":
                    {
                        OKAndClose();
                        break;
                    }

                case "Cancel":
                    {
                        CancelAndClose();
                        break;
                    }
            }

        }

        private void OKAndClose()
        {
            if (setPasswordMode)
            {
                if (Passwd.Text != RetyperPasswd.Text)
                {
                    DialogManager.ShowWarningDialogWithText("Fields don't match!");
                    return;
                }
            }

            if (Passwd.Text.Length < 4)
            {
                DialogManager.ShowWarningDialogWithText("Password must contain not less than 4 symbols");
                return;
            }

            if (ContainsSpaces(Passwd.Text))
            {
                DialogManager.ShowWarningDialogWithText("Password can't contain spaces");
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelAndClose()
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void PasswordDialog_Shown(object sender, EventArgs e)
        {
            Passwd.Text = "";
            RetyperPasswd.Text = "";
            BackColor = Conf.ThemeSelector.CurrentColorSchema.ControlColor;
            ForeColor = Conf.ThemeSelector.CurrentColorSchema.ControlFontColor;
            Passwd.BackColor = Conf.ThemeSelector.CurrentColorSchema.TextFieldColor;
            Passwd.ForeColor = Conf.ThemeSelector.CurrentColorSchema.TextFieldFontColor;
            RetyperPasswd.BackColor = Conf.ThemeSelector.CurrentColorSchema.TextFieldColor;
            RetyperPasswd.ForeColor = Conf.ThemeSelector.CurrentColorSchema.TextFieldFontColor;
            BottomPanel.BackColor = Conf.ThemeSelector.CurrentColorSchema.ToolPanelColor;
            foreach (var c in BottomPanel.Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.BackColor = Conf.ThemeSelector.CurrentColorSchema.ButtonColor;
                    b.ForeColor = Conf.ThemeSelector.CurrentColorSchema.ButtonFontColor;
                }
            }

            Passwd.Focus();
        }

        private void PasswordDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                OKAndClose();

            if (e.KeyCode == Keys.Escape)
                CancelAndClose();
        }

        private bool ContainsSpaces(string str)
        {
            foreach (char c in str)
                if (c == ' ' || c == 160)
                    return true;

            return false;
        }

    }
}
