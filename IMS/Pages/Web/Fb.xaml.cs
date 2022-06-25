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
using CefSharp;
using CefSharp.Wpf;

namespace IMS.Pages.Web
{
    /// <summary>
    /// Interaction logic for Fb.xaml
    /// </summary>
    public partial class Fb : Page
    {
        public Fb()
        {
            InitializeComponent();
            Browser.Address = "Facebook.com";
        }

        public void Reload()
        {
            Browser.Reload();
        }

        public void Backword()
        {
            if (Browser.CanGoBack)
            {
                Browser.Back();
            }
        }

        public void Forword()
        {
            if (Browser.CanGoForward)
            {
                Browser.Forward();
            }
        }
    }
}
