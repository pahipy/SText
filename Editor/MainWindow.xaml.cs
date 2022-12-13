using SText.Conf;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Color = System.Windows.Media.Color;

namespace SText.Editor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MinimizeButton.Click += (s, e) => this.WindowState = WindowState.Minimized;
            MaximizeButton.Click += (s, e) => this.WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
            CloseButton.Click += (s, e) => this.Close();
            this.StateChanged += (s, e) =>
            {
                switch (this.WindowState)
                {
                    case WindowState.Normal: WindowBorder.BorderThickness = new Thickness(2); break;
                    case WindowState.Minimized: break;
                    case WindowState.Maximized: WindowBorder.BorderThickness = new Thickness(8); break;
                }
            };

            Conf.ThemeSelector.Events.ThemeChanged += (Conf.Theme t) =>
            {
                ApplyTheme();
            };

            ApplyTheme();

            Conf.FormEvents.Events.FormTitleChanged += (title) => this.Title = title;

        }

        private void ApplyTheme()
        {
            SolidColorBrush BackgroundBrush = new SolidColorBrush(Color.FromRgb(Conf.ThemeSelector.CurrentColorSchema.MenuColor.R,
                                Conf.ThemeSelector.CurrentColorSchema.MenuColor.G,
                                Conf.ThemeSelector.CurrentColorSchema.MenuColor.B));
            TitleBar.Background = BackgroundBrush;
            TitleLabel.Foreground = new SolidColorBrush(Color.FromRgb(Conf.ThemeSelector.CurrentColorSchema.MenuFontColor.R,
                Conf.ThemeSelector.CurrentColorSchema.MenuFontColor.G,
                Conf.ThemeSelector.CurrentColorSchema.MenuFontColor.B));
            WindowBorder.BorderBrush = BackgroundBrush;

        }

        private void WpfWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left = SettngsInf.Settings.WindowPosition.X;
            this.Top = SettngsInf.Settings.WindowPosition.Y;
            this.Width = SettngsInf.Settings.WindowSize.Width;
            this.Height = SettngsInf.Settings.WindowSize.Height;
        }

        private void WpfWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            FormEvents.Events.NotifyFormClosingFromWPF(sender, e);
        }
    }

}
