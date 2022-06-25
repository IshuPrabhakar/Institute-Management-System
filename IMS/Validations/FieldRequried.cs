using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IMS.Validations
{
    public class FieldRequried : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string Check = value as string;
            return String.IsNullOrEmpty(Check) ? new ValidationResult(false, "This field cannot be empty") : new ValidationResult(true, null);
        }
    }
}
