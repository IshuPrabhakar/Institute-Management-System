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

namespace IMS.Pages.Account_Setting
{
    /// <summary>
    /// Interaction logic for Institute.xaml
    /// </summary>
    public partial class Institute : Page
    {
        public Institute()
        {
            InitializeComponent();
            InstituteFrame.Navigate(new Uri("Pages/SettingsPages/General.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Fee_Structure(object sender, RoutedEventArgs e)
        {
            
        }


        private void Advanced_Setting(object sender, RoutedEventArgs e)
        {

        }

        private void General(object sender, RoutedEventArgs e)
        {
            //InstituteFrame.Content = new General();
        }

        private void Institue_Setting(object sender, RoutedEventArgs e)
        {
            //InstituteFrame.Content = new InstituteSettings();
        }

        private void Account_Setting(object sender, RoutedEventArgs e)
        {
            InstituteFrame.Content = new Account();
        }

        private void Fee_and_payment(object sender, RoutedEventArgs e)
        {
            //InstituteFrame.Content = new FeeSturcture();
        }
    }
}
