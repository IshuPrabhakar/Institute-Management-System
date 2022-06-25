using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model
{
    public class RequiredDocs
    {
        public int No { get; set; }

        public string Title { get; set; }

        public string URI { get; set; }

        public bool IsRequired { get; set; }

        public string AddedBy { get; set; }

        public string Date { get; set; }
    }
}
