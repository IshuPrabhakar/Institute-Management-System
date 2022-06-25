using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using IMS.Pages;

namespace IMS.Template
{
    /// <summary>
    /// Interaction logic for AdmissionForm.xaml
    /// </summary>
    public partial class AdmissionForm : Page
    {
        public AdmissionForm()
        {
            InitializeComponent();
        }

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
                MessageBox.Show("Something went Wrong please Restart your Application\n This" + ex.Message);
            }

            NameBox.Text = Student.StuName;
            AddressBox.Text = Student.StuAddress;
            MobileBox.Text = Student.StuMobile;
            FathersNameBox.Text = Student.StuFathersname;
            MothersNameBox.Text = Student.StuMothersname;
            GenderBox.Text = Student.StuGender;
            ProgrammeNameBox.Text = Student.StuProgrammename;
            DOBBox.Text = Student.StuDOB;
            PincodeBox.Text = Student.StuPincode;
            StateBox.Text = Student.StuState;
            BoardorUniversity10TH.Text = Student.StuBoardorUniversity10TH;
            BoardorUniversity12TH.Text = Student.StuBoardorUniversity12TH;
            Subjects10TH.Text = Student.StuSubjects10TH;
            Subjects12TH.Text = Student.StuSubjects12TH;
            Pecentage10TH.Text = Student.StuPecentage10TH;
            Pecentage12TH.Text = Student.StuPecentage12TH;
            BoardorUniversityGraduation.Text = Student.StuBoardorUniversityGraduation;
            SubjectsGraduation.Text = Student.StuSubjectsGraduation;
            PecentageGraduation.Text = Student.StuPecentageGraduation;
            CategoryBox.Text = Student.StuCategory;

        }
    }
}
