using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace IMS.Converters
{
    public class StudentsSerachParameters : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ComboBoxItem SelectedTerm = (ComboBoxItem)value;
            ComboBoxItem AdditionalParameter = new ComboBoxItem();

            List<string> l0 = new List<string>();
            List<string> l1 = new List<string>
            {
                "hi",
                "bye",
                "bro."
            };

            switch (SelectedTerm.Content)
            {
                case "Name":
                    return l1;

                default:
                    break;
            }
            return l0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
