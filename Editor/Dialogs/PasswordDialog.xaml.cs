using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

            this.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Escape)
                    CancelAndClose();

                if (e.Key == Key.Enter && IsCorrectPassword)
                    OKAndClose();
            };

            this.Passwd.PasswordChanged += (s, e) => OK.IsEnabled = IsCorrectPassword;
            this.RetypedPasswd.PasswordChanged += (s, e) => OK.IsEnabled = IsCorrectPassword;

            this.Activated += (s, e) => Passwd.Focus();
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

        private const int MinimumPasswordLength = 4;
        private bool setPasswordMode = true;
        private SDialogResult sDialogResult = SDialogResult.Cancel;
        public SDialogResult SDialogResult { get => sDialogResult; }
        private bool IsCorrectPassword
        {
            get => Password == RetypedPasswd.Password && !ContainsSpaces(Password)
                && Password.Length >= MinimumPasswordLength || !setPasswordMode;
        }

        public string Password
        {
            get => Passwd.Password;
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
