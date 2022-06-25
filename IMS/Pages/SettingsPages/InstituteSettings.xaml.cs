using IMS.Model.HelperModel;
using IMS.UserControl;
using Microsoft.Win32;
using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using IMS.Model;
using IMS.Helpers;
using Newtonsoft.Json;
using IMS.ViewModel;

namespace IMS.Pages.SettingsPages
{
    /// <summary>
    /// Interaction logic for InstituteSettings.xaml
    /// </summary>
    public partial class InstituteSettings : Page
    {
        //public InstituteConfigModel Config { get; set; }
        //public ObservableCollection<StudentSession> ListItem { get; set; }
        //public StudentSession studentSession { get; set; }

        public InstituteSettings()
        {
            //Config = new InstituteConfigModel();
            //ListItem = new ObservableCollection<StudentSession>();

            //RetriveConfig();
            InitializeComponent();
            //InstituteViewModel viewModel = new InstituteViewModel();
            //DataContext = viewModel;
        }

        //public void RetriveConfig()
        //{
        //    // "iConfig.secure" = filename
        //    // type Should be type of DataModel Which has to retrived
        //    try
        //    {
        //        SettingHelper helper = new SettingHelper();
        //        Config = helper.Retrive("iConfig.json", typeof(InstituteConfigModel)) as InstituteConfigModel;
        //        ListItem = Config.Sessions;
        //        if (Config == null)
        //        {
        //            return;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e);
        //    }
        //}

        ////public void SaveConfig()
        ////{
        ////    // "iConfig.secure" = filename
        ////    // type Should be type of DataModel Which has to Save.......
        ////    SettingHelper helper = new SettingHelper();
        ////    Config.Sessions = ListItem;
        ////    helper.Save(Config, "iConfig.json", typeof(InstituteConfigModel));
        ////}

        //public ObservableCollection<StudentSession> RetriveCollection(string FileName)
        //{
        //    //TODO To Add Encryption
        //    // "gConfig.secure"
        //    SettingHelper helper = new SettingHelper();
        //    ObservableCollection<StudentSession> Collection = new ObservableCollection<StudentSession>();
        //    try
        //    {
        //        if (!File.Exists(helper.CreateConfigutionFilePath(FileName)))
        //        {
        //            _ = File.Create(helper.CreateConfigutionFilePath(FileName));

        //        }
        //        if (new FileInfo(helper.CreateConfigutionFilePath(FileName)).Length != 0)
        //        {
        //            using(StreamReader sr = new StreamReader(helper.CreateConfigutionFilePath(FileName)))
        //            {
        //                Collection = JsonConvert.DeserializeObject<ObservableCollection<StudentSession>>(sr.ReadToEnd());
        //            }

        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        // TODO TO Add A PRompt
        //        Console.WriteLine(e);
        //    }
        //    return Collection;
        //}

        private void InstituteRollPrefixBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //StudentSession NewSession = new StudentSession
            //{
            //    Session = Session.Text,
            //    AppliedTo = AppliedTo.Text,
            //    AddedBy = "Admin",
            //    No = 0,
            //    Date = DateTime.Today.Date.ToString(),
            //};
            //ListItem.Add(NewSession);
            //ListItem[ListItem.IndexOf(NewSession)].No = ListItem.IndexOf(NewSession) + 1;
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            //Button Remove = sender as Button;
            //StudentSession item = Remove.DataContext as StudentSession;
            //ListItem.RemoveAt(ListItem.IndexOf(item));
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            //SaveConfig();
        }


    }
}
