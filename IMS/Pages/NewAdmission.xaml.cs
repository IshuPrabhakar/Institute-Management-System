using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SQLite;
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
using IMS.Model;

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for NewAdmission.xaml
    /// </summary>
    public partial class NewAdmission : Page
    {
        public string SBatch { get; set; }
        public ObservableCollection<RequiredDocs> RequiredDocs { get; set; }

        public NewAdmission()
        {
            RequiredDocs = new ObservableCollection<RequiredDocs>();
            RequiredDocs.Add(new RequiredDocs
            {
                No = 1,
                Title = "10TH Marksheet",
                URI = "NOT SET",
                IsRequired = true
            });

            InitializeComponent();
            //GetBatch("Batch","InstituteSettings");
        }

        private void GetBatch(string ColumnName, string TableName)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);
                connection.Open();
                String Query = "SELECT " + ColumnName + " From " + TableName + "";
                SQLiteCommand command = new SQLiteCommand(Query, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    SBatch = dataReader.GetString(0);
                    StudentBatch.Items.Add(SBatch);
                }
                connection.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Something went Wrong, Try Again!\n" + ex.Message);
            }
        }

        private void DocUpload10Th_Click(object sender, RoutedEventArgs e)
        {
            //DocUpload10Th.Visibility = Visibility.Hidden;
            //Progressbar.Visibility = Visibility.Visible;
           
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            //SaveStudent();
        }

        //private void SaveStudent()
        //{
        //    try
        //    {
        //        SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);
        //        connection.Open();
        //        String Query = "INSERT INTO StudentInfo (Name, Class, Subject, Address, MobileNo, FathersName, MothersName, Gender,  AppliedFor, DOB, Pincode, District, '10TH', '12TH', Graduation, Subject10TH, Subject12TH, SubjectsGraduation, Category, Board10Th, Board12Th, University, Batch) " +
        //                       "VALUES('" + StudentName.Content + "','"+ StudentAppliedFor.Text  +"','" + StudentAppliedFor.Text + "', '"+ StudentAddress.Text +"', '"+ StudentPhoneNo.Text +"', '"+ StudentFathersName.Text +"', '"+ StudentMothersName.Text +"', '"+ StudentGender.Text +"', '"+ StudentAppliedFor.Text + "', '"+ StudentDOB.Text +"'" + ",'"+ StudentPincode.Text +"','"+ StudentDistrict.Text +"','"+ Student10THPercent.Text +"','"+ Student12THPercent.Text + "','"+ StudentGraduationPercent.Text +"','"+ Student10THSub.Text +"','"+ Student12THSub.Text +"','"+StudentGraduationSub.Text+"','"+ StudentCategory.Text +"','"+ Student10THBoard.Text  +"','" + Student12THBoard.Text + "','"+ StudentGraduationBoard.Text + "','"+ StudentBatch.SelectedItem.ToString() +"')";
        //        SQLiteCommand command = new SQLiteCommand(Query, connection);
        //        command.ExecuteNonQuery();

        //        connection.Close();
        //    }

        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Something went Wrong, Try Again!\n" + ex.Message);
        //    }
        //}
    }
}
