using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for Staff.xaml
    /// </summary>
    public partial class Staff : Page
    {
        public int SrNo { get; set; }
        public ObservableCollection<StaffListItem> ListItem { get; set; }
        public int index { get; set; }
        public String Filepath { get; set; }
        public Boolean CanLogin { get; set; }

        public Staff()
        {
            ListItem = new ObservableCollection<StaffListItem>();
            SrNo = ListItem.Count();

            InitializeComponent();
            RetriveSetting();

            // To check Whether the is empty or not if empty
            // it will not show the list empty messege
            if (StaffList.HasItems)
            {
                HeaderOfList.Visibility = Visibility.Collapsed;
            }
        }

        private void RetriveSetting()
        {
            // "sConfig.secure" = filename
            // type Should be type of DataModel Which has to retrived
            SettingHelper helper = new SettingHelper();
            ObservableCollection<StaffListItem> item = helper.RetriveSettings("sConfig.secure", typeof(ObservableCollection<StaffListItem>)) as ObservableCollection<StaffListItem>;
            if (item != null)
            {
                foreach (var i in item)
                {
                    ListItem.Add(i);
                }
            }
            else
            {
                _ = MessageBox.Show("You don't Have any Courses yet, \n create new course here.");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // "sConfig.secure" = filename
            // type Should be type of DataModel Which has to Save.......
            SettingHelper helper = new SettingHelper();
            helper.SaveSettings(ListItem, "sConfig.secure", typeof(ObservableCollection<StaffListItem>));
        }

        private void AddNewStaff_Click(object sender, RoutedEventArgs e)
        {
            StaffListItem list = new StaffListItem
            {
                No = ListItem.Count + 1,
                StaffName = StaffName.Text,
                StaffRole = StaffRole.Text,
                Phone = StaffPhone.Text,
                Email = NewStaffEmail,
                Filepath = Filepath,
                // TODO Have to add VAlidation here
                Salary = int.Parse(StaffSalary.Text),

            };
            ListItem.Add(list);
            if (StaffList.HasItems)
            {
                HeaderOfList.Visibility = Visibility.Collapsed;
            }
        }

        private void ResumeUploadButton_Click(object sender, RoutedEventArgs e)
        {
            SettingHelper helper = new SettingHelper();
            // TODO have to add Cousre Name as filename
            // but for debugging it is set to demo
            // filename = StaffName.Text
            Filepath = helper.CreateFiles("Staff", "Demo");
            ResumeUploadButton.Content = "Update";
        }

        private void StaffEdit(object sender, RoutedEventArgs e)
        {
            Button Edit = sender as Button;
            StaffListItem item = Edit.DataContext as StaffListItem;
            DialogBox.IsOpen = true;
            NewStaffName = item.StaffName;
            StaffRole.Text = item.StaffRole;
            NewStaffEmail = item.Email;
            NewStaffPhone = item.Phone;
            StaffSalary.Text = item.Salary.ToString();

            index = item.No;

            //change the content type of button to update
            AddButton.Visibility = Visibility.Collapsed;
            UpdateButton.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            StaffListItem item = new StaffListItem();
            if (index != 0)
            {
                item = ListItem[index - 1];
                item.StaffName = NewStaffName;
                item.StaffRole = StaffRole.Text;
                item.Email = NewStaffEmail;
                item.Phone = NewStaffPhone;

                item.Salary = int.Parse(StaffSalary.Text);
                item.No = index;

            }
        }

        private void StaffView(object sender, RoutedEventArgs e)
        {

        }

        private void StaffPrint(object sender, RoutedEventArgs e)
        {

        }

        private void StaffDelete(object sender, RoutedEventArgs e)
        {
            Button Remove = sender as Button;
            StaffListItem item = Remove.DataContext as StaffListItem;
            if (ListItem.Count == 1)
            {
                // set item number dynamically
                ListItem.RemoveAt(0);
            }
            ListItem.RemoveAt(item.No - 1);
        }

        private void ToggleButton_Click(object sender, RoutedEventArgs e)
        {
            Button login = sender as Button;
            StaffListItem item = login.DataContext as StaffListItem;
            CanLogin = login.IsEnabled;
            //TODO to add this in file
        }


        /// <summary>
        /// Properties For Validation 
        /// </summary>
        public String NewStaffName { get; set; }

        public String NewStaffEmail { get; set; }

        public String NewStaffPhone { get; set; }
    }
}
