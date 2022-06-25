using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS.Model;

namespace IMS.Model
{
    public class NewAdd
    {
        public string Batch { get; set; }

        public string AdmissionType { get; set; }

        public string ImageURI { get; set; }

        public string Name { get; set; }

        public string FathersName { get; set; }

        public string MothersName { get; set; }

        public string AplliedFor { get; set; }

        public string DOB { get; set; }

        public string Gender { get; set; }

        public string Nationality { get; set; }

        public string Category { get; set; }

        public string MaritalStatus { get; set; }

        public ObservableCollection<EductionalDetails> Education { get; set; }

        ////public string TenthBoard { get; set; }

        ////public string TwelveBoard { get; set; }

        ////public string TenthPercent { get; set; }

        ////public string TwelvePercent { get; set; }

        ////public string GraduationBoard { get; set; }

        ////public string GraduationPercent { get; set; }

        ////public string TenthSubjects { get; set; }

        ////public string TwelveSubjects { get; set; }

        ////public string GradutionSubject { get; set; }

        public string Address { get; set; }

        public string Pincode { get; set; }

        public string District { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ParentPhone { get; set; }

        public ObservableCollection<RequiredDocs> Docs { get; set; }

        ////public string TenthURI { get; set; }

        ////public string TwelveURI { get; set; }

        ////public string MigrationURI { get; set; }

        ////public string CasteCirtificateURI { get; set; }

        ////public string CharacterCirtificate { get; set; }
    }
}
