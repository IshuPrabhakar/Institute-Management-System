using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Model;
using IMS.Model.HelperModel;

namespace IMS.Model
{
    public class Configurations
    {
        private string dATABASE_CONNECTION;

        public AccountConfigModel AccountConfiguration { get; set; }
        public FeeRelatedModel FeeRelatedConfiguration { get; set; }
        public GeneralConfigModel GeneralConfiguration { get; set; }
        public InstituteConfigModel InstituteConfiguration { get; set; }
        public UserListItem UserConfiguration { get; set; }
        public Staff StaffList { get; set; }
        public Course CoureseList { get; set; }
        public string DATABASE_CONNECTION_PATH
        {
            get => dATABASE_CONNECTION;
            set => dATABASE_CONNECTION = (Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\" + System.Diagnostics.Process.GetCurrentProcess().ProcessName + @"\IMS\DB").ToString();
        }

        public class Staff
        {
            public ObservableCollection<StaffListItem> Staffs { get; set; }
        }
        public class Course
        {
            public ObservableCollection<CoursesListItem> Courses { get; set; }
        }
    }
}
