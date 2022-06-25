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
using System.Data.SQLite;

namespace IMS
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        String ConnectionString = @" Data Source=D:\ME\Visual Studio Projects\IMS\IMS\Data\IMSdb.db;Version=3;";
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void UsernameBox_KeyDown(object sender, KeyEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);  // this will open connection for the database

            try
            {
                connection.Open();
                String Query = "SELECT Username FROM Credential";
                SQLiteCommand command = new SQLiteCommand(Query, connection);

                SQLiteDataReader dataReader = command.ExecuteReader();

                while(dataReader.Read())
                {
                    string username = dataReader.GetString(0);
                    string Eusername = UsernameBox.Text.ToString();
                    bool access = string.Equals(Eusername, username);

                    if (e.Key == Key.Enter)
                    {

                        if (access != true)
                        {

                            MessageBox.Show("Wrong Username!");
                        }
                    }

                }
                    connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went Wrong please Restart your Application\n" + ex.Message);
            }

           
            }

        private void PasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);  // this will open connection for the database

            try
            {
                connection.Open();
                String Query = "select Password from Credential";
                SQLiteCommand command = new SQLiteCommand(Query, connection);

                SQLiteDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string password = dataReader.GetString(0);

                    string Epassword = PasswordBox.Password.ToString();


                    if (e.Key == Key.Enter)
                    {
                        bool access = string.Equals(Epassword, password);
                        if (access == true)
                        {
                            MainWindow dashboard = new MainWindow();
                            dashboard.Show();
                            this.Close();

                        }
                        else
                        {
                            MessageBox.Show("Wrong Username or password!");
                        }
                    }
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went Wrong please Restart your Application\n" + ex.Message);
            }
        }
    }
    
}
