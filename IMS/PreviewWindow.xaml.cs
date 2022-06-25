using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.SQLite;
using Microsoft.Win32;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using IMS.Template;
using IMS.Pages;

namespace IMS
{
    /// <summary>
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        public PreviewWindow()
        {
            InitializeComponent();
            //PreviewFrame.Navigate(new Uri(navigationcmd, UriKind.RelativeOrAbsolute));
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Minimise_Button(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
            else if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Minimized;
            }
        }

        //private void PrintButton_Click(object sender, RoutedEventArgs e)
        //{
        //    if (FeePage.Test != true)
        //    {

        //        try
        //        {
        //            AdmissionForm admission = new AdmissionForm();

        //            PrintDialog printForm = new PrintDialog();
        //            if (printForm.ShowDialog() == true)
        //            {
        //                printForm.PrintVisual(PreviewFrame, "FormTest");
        //            }
        //        }
        //        catch
        //        {
        //            MessageBox.Show("An Error ocurred");
        //        }
        //    }
        //    else
        //    {
        //        try
        //        {
        //            AdmissionForm admission = new AdmissionForm();

        //            PrintDialog printForm = new PrintDialog();
        //            if (printForm.ShowDialog() == true)
        //            {
        //                printForm.PrintVisual(PreviewFrame, "FormTest");
        //            }
        //        }
        //        catch
        //        {
        //            MessageBox.Show("An Error ocurred");
        //        }

        //        try
        //        {
        //            double newtotal;
        //            double total = FeePage.PreTotalFeePaid;
        //            double.TryParse(FeePage.TotalFee, out newtotal);
        //            total = total + newtotal;

        //            SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);
        //            connection.Open();
        //            String Query = " UPDATE StudentInfo SET TotalPaid = '"+ total + "' WHERE ID= "+ FeePage.PreRoll +"";

        //            SQLiteCommand command = new SQLiteCommand(Query, connection);
        //            command.ExecuteNonQuery();
        //            connection.Close();
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message + "Updating the database error (1)");
        //        }

        //        try
        //        {
        //            SQLiteConnection connection = new SQLiteConnection(MainWindow.ConnectionString);
        //            connection.Open();
        //            String Query = "INSERT INTO Transactions(Name, Date, Amount, RollNo) VALUES " +
        //                "('" + FeePage.PreStuName + "','" + FeeReceipt.date + "','" + FeePage.TotalFee + "'," + FeePage.PreRoll + ")";

        //            SQLiteCommand command = new SQLiteCommand(Query, connection);
        //            command.ExecuteNonQuery();
        //            connection.Close();

        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message + "Updating the database error");
        //        }
        //    }
        //}

    }
}
