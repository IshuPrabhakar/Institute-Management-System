using IMS.Model.HelperModel;
using IMS.Pages;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace IMS.Template
{
    /// <summary>
    /// Interaction logic for FeeReceipt.xaml
    /// </summary>
    public partial class FeeReceipt : Page
    {
        public static string date;

        public FeeReceipt()
        {
            InitializeComponent();
            StartClock();
        }

        private void StartClock()
        {
            DispatcherTimer dateTime = new DispatcherTimer();
            dateTime.Interval = TimeSpan.FromSeconds(1);
            dateTime.Tick += tickevent;
            dateTime.Start();
        }

        private void tickevent(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            date = DateTime.Now.ToString();
            DateBox.Text = date;
            //loaddata();
        }

        public void Retrivedata(FeeRelatedModel feeModel)
        {
            
        }

        //private void loaddata()
        //{

        //    NameBox.Text = FeePage.PreStuName;
        //    ClassBox.Text = FeePage.PreClass;
        //    RelationBox.Text = FeePage.PreParName;
        //    RollnoBox.Text = FeePage.PreRoll.ToString();
        //    TotalBox.Text = FeePage.TotalFee;
        //    PreAdFee.Text = FeePage.FeeAd;
        //    PreTuFee.Text = FeePage.FeeTu;
        //    PreExtraFee.Text = FeePage.FeeExt;
        //    PreSemFee.Text = FeePage.FeeSem;
        //    PreExamFee.Text = FeePage.FeeEx;
        //    PreLabFee.Text = FeePage.Feela;
        //}

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);

            try
            {
                connection.Open();
                String Query = "SELECT UserImage,InstitutionName,Address FROM Credential WHERE ID=1";
                SQLiteCommand command = new SQLiteCommand(Query, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string bgImage64 = dataReader.GetString(0);
                    InstitutionName.Text = dataReader.GetString(1);
                    InstitutionAddress.Text = dataReader.GetString(2);


                    byte[] binaryData = Convert.FromBase64String(bgImage64);
                    BitmapImage bi = new BitmapImage();
                    bi.BeginInit();
                    bi.StreamSource = new MemoryStream(binaryData);
                    bi.EndInit();

                    Image img = new Image();
                    PreviewWindowProfilePicture.Source = bi;
                }
                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something went Wrong please Restart your Application\n" + ex.Message);
            }
        }
    }
}
