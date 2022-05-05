using System;
using System.ComponentModel;
using System.Windows;

namespace DS.WpfApp.PersonValidation
{
    public class PersonModel : IDataErrorInfo
    {
        public string Name { get; set; }

        private int age;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Position { get; set; }
        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
                switch (columnName)
                {
                    case "Age":
                        if ((Age < 0) || (Age > 100))
                        {
                            error = "Возраст должен быть больше 0 и меньше 100";
                            MessageBox.Show(error);
                        }
                        if (Age.GetType() != typeof(int))
                        {
                            error = "Неверный тип данных";
                        }
                        break;
                    case "Name":
                        //Обработка ошибок для свойства Name
                        break;
                    case "Position":
                        //Обработка ошибок для свойства Position
                        break;
                }

                if (error != String.Empty)
                {
                    MessageBox.Show(error);
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
    }
}
