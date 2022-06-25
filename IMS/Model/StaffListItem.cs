using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class StaffListItem : IDataErrorInfo
    {
        // InterFace
        public string this[string Property]
        {
            get
            {
                string error = String.Empty;
                switch (Property)
                {
                    case "StaffName":
                        if (string.IsNullOrEmpty(StaffName))
                            error = "Staff name is required!";
                        break;
                    case "Phone":
                        if (string.IsNullOrEmpty(Phone))
                            error = "Staff name is required!";
                        break;
                    case "Email":
                        if (string.IsNullOrEmpty(Email))
                            error = "Staff name is required!";
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get
            {
                return null;
            }
        }

        // DataModel members
        public int No { get; set; }

        public String StaffName { get; set; }

        public String StaffRole { get; set; }

        public String Email { get; set; }

        public String Phone { get; set; }

        public int Salary { get; set; }

        public Boolean CanLogin { get; set; }

        public String Filepath { get; set; }

    }
}
