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
using IMS.Model;
using IMS.Model.HelperModel;
using IMS.Helpers;
using System.IO;
using IMS.UserControl;
namespace IMS.Pages.Account_Setting
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Page
    {
        public List<UserListItem> ListItem { get; set; }
        public AccountConfigModel AccountConfig { get; set; }
        public FilePicker Picker;
        public URIs AdminURI { get; set; }

        public Account()
        {
            Picker = new FilePicker();

            RetriveConfig();
            InitializeComponent();

            Console.WriteLine(AdminURI.AdminProfilePicture);

            ListItem = new List<UserListItem>
            {
                new UserListItem()
                {
                    No = 1,
                    UserName = "Ishu Prabhakar",
                    Password = "Hello",
                    HasAllPreveledge = true,
                    CanManageStudent = true
                }
            };


            // To check Whether the is empty or not if empty
            // it will not show the list empty messege
            UserList.ItemsSource = ListItem;
            if (UserList.HasItems)
            {
                HeaderOfList.Visibility = Visibility.Collapsed;
            }

            //Profile picture
            if (AccountConfig.AdminPictureURI == null)
                AccountConfig.AdminPictureURI = new BitmapImage(new Uri(@"D:\ME\Visual Studio Projects\IMS\IMS\Assets\Person.png")).ToString();
            else
            {
                AccountConfig.AdminPictureURI = AdminURI.AdminProfilePicture;
            }

        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    //Console.WriteLine(new SettingHelper().CreateConfigutionFilePath() + "Configs" + "/aConfig.save");
            //    StreamReader reader = new StreamReader(new SettingHelper().CreateConfigutionFilePath("aConfig.secure"));
            //    Console.WriteLine(reader.ReadToEnd());
            //    Console.WriteLine("fdhoipj");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex);
            //}
        }

        private void SaveButton_click(object sender, RoutedEventArgs e)
        {
            //Getting HashCode for checking wheather Previous setting
            //is Same or Not

            SaveAccountSettings();
            //if (PreviousMailSetting != NewMailSetting)
            //{
            //}
            //else
            //{
            //    Console.WriteLine("Nothing Changed");
            //}

            //Console.WriteLine(PreviousMailSetting + "\n" + NewMailSetting);
        }

        private void RetriveConfig()
        {
            try
            {
                SettingHelper helper = new SettingHelper();
                AccountConfig = helper.RetriveSettings("aConfig.secure", typeof(AccountConfigModel)) as AccountConfigModel;
                AdminURI = helper.RetriveSettings("assets.uri", typeof(URIs)) as URIs;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void SaveAccountSettings()
        {
            SettingHelper helper = new SettingHelper();
            helper.SaveSettings(AccountConfig, "aConfig.secure", typeof(AccountConfigModel));
            Console.WriteLine("Saving..");
        }

        private void ProfilePictureEdit(object sender, RoutedEventArgs e)
        {
            if (!MainGrid.Children.Contains(Picker))
            {
                _ = MainGrid.Children.Add(Picker);
            }
            else
            {
                Picker.Visibility = Visibility.Visible;
            }

            AccountConfig.AdminPictureURI = Picker.AdminURI.AdminProfilePicture;
            if (Picker.Visibility == Visibility.Visible && Picker.SaveButton.IsPressed)
                Picker.IsVisibleChanged += Picker_IsVisibleChanged;
        }

        private void Picker_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            SettingHelper helper = new SettingHelper();
            AdminURI = helper.RetriveSettings("assets.uri", typeof(URIs)) as URIs;
            AccountConfig.AdminPictureURI = AdminURI.AdminProfilePicture;
        }
    }
}
