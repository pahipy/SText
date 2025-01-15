using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wpf.Ui.Controls;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Button = Wpf.Ui.Controls.Button;

namespace SText.Dialogs
{
    /// <summary>
    /// Interaction logic for PasswordDialog.xaml
    /// </summary>
    public partial class PasswordDialog : FluentWindow
    {
        public PasswordDialog(FluentWindow Owner)
        {
            InitializeComponent();
            this.Owner = Owner;
            Passwd.Text = "";
            RetypedPasswd.Text = "";
        }

        public PasswordDialog(FluentWindow Owner, bool SetPasswordMode) : this(Owner)
        {
            setPasswordMode = SetPasswordMode;
            if (!SetPasswordMode)
            {
                RetypedPasswd.Visibility = Visibility.Hidden;
                Height -= RetypedPasswd.Height;
            }
        }

        private bool setPasswordMode = true;
        private SDialogResult sDialogResult = SDialogResult.Cancel;
        public SDialogResult SDialogResult { get => sDialogResult; }

        public string Password
        {
            get => Passwd.Text;
        }
        public SDialogResult ShowSDialog()
        {
            this.ShowDialog();
            return this.SDialogResult;
        }

        private void Buttons_Click(object sender, RoutedEventArgs e)
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
                if (Passwd.Text != RetypedPasswd.Text)
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
                DialogManager.ShowWarningDialogWithText("Password shouldn't contain spaces");
                return;
            }

            sDialogResult = SDialogResult.OK;
            Close();
        }

        private void CancelAndClose()
        {
            sDialogResult = SDialogResult.Cancel;
            Close();
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
