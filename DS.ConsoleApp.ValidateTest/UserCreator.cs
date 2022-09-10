using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.ValidateTest
{
    internal static class UserCreator
    {
        public static void CreateUser(string name, int age)
        {
            User user = new User(name, age);
            var context = new ValidationContext(user);
            var results = new List<ValidationResult>();
            if (!Validator.TryValidateObject(user, context, results, true))
            {
                Console.WriteLine("Не удалось создать объект User");
                foreach (var error in results)
                {
                    Console.WriteLine(error.ErrorMessage);
                }
                Console.WriteLine();
            }
            else
                Console.WriteLine($"Объект User успешно создан. Name: {user.Name}\n");
        }
    }
}
