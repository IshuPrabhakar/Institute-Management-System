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

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for TransactionHistory.xaml
    /// </summary>
    public partial class TransactionHistory : Page
    {
        public TransactionHistory()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(LoadData));
            thread1.Start();
        }

        private void LoadData()
        {
            this.Dispatcher.Invoke(() =>
            {
                SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);  // this will open connection for the database

                try
                {
                    connection.Open();
                    String Query = "SELECT * FROM Transactions";
                    SQLiteCommand command = new SQLiteCommand(Query, connection);

                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

                    DataTable table = new DataTable("Transactions");
                    dataAdapter.Fill(table);

                    TransactionDataGrid.AutoGenerateColumns = false;
                    TransactionDataGrid.ItemsSource = table.DefaultView;

                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Something went Wrong please Restart your Application\n" + ex.Message);
                }
            });
        }

       
    }
}
