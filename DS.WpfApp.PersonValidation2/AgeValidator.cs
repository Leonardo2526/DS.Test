using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DS.ClassLib.VarUtils.Strings;
using DS.ClassLib.VarUtils;

namespace DS.WpfApp.PersonValidation2
{
    public class AgeValidator : ValidationRule
    {
        public override ValidationResult Validate
          (object value, System.Globalization.CultureInfo cultureInfo)
        {
            string? stringValue = value as string;

            if (String.IsNullOrEmpty(stringValue))
            {
                return new ValidationResult(false, "Значение не может быть нулевым.");
            }
            else if (!stringValue.IsInt())
            {
                return new ValidationResult(false, "Значение должно быть целым числом.");
            }

            int MaxValue = 1000;
            int MinValue = 10;

            int.TryParse(stringValue, out int intValue);
            if (!intValue.IsDevisible(10))
            {
                return new ValidationResult(false, "Значение должно быть кратным 10.");
            }
            else if (intValue < 10 || intValue > MaxValue)
            {
                return new ValidationResult(false, $"Значение должно быть в пределах от {MinValue} до {MaxValue}.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
