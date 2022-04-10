using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SText.Conf;

namespace SText.Dialogs
{
    public partial class SaveDialog : Form
    {
        public SaveDialog(string fname)
        {
            InitializeComponent();
            this.Text = ProgramSets.ProgramName;

            Message.Text += " " + (File.Exists(fname) ? new FileInfo(fname).Name : fname) + "?";
            inputFileName = fname;
            ApplyTheme();
        }

        public SaveDialog(string fname, SaveFileDialog dialog) : this(fname)
        {
            fileDialog = dialog;
        }

        private SaveFileDialog fileDialog = null;
        private string inputFileName;
        public string FileName
        {
            get => fileDialog != null ? fileDialog.FileName : inputFileName;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var item = (Button)sender;

            switch (item.Name)
            {
                case "SaveButton":
                    {
                        if (fileDialog != null && !File.Exists(inputFileName))
                        {
                            this.Hide();
                            DialogResult = fileDialog.ShowDialog();

                            if (DialogResult == DialogResult.OK && !File.Exists(fileDialog.FileName))
                                File.Create(fileDialog.FileName).Close();

                        }
                        else
                            DialogResult = DialogResult.OK;
                        break;
                    }

                case "DontSaveButton":
                    {
                        DialogResult = DialogResult.Abort;
                        break;
                    }

                case "CancelButton":
                    {
                        DialogResult = DialogResult.Cancel;
                        break;
                    }
            }
            Close();

        }

        private void ApplyTheme()
        {
            this.BackColor = ThemeSelector.CurrentColorSchema.ControlColor;
            Message.ForeColor = ThemeSelector.CurrentColorSchema.ControlFontColor;
            panel1.BackColor = ThemeSelector.CurrentColorSchema.ToolPanelColor;

            foreach (Button b in panel1.Controls)
            {
                b.BackColor = ThemeSelector.CurrentColorSchema.ButtonColor;
                b.ForeColor = ThemeSelector.CurrentColorSchema.ButtonFontColor;
            }

            Theme theme = ThemeSelector.CurrentTheme;

            if (theme == Theme.Default || theme == Theme.Blue)
            {
                Message.ForeColor = Color.FromArgb(0, 59, 209);
            }

            if (theme == Theme.Dark)
            {
                ContentIcon.Image = global::Dialogs.Resource.help_circle_white;
            }

        }

        private void SaveDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                DialogResult = DialogResult.Cancel;
                Close();
            }
        }
    }
}
