using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading;
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
using IMS.Helpers;
using LiveCharts;

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for DashBoard.xaml
    /// </summary>
    public partial class DashBoard : Page
    {
        public ChartValues<double> Value { get; set; }

        public DashBoard()
        {
            InitializeComponent();
            Value = new ChartValues<double>
            {
                10,20,30,40,80,70
            };
        }

        private void NewAdmission_Checked(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if(main != null)
            {
                main.Pages.Content = new NewAdmission();
                main.SelectNewAdmission();
            }
        }

        private void Transaction_buttonClick(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.Pages.Content = new Transactions();
                main.SelectFeePage();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(LoadData));
            thread1.Start();
        }

        public object DataTable { get; set; }

        private void LoadData()
        {
            this.Dispatcher.Invoke(() =>
            {
                SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);  // this will open connection for the database

                try
                {
                    connection.Open();
                    String Query = "SELECT * FROM Transactions ORDER BY No DESC LIMIT 5";
                    SQLiteCommand command = new SQLiteCommand(Query, connection);

                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

                    DataTable table = new DataTable("Transactions");
                    dataAdapter.Fill(table);

                    Transaction.AutoGenerateColumns = false;
                    Transaction.ItemsSource = table.DefaultView;

                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Something went Wrong please Restart your Application\n" + ex.Message);
                }
            });

        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
            if (main != null)
            {
                main.Pages.Content = new Staff();
                main.SelectStaff();
            }
        }
    }
}
