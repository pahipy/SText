using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SText.Editor;

namespace SText.Dialogs
{
    public partial class AboutDialog : Form
    {
        public AboutDialog()
        {
            InitializeComponent();
            this.Text = $"About {ProgramSets.ProgramName}";
            Content.Text = $"{ProgramSets.ProgramName} is a simple text editor.";
            ApplyTheme();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyTheme()
        {
            foreach (var c in panel1.Controls)
            {
                if (c is Button)
                {
                    Button b = (Button)c;
                    b.BackColor = ThemeSelector.CurrentColorSchema.ButtonColor;
                    b.ForeColor = ThemeSelector.CurrentColorSchema.ButtonFontColor;
                }
            }

            switch (ThemeSelector.CurrentTheme)
            {
                case Theme.Default:
                    {

                        return;
                    }

                case Theme.Dark:
                    {
                        this.BackColor = ThemeSelector.CurrentColorSchema.ControlColor;
                        Content.ForeColor = Color.FromArgb(235, 235, 235);
                        AdditionalContent.ForeColor = Color.FromArgb(235, 235, 235);
                        Author.ForeColor = Color.FromArgb(235, 235, 235);
                        panel1.BackColor = ThemeSelector.CurrentColorSchema.ToolPanelColor;

                        
                        return;
                    }

                case Theme.Blue:
                    {

                        return;
                    }
            }
        }

        private void AboutDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }

        private void ForkMe_Click(object sender, EventArgs e)
        { 
            
            try
            {
                var uri = ProgramSets.GitHubLink;
                var psi = new System.Diagnostics.ProcessStartInfo();
                psi.UseShellExecute = true;
                psi.FileName = uri;
                System.Diagnostics.Process.Start(psi);
            }
            catch { }
        }
    }
}
