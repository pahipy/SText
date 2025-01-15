using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
using System.Drawing.Imaging;

namespace SText.Dialogs
{
    /// <summary>
    /// Interaction logic for AboutDialog.xaml
    /// </summary>
    public partial class AboutDialog : FluentWindow
    {
        public AboutDialog(FluentWindow Owner)
        {
            InitializeComponent();

            this.Owner = Owner;

            AppVersion.Text = $"{Assembly.GetExecutingAssembly().GetName().Version}";

            this.KeyDown += (s, e) =>
            {
                if (e.Key == Key.Escape || e.Key == Key.Enter)
                {
                    this.Close();
                }
            };

            AppImage.Source = Tools.BitmapConverter.BitmapToBitmapImage(SText.Resources.STextIcon_Big, ImageFormat.Png);
            //SText.Resources.STextIcon_Big
        }

        private void OkayButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
