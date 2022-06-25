using IMS.Pages;
using IMS.UserControl;
using Microsoft.Win32;
using System.Drawing;
using System.IO;
using System;
using System.Data.SQLite;
using System.Data;
using System.Threading;
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
using IMS.Pages.SettingsPages;
using IMS.Pages.Account_Setting;
using IMS.Helpers;
using IMS.Model;

namespace IMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static String ConnectionString = @" Data Source=D:\ME\Visual Studio Projects\IMS\IMS\Data\IMSdb.db;Version=3;";
        BitmapImage bi;
        readonly Thread Retrive;
        public Configurations configurations { get; set; }

        public MainWindow()
        {
            /// LOAD CONFIGURATION
            configurations = new Configurations();
            /// LOAD CONFIGURATION


            InitializeComponent();
            _ = Pages.Navigate(new Uri("Pages/dashBoard.xaml", UriKind.RelativeOrAbsolute));

            //Retrive = new Thread(() => RetriveALLSettings());
            //Retrive.Start();
        }

        private void RetriveALLSettings()
        {
            SettingHelper helper = new SettingHelper();
            configurations = helper.Retrive("Configurations.json", typeof(Configurations)) as Configurations;
            if (configurations == null)
            {
                return;
            }
        }

        private void Minimise_Button(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Minimized;
            }
            else if (WindowState == WindowState.Minimized)
            {
                WindowState = WindowState.Normal;
            }
            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Minimized;
            }
        }

        private void Maximise_Button(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                MaximiseButton.Kind = MaterialDesignThemes.Wpf.PackIconKind.FullscreenExit;      //Change in icon of maximise button
                WindowState = WindowState.Maximized;
            }
            else if (WindowState == WindowState.Maximized)
            {
                MaximiseButton.Kind = MaterialDesignThemes.Wpf.PackIconKind.Fullscreen;
                WindowState = WindowState.Normal;
            }
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Setting_ButtonClick(object sender, RoutedEventArgs e)
        {
            Pages.Content = new Settings();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindowProfilePictureEdit_Loaded(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(ConnectionString);  
            try
            {
                connection.Open();
                String Query = "SELECT UserImage,InstitutionName FROM Credential WHERE ID=1";
                SQLiteCommand command = new SQLiteCommand(Query, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string bgImage64 = dataReader.GetString(0);
                    InstituteTextBlock.Text = dataReader.GetString(1);
                   


                    byte[] binaryData = Convert.FromBase64String(bgImage64);
                    bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(binaryData);
                    bi.EndInit();

                    MainWindowProfilePictureEdit.Source = bi;
                }
                    connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something went Wrong please Restart your Application \n Profile \n" + ex.Message);
            }

           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //Settings settings = new Settings();
            //settings.loaddata();
        }

        private void Sublist()
        {
            HistorySubList.SelectedIndex = 2;
            InstitueSubList.SelectedIndex = 3;
            TransactionSubList.SelectedIndex = 1;
            StudentSubList.SelectedIndex = 2;
        }

        public void SelectNewAdmission()
        {
            StudentSubList.SelectedIndex = 1;
        }

        public void SelectFeePage()
        {
            TransactionSubList.SelectedIndex = 0;
        }

        public void SelectStaff()
        {
            MainList.SelectedIndex = 5;
        }

        private void Dashboardd_Selected(object sender, RoutedEventArgs e)
        {
            Sublist();
            Pages.Navigate(new Uri("Pages/dashBoard.xaml", UriKind.RelativeOrAbsolute));

            SettingHelper setting = new SettingHelper();
            ////Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + "/IMS/Configs");
            ////Console.WriteLine(setting.CreateConfigutionFilePath());
            //Console.WriteLine(setting.CreateConfigutionFilePath());

            //try
            //{
            //    String configFilePath = (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + @"\IMS\Configs\hi.txt").ToString();
            //    //File.Create(configFilePath);
            //    //using (StreamWriter writer = new StreamWriter(configFilePath))
            //    //{
            //    //    writer.WriteLine("HELLO!   fdddddddddddddddddddddddddg   ");
            //    //}

            //    //Console.WriteLine(new SettingHelper().CreateConfigutionFilePath() + "Configs" + "/aConfig.save");
            //    using (StreamReader reader = new StreamReader(configFilePath))
            //    {
            //        Console.WriteLine(reader.ReadToEnd());
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}

        }

        private void StudentMenuButton_Selected(object sender, RoutedEventArgs e)
        {
            MainList.SelectedIndex = 1;
            Pages.Navigate(new Uri("Pages/Student.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Menubutton3_Selected(object sender, RoutedEventArgs e)
        {
            Sublist();
            Pages.Content = new Transactions();
        }

        private void Menubutton4_Selected(object sender, RoutedEventArgs e)
        {
            Sublist();
            Pages.Content = new Courses();
        }

        private void Menubutton8_Selected(object sender, RoutedEventArgs e)
        {
            Sublist();
            Pages.Content = new Settings();
        }

        private void History_Selected(object sender, RoutedEventArgs e)
        {
            Sublist();
            Pages.Content = new History();
        }

        private void transaction_history(object sender, RoutedEventArgs e)
        {
            MainList.SelectedIndex = 6;
            Pages.Content = new TransactionHistory();
        }

        private void student_selected(object sender, RoutedEventArgs e)
        {
            MainList.SelectedIndex = 6;
            Pages.Content = new Student();
        }

        private void InstituteSetting(object sender, RoutedEventArgs e)
        {
            MainList.SelectedIndex = 3;
            Pages.Navigate(new Uri("Pages/SettingsPages/General.xaml", UriKind.RelativeOrAbsolute));
        }

        private void UserProfile_Click(object sender, RoutedEventArgs e)
        {
            pop.IsPopupOpen = pop.IsPopupOpen != true;
        }

        private void Institute_Selected(object sender, RoutedEventArgs e)
        {
            MainList.SelectedIndex = 3;
            Pages.Navigate(new Uri("Pages/SettingsPages/InstituteSettings.xaml", UriKind.RelativeOrAbsolute));
        }

        private void FeeStructure_Selected(object sender, RoutedEventArgs e)
        {
            MainList.SelectedIndex = 3;
            Pages.Navigate(new Uri("Pages/SettingsPages/FeeSturcture.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ManageFee_FeePage(object sender, RoutedEventArgs e)
        {
            MainList.SelectedIndex = 2;
            Pages.Navigate(new Uri("Pages/FeePage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void AddNewStudent(object sender, RoutedEventArgs e)
        {
            MainList.SelectedIndex = 1;
            Sublist();
            Pages.Navigate(new Uri("Pages/NewAdmission.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Web(object sender, RoutedEventArgs e)
        {
            WebWindow webWindow = new WebWindow();
            webWindow.Show();
        }

        private void AccountAndAdvanced(object sender, RoutedEventArgs e)
        {
            AdvancedWindow advancedWindow = new AdvancedWindow();
            advancedWindow.Show();
        }

        private void EmailAndNotification_Selected(object sender, RoutedEventArgs e)
        {
            Sublist();
            Pages.Navigate(new Uri("Pages/Email.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Staff_Selected(object sender, RoutedEventArgs e)
        {
            Sublist();
            Pages.Content = new Staff();
            Console.WriteLine(Pages.CurrentSource);

        }

        private void DarkModeToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AppTheme = "Dark";
            Properties.Settings.Default.Save();
        }

        private void DarkModeToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.AppTheme = "Light";
            Properties.Settings.Default.Save();
        }

        private void Exam_Selected(object sender, RoutedEventArgs e)
        {
            Pages.Content = new Exam();
        }

        private void Attendence_Selected(object sender, RoutedEventArgs e)
        {
            Pages.Content = new Attendence();
        }

        private void SaveSettingsWhenWindowIsClosing(object sender, RoutedEventArgs e)
        {
            SettingHelper helper = new SettingHelper();
            helper.Save(configurations, "Configurations.json", typeof(Configurations));
        }
    }
}
