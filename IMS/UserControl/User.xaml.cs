using System;
using System.Collections.Generic;
using System.Data.SQLite;
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

namespace IMS.UserControl
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User 
    {
        public User()
        {
            InitializeComponent();
        }

        private void SaveUser_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);
            //    connection.Open();
            //    String Query = "INSERT INTO Credential (";
            //    SQLiteCommand command = new SQLiteCommand(Query, connection);
            //    command.ExecuteNonQuery();

            //    connection.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
