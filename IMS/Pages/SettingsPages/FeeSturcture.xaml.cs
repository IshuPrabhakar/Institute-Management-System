using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using IMS.Model;
using Newtonsoft.Json;

namespace IMS.Pages.SettingsPages
{
    /// <summary>
    /// Interaction logic for FeeSturcture.xaml
    /// </summary>
    public partial class FeeSturcture : Page
    {
        public int Index { get; set; }
        public ObservableCollection<FeeListItem> ListItem { get; set; }
        public FeeListItem FeeListModel { get; set; }

        public FeeSturcture()
        {
            ListItem = new ObservableCollection<FeeListItem>();
            FeeListModel = new FeeListItem();

            RetriveSetting();
            InitializeComponent();
        }

        private void RetriveSetting()
        {
            // "gConfig.secure" = filename
            // type Should be type of DataModel Which has to retrived
            SettingHelper helper = new SettingHelper();
            ListItem = RetriveCollection("fConfig.json");
            if (ListItem == null)
            {
                return;
            }
        }

        public ObservableCollection<FeeListItem> RetriveCollection(String FileName)
        {
            //TODO To Add Encryption
            // "gConfig.secure"
            SettingHelper helper = new SettingHelper();
            ObservableCollection<FeeListItem> Collection = new ObservableCollection<FeeListItem>();
            try
            {
                if (!File.Exists(helper.CreateConfigutionFilePath(FileName)))
                {
                    _ = File.Create(helper.CreateConfigutionFilePath(FileName));

                }
                if (new FileInfo(helper.CreateConfigutionFilePath(FileName)).Length != 0)
                {
                    using (StreamReader sr = new StreamReader(helper.CreateConfigutionFilePath(FileName)))
                    {
                        Collection = JsonConvert.DeserializeObject<ObservableCollection<FeeListItem>>(sr.ReadToEnd());
                    }

                }

            }
            catch (Exception e)
            {
                // TODO TO Add A PRompt
                Console.WriteLine(e);
            }
            return Collection;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // "gConfig.secure" = filename
            // type Should be type of DataModel Which has to Save.......
            SettingHelper helper = new SettingHelper();
            helper.Save(ListItem, "fConfig.json", typeof(ObservableCollection<FeeListItem>));
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FeeListItem feeListitem = new FeeListItem
            {
                No = 0,
                AddedBy = "Admin",
                FeeType = NewFeeType.Text,
                FeeAmount = NewFeeAmount.Text,
                Duration = NewFeeDuration.Text,
                ApplyFromCurrent = (bool)NewApplyFromCurrent.IsChecked,
                ApplyToAll = (bool)NewApplyToAll.IsChecked
            };
            ListItem.Add(feeListitem);
            ListItem[ListItem.IndexOf(feeListitem)].No = ListItem.IndexOf(feeListitem) + 1;
        }

        private void RemoveItem(object sender, RoutedEventArgs e)
        {
            Button Remove = sender as Button;
            FeeListItem item = Remove.DataContext as FeeListItem;
            ListItem.RemoveAt(ListItem.IndexOf(item));
        }

        private void EditListItem(object sender, RoutedEventArgs e)
        {
            Button Remove = sender as Button;
            FeeListItem item = Remove.DataContext as FeeListItem;
            DialogBox.IsOpen = true;
            NewFeeType.Text = item.FeeType;
            NewFeeAmount.Text = item.FeeAmount;
            NewFeeDuration.Text = item.Duration;
            NewApplyToAll.IsChecked = item.ApplyToAll;
            NewApplyFromCurrent.IsChecked = item.ApplyFromCurrent;
            Index = ListItem.IndexOf(item);

            //change the content type of button to update
            AddButton.Visibility = Visibility.Collapsed;
            UpdateButton.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            FeeListItem item = new FeeListItem();
            if (Index != 0)
            {
                ListItem[Index].FeeType = NewFeeType.Text;
                ListItem[Index].FeeAmount = NewFeeAmount.Text;
                ListItem[Index].Duration = NewFeeDuration.Text;
                ListItem[Index].ApplyToAll = (bool)NewApplyToAll.IsChecked;
                ListItem[Index].ApplyFromCurrent = (bool)NewApplyFromCurrent.IsChecked;
                ListItem[Index].No = Index;
            }
        }

    }
}
