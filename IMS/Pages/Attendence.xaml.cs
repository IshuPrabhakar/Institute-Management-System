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

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for Attendence.xaml
    /// </summary>
    public partial class Attendence : Page
    {
        public List<AttendenceModel> ListItem { get; set; }
        public Attendence()
        {
            InitializeComponent();
            ListItem = new List<AttendenceModel>
            {
                new AttendenceModel
                {
                    No = 1,
                    StudentName = "Mrunpredictable",
                    RollNumber = "2001108010",
                    IsPresent = true,
                    Class = "BCA",

                }
            };

            AttendenceList.ItemsSource = ListItem;
        }

        private void HolidayType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(HolidayType.SelectedIndex + "\n");
            //Console.WriteLine(HolidayType.SelectedValue);
        }
    }
}
