using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace IMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Bold.Licensing.BoldLicenseProvider.RegisterLicense("+HFUsT9QYwalTxJn/a9pz/6ByNYot8eA6j2wPO0tPjo=");
        }
    }
}
