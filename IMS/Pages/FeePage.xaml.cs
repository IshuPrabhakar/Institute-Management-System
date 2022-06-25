using IMS.Helpers;
using IMS.Model;
using IMS.Model.HelperModel;
using IMS.Template;
using System;
using System.Collections.ObjectModel;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace IMS.Pages
{
    /// <summary>
    /// Interaction logic for FeePage.xaml
    /// </summary>
    public partial class FeePage : Page
    {
        public ObservableCollection<FeeListItem> ListItem { get; set; }

        public FeePage()
        {
            ListItem = new ObservableCollection<FeeListItem>();

            InitializeComponent();
            //StartClock();
            StudentSelectComboBox();

            RetriveSetting();

            // To check Whether the is empty or not if empty
            // it will not show the list empty messege
            if (FeeList.HasItems)
            {
                HeaderOfList.Visibility = Visibility.Collapsed;
            }
        }

        //private void StartClock()
        //{
        //    DispatcherTimer dateTime = new DispatcherTimer();
        //    dateTime.Interval = TimeSpan.FromSeconds(1);
        //    dateTime.Tick += tickevent;
        //    dateTime.Start();
        //}

        //private void tickevent(object sender, EventArgs e)
        //{
        //    //throw new NotImplementedException();
        //    FeeDateBox.Text = DateTime.Now.ToString();

        //    Int32 adfee, tutionfee, extrafee, semfee, examfee, labfee, totalfee;

        //    Int32.TryParse(FeeAdmission.Text, out adfee);
        //    Int32.TryParse(Feetution.Text, out tutionfee);
        //    Int32.TryParse(FeeExtra.Text, out extrafee);
        //    Int32.TryParse(FeeSemester.Text, out semfee);
        //    Int32.TryParse(FeeExam.Text, out examfee);
        //    Int32.TryParse(FeeLab.Text, out labfee);

        //    totalfee = adfee + tutionfee + extrafee + semfee + examfee + labfee;
        //    FeeTotal.Text = totalfee.ToString();
        //    TotalFee = totalfee.ToString();

        //    FeeAd = adfee.ToString();
        //    FeeTu = tutionfee.ToString();
        //    FeeExt = extrafee.ToString();
        //    FeeSem = semfee.ToString();
        //    FeeEx = examfee.ToString();
        //    Feela = labfee.ToString();

        //}

        private void StudentSelectComboBox()
        {
            SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);

            try
            {
                connection.Open();
                String Query = "SELECT Name FROM StudentInfo";
                SQLiteCommand command = new SQLiteCommand(Query, connection);
                SQLiteDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    string StuName = dataReader.GetString(0);
                    SelectStudentName.Items.Add(StuName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RetriveSetting()
        {
            // "fConfig.secure" = filename
            // type Should be type of DataModel Which has to retrived
            SettingHelper helper = new SettingHelper();
            ObservableCollection<FeeListItem> item = helper.RetriveSettings("fConfig.secure", typeof(ObservableCollection<FeeListItem>)) as ObservableCollection<FeeListItem>;
            foreach (var i in item)
            {
                ListItem.Add(i);
            }
        }

        private void SelectStudentName_DropDownClosed(object sender, EventArgs e)
        {
            //double fee_remain;
            //double.TryParse(Settings.chargedfee, out fee_remain);

            //SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);

            //try
            //{
            //    connection.Open();
            //    String Query = "SELECT ID, FathersName, Class, TotalPaid FROM StudentInfo WHERE Name='" + SelectStudentName.Text + "'";
            //    SQLiteCommand command = new SQLiteCommand(Query, connection);
            //    SQLiteDataReader dataReader = command.ExecuteReader();

            //    while (dataReader.Read())
            //    {
            //        PreRoll = dataReader.GetInt32(0);
            //        PreParName = dataReader.GetString(1);
            //        PreClass = dataReader.GetString(2);
            //        PreTotalFeePaid = dataReader.GetInt32(3);

            //        FeeRollnoBox.Text = PreRoll.ToString();
            //        FeeParentName.Text = PreParName;
            //        FeeClassBox.Text = PreClass;
            //        TotalFeePaidBox.Text = PreTotalFeePaid.ToString();
            //    }

            //    FeeRemainingBox.Text = (fee_remain - PreTotalFeePaid).ToString();
            //    PreStuName = SelectStudentName.Text;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void ContinueButton_Click(object sender, RoutedEventArgs e)
        {
            //FeeRelatedModel feeModel = new FeeRelatedModel
            //{
            //    StudentName = SelectStudentName.Text,
            //    ParentsName = ParentName.Text,
            //    StudentRoll = Rollno.Text,
            //    Class = StudentClass.Text,
            //    TotalFeeRemaining = FeeRemaining.Text,
            //    TotalFeePaid = TotalFeePaidBox.Text,
            //    ListItem = ListItem,
            //};
            //FeeReceipt receipt = new FeeReceipt();
            //receipt.Retrivedata(feeModel);
            PreviewWindow preview = new PreviewWindow();
            //PreviewWindow preview = new PreviewWindow("Template/FeeReceipt.xaml");
            preview.Show();
        }

        //private void Feetution_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    double tutionfee = System.Convert.ToDouble(Feetution.Text);

        //    double admissionfee = System.Convert.ToDouble(FeeAdmission.Text);
        //    double examfee = System.Convert.ToDouble(FeeExam.Text);
        //    double extrafee = System.Convert.ToDouble(FeeExtra.Text);
        //    double labfee = System.Convert.ToDouble(FeeLab.Text);
        //    double Semesterfee = System.Convert.ToDouble(FeeSemester.Text);

        //    double Totalfees = (tutionfee + admissionfee + examfee + extrafee + labfee + Semesterfee);
        //    FeeTotal.Text = Totalfees.ToString();
        //}
    }
}
