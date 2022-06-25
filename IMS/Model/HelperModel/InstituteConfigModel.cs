using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model.HelperModel
{
    public class InstituteConfigModel : INotifyPropertyChanged
    {
        private string rollNumberPrefix;
        private string enrollmentPrefix;
        private string reciptPrefix;
        private string admissionPrefix;
        private bool autoIncrement;
        private bool logoOnReciptAndAdmission;

        public ObservableCollection<StudentSession> Sessions { get; set; }
        public ObservableCollection<EductionalDetails> EducationalDetailsList { get; set; }
        public ObservableCollection<RequiredDocs> RequiredDocumentsList { get; set; }


        public string RollNumberPrefix { get => rollNumberPrefix; set { rollNumberPrefix = value; OnPropertyChanged("rollNumberPrefix"); } }

        public string EnrollmentPrefix { get => enrollmentPrefix; set { enrollmentPrefix = value; OnPropertyChanged("enrollmentPrefix"); } }

        public string ReciptPrefix { get => reciptPrefix; set { reciptPrefix = value; OnPropertyChanged("reciptPrefix"); } }

        public string AdmissionPrefix { get => admissionPrefix; set { admissionPrefix = value; OnPropertyChanged("admissionPrefix"); } }

        public bool AutoIncrement { get => autoIncrement; set { autoIncrement = value; OnPropertyChanged("autoIncrement"); } }

        public bool LogoOnReciptAndAdmission { get => logoOnReciptAndAdmission; set { logoOnReciptAndAdmission = value; OnPropertyChanged("logoOnReciptAndAdmission"); } }



        // INOTIFY INTERFACE IMPLEMENTAION
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
