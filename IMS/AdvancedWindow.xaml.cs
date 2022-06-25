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

namespace IMS
{
    /// <summary>
    /// Interaction logic for AdvancedWindow.xaml
    /// </summary>
    public partial class AdvancedWindow : Window
    {
        public AdvancedWindow()
        {
            InitializeComponent();
            AdvFrame.Navigate(new Uri("Pages/Account_Setting/Account.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Minimise_Button(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        private void Maximise_Button(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                MaximiseButton.Kind = MaterialDesignThemes.Wpf.PackIconKind.FullscreenExit;      //Change in icon of maximise button
                this.WindowState = WindowState.Maximized;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                MaximiseButton.Kind = MaterialDesignThemes.Wpf.PackIconKind.Fullscreen;
                this.WindowState = WindowState.Normal;
            }
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
