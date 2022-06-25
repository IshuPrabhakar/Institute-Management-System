using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class FeeListItem
    {
        public int No { get; set; }

        public String FeeType { get; set; }

        private int _FeeAmount;

        public String FeeAmount
        {
            get { return _FeeAmount.ToString(); }
            set { _FeeAmount = int.Parse(value); }
        }

        public String AddedBy { get; set; }

        public Boolean ApplyToAll { get; set; }

        public Boolean ApplyFromCurrent { get; set; }

        public String Duration { get; set; }
    }
}
