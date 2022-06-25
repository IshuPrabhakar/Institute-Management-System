using Microsoft.Win32;
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
using System.Windows.Threading;
using IMS.Model;
using IMS.Helpers;
using IMS.Pages.Account_Setting;
using IMS.Model.HelperModel;

namespace IMS.UserControl
{
    /// <summary>
    /// Interaction logic for FilePicker.xaml
    /// </summary>
    public partial class FilePicker
    {
        //public AccountConfigModel PictureURI { get; set; }
        public URIs AdminURI { get; set; }

        public FilePicker()
        {
            AdminURI = new URIs();
            InitializeComponent();
        }

        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // To Close on MouseClick Away From the main content
            this.Visibility = Visibility.Collapsed;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog
            {
                Filter = "Images | *.jpg; *.jpeg; *.png; ",
                CheckFileExists = true,
                Multiselect = false
            };

            if (fileDialog.ShowDialog() == true)
            {
                //Console.WriteLine(fileDialog.FileName + " 1st");
                AdminURI.AdminProfilePicture = new Uri(fileDialog.FileName).ToString();
                //Console.WriteLine(AdminURI.AdminProfilePicture);
                if (AdminURI.AdminProfilePicture != null)
                {
                    DispatcherTimer timer = new DispatcherTimer
                    {
                        Interval = new TimeSpan(0, 0, 1)
                    };
                    timer.Tick += Timer_Tick;
                    timer.Start();

                    DropArea.Visibility = Visibility.Collapsed;
                    ProgressBar.Visibility = Visibility.Visible;
                }

            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            ProgressBar.Visibility = Visibility.Collapsed;
            Previewbox.Visibility = Visibility.Visible;
            Preview.Source = new BitmapImage(new Uri(AdminURI.AdminProfilePicture));
        }

        private void DropArea_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                AdminURI.AdminProfilePicture = (new Uri(files[0])).ToString();

                DispatcherTimer timer = new DispatcherTimer
                {
                    Interval = new TimeSpan(0, 0, 1)
                };
                timer.Tick += Timer_Tick;
                timer.Start();

                if (AdminURI.AdminProfilePicture != null)
                {
                    DropArea.Visibility = Visibility.Collapsed;
                    ProgressBar.Visibility = Visibility.Visible;
                    Preview.Source = new BitmapImage(new Uri(AdminURI.AdminProfilePicture));
                }
            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SettingHelper helper = new SettingHelper();
            helper.SaveSettings(AdminURI, "assets.uri", typeof(URIs));
            this.Visibility = Visibility.Collapsed;
        }

        private void Cancel(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
        }
    }
}
