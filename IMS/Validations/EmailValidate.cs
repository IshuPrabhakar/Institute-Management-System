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
    public class EmailValidate : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string Check = value as string;
            string pattern = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            if (String.IsNullOrEmpty(Check))
            {
                return new ValidationResult(false, "This Field is required!");
            }else if (Regex.IsMatch(Check, pattern))
            {
                return new ValidationResult(true, null);
            }
            return new ValidationResult(false, "This is not a valid email address!");
        }

    }
}
