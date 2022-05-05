using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace DS.WpfApp.PersonValidation2
{
    public class AgeValidator : ValidationRule
    {
        public override ValidationResult Validate
          (object value, System.Globalization.CultureInfo cultureInfo)
        {
            if (String.IsNullOrEmpty(value.ToString()))
                return new ValidationResult(false, "value cannot be empty.");
            else
            {
                if (value.GetType() != typeof(int) || value.ToString().Contains(" "))
                {
                    return new ValidationResult(false, "Неверный тип данных");
                }
                if (value.ToString().Length > 3)
                    return new ValidationResult
                    (false, "Name cannot be more than 3 characters long.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
