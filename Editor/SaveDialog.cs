﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using SText.Editor;

namespace SText.Dialogs
{
    public partial class SaveDialog : Form
    {
        public SaveDialog(string fname)
        {
            InitializeComponent();
            this.Text = ProgramSets.ProgramName;

            label1.Text += " " + (File.Exists(fname) ? new FileInfo(fname).Name : fname) + "?";
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
            switch (ThemeSelector.CurrentTheme)
            {
                case Theme.Default:
                    {

                        return;
                    }

                case Theme.Dark:
                    {
                        this.BackColor = Color.FromArgb(52, 52, 52);
                        label1.ForeColor = Color.FromArgb(235, 235, 235);
                        panel1.BackColor = Color.FromArgb(38, 35, 54);
                        ContentIcon.Image = global::Editor.Resource.help_circle_white;

                        foreach (Button b in panel1.Controls)
                        {
                            b.BackColor = Color.FromArgb(44, 67, 156);
                            b.ForeColor = Color.White;
                        }
                        return;
                    }

                case Theme.Blue:
                    {

                        return;
                    }
            }
        }

    }
}
