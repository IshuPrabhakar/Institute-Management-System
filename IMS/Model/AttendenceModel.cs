using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class AttendenceModel
    {
        public int No { get; set; }

        public string StudentName { get; set; }

        public string Class { get; set; }

        public string RollNumber { get; set; }

        public bool IsPresent { get; set; }

        public bool IsLeave { get; set; }

        public List<Previous> PreviousAttendenceHistory { get; set; }

        public class Previous
        {
            public bool IsPresent { get; set; }

            public bool IsLeave { get; set; }

            public string Date { get; set; }
        }
    }
}
