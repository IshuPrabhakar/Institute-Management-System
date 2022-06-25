using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Model.HelperModel
{
    public class AccountConfigModel : INotifyPropertyChanged
    {
        public String EmailAddress { get; set; }

        public String Password { get; set; }

        public String Type { get; set; }

        public String Server { get; set; }

        public String Port { get; set; }

        public String AdminUserName { get; set; }

        public String AdminPassword { get; set; }

        public String AdminEmail { get; set; }

        public String AdminPhone { get; set; }

        public String AdminAddress { get; set; }

        public String ProductKey { get; set; }

        public String AdminDesignation { get; set; }

        public String AppAbout { get; set; }

        public String AppLicenseStatus { get; set; }

        public Boolean EnableAllNoti { get; set; }

        public Boolean EnableEmailNoti { get; set; }

        public Boolean EnableFB { get; set; }

        public Boolean EnableSite { get; set; }

        public Boolean EnableWA { get; set; }

        private String adminPictureURI;

        public String AdminPictureURI
        {
            get => adminPictureURI;
            set
            {
                if (adminPictureURI != null)
                {
                    adminPictureURI = value;
                    OnPropertyChanged("AdminPictureURI");
                }
            }
        }


        /// <summary>
        /// PropertyChanged event
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
