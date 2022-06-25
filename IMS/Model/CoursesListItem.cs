using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class CoursesListItem
    {
        public int No { get; set; }

        public String CourseName { get; set; }

        public String AddedDate { get; set; }

        public String AppliedTo { get; set; }

        public String Description { get; set; }

        public String CourseCode { get; set; }

        public int Fee { get; set; }

        public String Filepath { get; set; }


        // This was trial maybe implemented in new update of this app

        //public event PropertyChangedEventHandler PropertyChanged;

        //private void OnPropertyChanged(String property)
        //{
        //    if(PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(property));
        //    }
        //}
    }
}
