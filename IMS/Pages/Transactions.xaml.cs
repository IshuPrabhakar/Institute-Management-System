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

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for Transactions.xaml
    /// </summary>
    public partial class Transactions : Page
    {
        public Transactions()
        {
            InitializeComponent();
            TransactionFrame.Navigate(new Uri("Pages/FeePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void TransactionButton_Click(object sender, RoutedEventArgs e)
        {
            TransactionFrame.Content = new TransactionHistory();
        }

        private void Default_Click(object sender, RoutedEventArgs e)
        {
            TransactionFrame.Content = new FeePage();
        }
    }
}
