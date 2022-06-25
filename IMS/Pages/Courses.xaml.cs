using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
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


namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for Courses.xaml
    /// </summary>
    public partial class Courses : Page
    {
        public int SrNo { get; set; }
        public ObservableCollection<CoursesListItem> ListItem { get; set; }
        public int index { get; set; }
        public String Filepath { get; set; }

        public Courses()
        {
            ListItem = new ObservableCollection<CoursesListItem>();
            SrNo = ListItem.Count();
            InitializeComponent();
            RetriveSetting();

            // To check Whether the is empty or not if empty
            // it will not show the list empty messege
            if (CourseList.HasItems)
            {
                HeaderOfList.Visibility = Visibility.Collapsed;
            }
        }

        private void AddNewButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            // to add upload methed
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            SettingHelper helper = new SettingHelper();
            // TODO have to add Cousre Name as filename
            // but for debugging it is set to demo
            // filename = CourseName.Text
            Filepath = helper.CreateFiles("Courses", "Demo");
            CreateButton.Content = "Update";
        }

        //private void IsNull()
        //{
        //    if (String.IsNullOrWhiteSpace(CourseName.Text) && String.IsNullOrWhiteSpace(CourseBatch.Text) && String.IsNullOrWhiteSpace(CourseCode.Text) && String.IsNullOrWhiteSpace(CourseFee.Text))
                

           
        //}

        private void AddNewCourse_Click(object sender, RoutedEventArgs e)
        {
            SrNo++;
            CoursesListItem list = new CoursesListItem
            {
                No = SrNo,
                CourseName = CourseName.Text,
                AddedDate = DateTime.Now.ToString("dd/MM/YYYY"),
                Description = Description.Text,
                AppliedTo = CourseBatch.Text,
                CourseCode = CourseCode.Text,
                Filepath = Filepath,
                // TODO Have to add VAlidation here
                Fee = int.Parse(CourseFee.Text)

            };
            ListItem.Add(list);
            if (CourseList.HasItems)
            {
                HeaderOfList.Visibility = Visibility.Collapsed;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // "cConfig.secure" = filename
            // type Should be type of DataModel Which has to Save.......
            SettingHelper helper = new SettingHelper();
            helper.SaveSettings(ListItem, "cConfig.secure", typeof(ObservableCollection<CoursesListItem>));
        }

        private void RetriveSetting()
        {
            // "cConfig.secure" = filename
            // type Should be type of DataModel Which has to retrived
            SettingHelper helper = new SettingHelper();
            ObservableCollection<CoursesListItem> item = helper.RetriveSettings("cConfig.secure", typeof(ObservableCollection<CoursesListItem>)) as ObservableCollection<CoursesListItem>;
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

        private void CourseEdit(object sender, RoutedEventArgs e)
        {
            Button Remove = sender as Button;
            CoursesListItem item = Remove.DataContext as CoursesListItem;
            DialogBox.IsOpen = true;
            CourseName.Text = item.CourseName;
            Description.Text = item.Description;
            CourseBatch.Text = item.AppliedTo;
            CourseCode.Text = item.CourseCode;
            CourseFee.Text = item.Fee.ToString();
            index = item.No;

            //change the content type of button to update
            AddNewCourse.Visibility = Visibility.Collapsed;
            UpdateButton.Visibility = Visibility.Visible;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            CoursesListItem newItem = new CoursesListItem();
            CoursesListItem item = new CoursesListItem();
            if (index != 0)
            {
                item.CourseName = CourseName.Text;
                item.CourseCode = CourseCode.Text;
                item.Description = Description.Text;
                item.AppliedTo = CourseBatch.Text;
                item.Fee = int.Parse(CourseFee.Text);
                item.No = index;
            }
        }

        // TODO
        private void CoursePrint(object sender, RoutedEventArgs e)
        {

        }

        // TODO
        private void CourseVeiw(object sender, RoutedEventArgs e)
        {

        }

        private void CourseDelete(object sender, RoutedEventArgs e)
        {
            Button Remove = sender as Button;
            CoursesListItem item = Remove.DataContext as CoursesListItem;
            if (ListItem.Count != 0)
            {
                // set item number dynamically
                ListItem.RemoveAt(item.No - 1);
            }
        }

        public String NewCourseName { get; set; }

        public String NewCourseFee { get; set; }

        public String NewCourseBatch { get; set; }
    }
}
