using IMS.Template;
using System;
using System.Data;
using System.Data.SQLite;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for Student.xaml
    /// </summary>
    public partial class Student : Page
    {
        public static string StuName;
        public static string StuAddress;
        public static string StuMobile;
        public static string StuFathersname;
        public static string StuMothersname;
        public static string StuGender;
        public static string StuReligion;
        public static string StuProgrammename;
        public static string StuDOB;
        public static string StuPincode;
        public static string StuState;
        public static string StuBoardorUniversity10TH;
        public static string StuBoardorUniversity12TH;
        public static string StuSubjects10TH;
        public static string StuSubjects12TH;
        public static string StuPecentage10TH;
        public static string StuPecentage12TH;
        public static string StuBoardorUniversityGraduation;
        public static string StuSubjectsGraduation;
        public static string StuPecentageGraduation;
        public static string StuCategory;

        public Student()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Thread thread1 = new Thread(new ThreadStart(LoadData));
            thread1.Start();
        }

        private void LoadData()
        {
            this.Dispatcher.Invoke(() =>
            {
                SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);  // this will open connection for the database

                try
                {
                    connection.Open();
                    String Query = "SELECT ID,Name,Class,Subject,Address,MobileNo FROM StudentInfo";
                    SQLiteCommand command = new SQLiteCommand(Query, connection);

                    SQLiteDataAdapter dataAdapter = new SQLiteDataAdapter(command);

                    DataTable table = new DataTable("Student");
                    dataAdapter.Fill(table);

                    StudentDataGrid.AutoGenerateColumns = false;
                    StudentDataGrid.ItemsSource = table.DefaultView;

                    connection.Close();
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Something went Wrong please Restart your Application \n\nstudent\n" + ex.Message);
                }
            });
        }

        private void DetailView_Click(object sender, RoutedEventArgs e)
        {
            DataRowView ColunmView = (DataRowView)((Button)e.Source).DataContext;
            string SelectedRow = ColunmView[1].ToString();

            //PreviewWindow preview = new PreviewWindow("Template/AdmissionForm.xaml");
            //preview.Show();
            //FeePage.Test = false;

            AdmissionForm admission = new AdmissionForm();


            String Query = "SELECT * FROM StudentInfo where name= '" + SelectedRow + "'";
            SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);

            //try
            //{
                connection.Open();

                SQLiteCommand command = new SQLiteCommand(Query, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    StuName = dataReader.GetString(1);
                    StuAddress = dataReader.GetString(4);
                    StuMobile = dataReader.GetString(5);
                    StuFathersname = dataReader.GetString(7);
                    StuMothersname = dataReader.GetString(8);
                    StuGender = dataReader.GetString(9);
                    StuReligion = dataReader.GetString(10);
                    StuProgrammename = dataReader.GetString(10);
                    StuDOB = dataReader.GetString(11);
                    StuPincode = dataReader.GetInt32(12).ToString();
                    StuState = dataReader.GetString(14);
                    StuBoardorUniversity10TH = dataReader.GetString(21);
                    StuBoardorUniversity12TH = dataReader.GetString(22);
                    StuSubjects10TH = dataReader.GetString(18);
                    StuSubjects12TH = dataReader.GetString(19);
                    StuPecentage10TH = dataReader.GetString(15);
                    StuPecentage12TH = dataReader.GetString(16);
                    StuBoardorUniversityGraduation = dataReader.GetString(23);
                    StuSubjectsGraduation = dataReader.GetString(23);
                    StuPecentageGraduation = dataReader.GetString(17);
                    StuCategory = dataReader.GetString(20);
                }

                connection.Close();
            //}

            //catch (Exception ex)
            //{
            //    MessageBox.Show("Something went Wrong please Restart your Application\n\nstudent details\n" + ex.Message);
            //}
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //PreviewWindow preview = new PreviewWindow("Template/FeeReceipt.xaml");
            //preview.Show();

        }

        private void SearchBy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(SearchBy.Text);
        }

        //PreviewWindow preview = new PreviewWindow();
        //preview.Show();

        //    //GridView values to Preview Window

        //    DataRowView ColunmView = (DataRowView)((Button)e.Source).DataContext;

        //preview.NameBox.Text = ColunmView[1].ToString();
        //preview.ProgrammeNameBox.Text = ColunmView[2].ToString();
        //preview.MothersNameBox.Text = ColunmView[8].ToString();
        //preview.AddressBox.Text = ColunmView[4].ToString();
        //preview.MobileBox.Text = ColunmView[5].ToString();
    }
}
