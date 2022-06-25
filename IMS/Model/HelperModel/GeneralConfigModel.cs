using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model.HelperModel
{
    public class GeneralConfigModel
    {
        public String InstituteName { get; set; }

        public String InstituteAddress { get; set; }

        public String InstitutePhone { get; set; }

        public String InstitueEmail { get; set; }

        public String InstituteCode { get; set; }

        public String EstablishmentYear { get; set; }

        public String Description { get; set; }

        public String DiceCode { get; set; }

        public String WebsiteURL { get; set; }

        public String WhatsAppURL { get; set; }

        public String FacebookURL { get; set; }

        public bool IsSocialURLEnabled { get; set; }

        public String InstituteProfileURL { get; set; }
    }
}
