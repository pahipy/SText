using SText.Conf;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Xml.Linq;
using Wpf.Ui.Appearance;
using Wpf.Ui.Controls;

using SaveFileDialog = Microsoft.Win32.SaveFileDialog;
using Button = Wpf.Ui.Controls.Button;

namespace SText.Dialogs
{
    /// <summary>
    /// Interaction logic for SaveDialog.xaml
    /// </summary>
    public partial class SaveDialog : FluentWindow
    {
        public SaveDialog(FluentWindow Owner, string FileName)
        {
            InitializeComponent();

            Header.Content = ProgramSets.ProgramName;

            Message.Content += " " + (File.Exists(FileName) ? new FileInfo(FileName).Name : FileName) + "?";
            inputFileName = FileName;
            this.Owner = Owner;
            this.Loaded += (s,e) => QuestionIcon.Source = Tools.BitmapConverter.BitmapToBitmapImage(SText.Resources.help_circle_white);
        }
        public SaveDialog(FluentWindow Owner, string FileName, SaveFileDialog Dialog) : this(Owner, FileName)
        {
            fileDialog = Dialog;
        }

        private SaveFileDialog fileDialog = null;
        private string inputFileName;
        private SDialogResult dialogResult;

        public SDialogResult SDialogResult { get => dialogResult; }

        public string FileName
        {
            get => fileDialog is not null ? fileDialog.FileName : inputFileName;
        }


        public SDialogResult ShowSDialog()
        {
            this.ShowDialog();
            return dialogResult;
        }

        private void ActionButtons_Click(object sender, RoutedEventArgs e)
        {
            string Name = ((Button)sender).Name;

            switch (Name)
            {
                case "SaveButton":
                    {
                        if (fileDialog is not null && !File.Exists(inputFileName))
                        {
                            this.Hide();
                            dialogResult = fileDialog.ShowDialog() ?? false ? SDialogResult.Save : SDialogResult.Cancel;

                            if (DialogResult ?? false && !File.Exists(fileDialog.FileName))
                                File.Create(fileDialog.FileName).Close();

                        }
                        else
                            dialogResult = SDialogResult.Save;
                        break;
                    }

                case "AbortButton":
                    {
                        dialogResult = SDialogResult.Abort;
                        break;
                    }

                case "CancelButton":
                    {
                        dialogResult = SDialogResult.Cancel;
                        break;
                    }
                    
            }
            Close();

        }
    }
}
