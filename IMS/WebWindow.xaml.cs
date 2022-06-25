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
using CefSharp;
using CefSharp.Wpf;
using IMS.Pages.Web;
using IMS.Helpers;

namespace IMS
{
    /// <summary>
    /// Interaction logic for WebWindow.xaml
    /// </summary>
    public partial class WebWindow : Window
    {
        public Fb facebook = new Fb();
        public Wa whatsapp = new Wa();
        public Site site = new Site();

        public WebWindow()
        {
            
            InitializeComponent();
            TabFrame.Content = facebook;

            //Broser Cache Path, this is to avoid extra loading time
            SettingHelper helper = new SettingHelper();
            CefSettings settings = new CefSettings();
            // create a new folder in appdata folder
            settings.CachePath = helper.WebCachePath();
            Cef.Initialize(settings);
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

        private void Backward(object sender, RoutedEventArgs e)
        {
            Uri F = new Uri("Pages/Web/Fb.xaml");
            Uri W = new Uri("Pages/Web/Fb.xaml");
            Uri S = new Uri("Pages/Web/Fb.xaml");
            if (TabFrame.CurrentSource == F)
            {
                facebook.Backword();
            }
            else if(TabFrame.CurrentSource == W)
            {
                whatsapp.Backword();
            }
            else if (TabFrame.CurrentSource == S)
            {
                site.Backword();
            }
            else
            {

            }
        }

        private void Forward(object sender, RoutedEventArgs e)
        {
            Uri F = new Uri("Pages/Web/Fb.xaml");
            Uri W = new Uri("Pages/Web/Fb.xaml");
            Uri S = new Uri("Pages/Web/Fb.xaml");
            if (TabFrame.CurrentSource == F)
            {
                facebook.Forword();
            }
            else if (TabFrame.CurrentSource == W)
            {
                whatsapp.Forword();
            }
            else if (TabFrame.CurrentSource == S)
            {
                site.Forword();
            }
            else
            {

            }
        }

        private void Facebook(object sender, RoutedEventArgs e)
        {
            TabFrame.Navigate(new Uri("Pages/Web/Fb.xaml", UriKind.RelativeOrAbsolute));

            // TODO HAVE TO ADD TAB CONTROL
        }

        private void WhatsApp(object sender, RoutedEventArgs e)
        {
            TabFrame.Content = whatsapp;
        }

        private void Site(object sender, RoutedEventArgs e)
        {
            TabFrame.Content = site;
        }

        private void Reload(object sender, RoutedEventArgs e)
        {
            Uri F = new Uri("Pages/Web/Fb.xaml");
            Uri W = new Uri("Pages/Web/Fb.xaml");
            Uri S = new Uri("Pages/Web/Fb.xaml");
            if (TabFrame.CurrentSource == F)
            {
                facebook.Reload();
            }
            else if (TabFrame.CurrentSource == W)
            {
                whatsapp.Reload();
            }
            else if (TabFrame.CurrentSource == S)
            {
                site.Reload();
            }
            else
            {

            }
        }
    }
}
