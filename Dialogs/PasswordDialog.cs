using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SText.Editor
{
    public partial class PasswordDialog : Form
    {
        public PasswordDialog()
        {
            InitializeComponent();
        }

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
                        DialogResult = DialogResult.OK;
                        break;
                    }

                case "Cancel":
                    {
                        DialogResult= DialogResult.Cancel;
                        break;
                    }
            }

            Close();
        }


    }
}
