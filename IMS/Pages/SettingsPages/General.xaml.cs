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
using IMS.Helpers;
using IMS.Model.HelperModel;
using IMS.Pages.Account_Setting;
using IMS.UserControl;

namespace IMS.Pages.SettingsPages
{
    /// <summary>
    /// Interaction logic for General.xaml
    /// </summary>
    public partial class General : Page
    {
        public FilePicker Picker;
        public GeneralConfigModel GeneralConfig { get; set; }
        public General()
        {
            //GeneralConfig = new GeneralConfigModel();
            RetriveConfig();
            InitializeComponent();

            if (GeneralConfig.InstituteProfileURL == null)
                InstituteProfilePicture.Source = new BitmapImage(new Uri(@"D:\ME\Visual Studio Projects\IMS\IMS\Assets\Person.png"));
        }

        public void RetriveConfig()
        {
            // "gConfig.secure" = filename
            // type Should be type of DataModel Which has to retrived
            try
            {
                SettingHelper helper = new SettingHelper();
                GeneralConfig = helper.RetriveSettings("gConfig.secure", typeof(GeneralConfigModel)) as GeneralConfigModel;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void SaveConfig()
        {
            // "gConfig.secure" = filename
            // type Should be type of DataModel Which has to Save.......
            SettingHelper helper = new SettingHelper();
            helper.SaveSettings(GeneralConfig, "gConfig.secure", typeof(GeneralConfigModel));
        }

        private void SaveButton_click(object sender, RoutedEventArgs e)
        {
            //Getting HashCode for checking wheather Previous setting
            //is Same or Not
            SaveConfig();
        }

        private void ProfilePictureButton_Click(object sender, RoutedEventArgs e)
        {
            Picker = new FilePicker();
            if (!MainGrid.Children.Contains(Picker))
            {
                _ = MainGrid.Children.Add(Picker);
            }
            else
            {
                Picker.Visibility = Visibility.Visible;
            }

            //AccountConfig.AdminPictureURI = Picker.PictureURI.AdminPictureURI;
            if (Picker.Visibility == Visibility.Visible)
                Picker.IsVisibleChanged += Picker_IsVisibleChanged;
        }

        private void Picker_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            GeneralConfigModel URI;
            FilePicker picker = sender as FilePicker;
            URI = picker.DataContext as GeneralConfigModel;
            //GeneralConfig.InstituteProfileURL = Picker.PictureURI.AdminPictureURI;
            SaveConfig();
            //Console.WriteLine(Picker.PictureURI.AdminPictureURI);
        }
    }
}
