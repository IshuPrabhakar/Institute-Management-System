using System;
using System.Collections.Generic;
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
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Page
    {
        public static string chargedfee;

        public Settings()
        {
            InitializeComponent();
        }

        //private void SaveButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //SaveSnackbar.Visibility = Visibility.Visible;

        //    Thread thread1 = new Thread(new ThreadStart(savedata));
        //    thread1.Start();
        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread2 = new Thread(new ThreadStart(loaddata));
            thread2.Start();
        }

        //private void savedata()
        //{
        //    this.Dispatcher.Invoke(() =>
        //   {
        //       try
        //       {
        //           SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);
        //           connection.Open();
        //           String Query = " UPDATE InstituteSettings SET ChargedFee = '" + FeeCharged.Text + "' WHERE No = 1";

        //           SQLiteCommand command = new SQLiteCommand(Query, connection);
        //           command.ExecuteNonQuery();

        //           connection.Close();
        //       }
        //       catch (Exception ex)
        //       {
        //           MessageBox.Show(ex.Message);
        //       }
        //   });
        //}

        public void loaddata()
        {
            this.Dispatcher.Invoke(() =>
            {
                SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);  // this will open connection for the database

                try
                {
                    connection.Open();
                    String Query = "SELECT ChargedFee FROM InstituteSettings";
                    SQLiteCommand command = new SQLiteCommand(Query, connection);

                    SQLiteDataReader dataReader = command.ExecuteReader();

                    while (dataReader.Read())
                    {
                        chargedfee = dataReader.GetString(0);
                        //FeeCharged.Text = chargedfee;
                    }

                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Something went Wrong please Restart your Application\n feecharged \n" + ex.Message);
                }
            });
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AppTheme = "Dark";
            Properties.Settings.Default.Save();
           
        }

        private void ThemeModeButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AppTheme = "Light";
            Properties.Settings.Default.Save();
        }
    }
}
