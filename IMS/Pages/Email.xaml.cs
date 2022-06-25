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
using IMS.UserControl;

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for Email.xaml
    /// </summary>
    public partial class Email : Page
    {
        public Email()
        {
            InitializeComponent();

        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            Pop.IsPopupOpen = Pop.IsPopupOpen != true;
        }

        //private void TextBox_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    pop.IsPopupOpen = pop.IsPopupOpen != true;
        //}

        //private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    pop.IsPopupOpen = pop.IsPopupOpen != true;
        //}
    }
}
