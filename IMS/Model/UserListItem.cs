using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class UserListItem
    {
        public int No { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public Boolean CanManageStudent { get; set; }

        public Boolean CanManageTransaction { get; set; }

        public Boolean CanChangeSettings { get; set; }

        public Boolean HasAllPreveledge { get; set; }
    }
}
