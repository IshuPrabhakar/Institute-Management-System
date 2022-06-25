using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model.HelperModel
{
    public class FeeRelatedModel
    {
        public String StudentName { get; set; }

        public String StudentRoll { get; set; }

        public String ParentsName { get; set; }

        public String Class { get; set; }

        public String TotalFeePaid { get; set; }

        public String TotalFeeRemaining { get; set; }

        public String Total { get; set; }

        public ObservableCollection<FeeListItem> ListItem { get; set; }

        public String InstituteName { get; set; }

        public String InstituteAddess { get; set; }

        public String ImagePath { get; set; }
    }
}
