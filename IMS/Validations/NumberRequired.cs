using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace IMS.Validations
{
    public class NumberRequired : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string Check = value as string;
            if (String.IsNullOrEmpty(Check))
            {
                return new ValidationResult(false, "This Field is required!");
            }
            else if (Regex.IsMatch(Check,@"\d"))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "Only numbes are allowed!");
        }
    }
}
