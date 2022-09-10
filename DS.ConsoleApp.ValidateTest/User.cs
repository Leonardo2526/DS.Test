using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.ValidateTest
{
    public class User
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        [Range(1, 100)]
        public int Age { get; set; }

        public User(string name, int age)
        {
            Name = name;
            Age = age;
        }       
    }

  

}
