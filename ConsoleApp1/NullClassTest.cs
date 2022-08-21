using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.Net6Test
{
    internal static class NullClassTest
    {

        internal static void TestReferenceType()
        {
            string message = null;
            SayHi(message);
        }

        internal static void TestReferenceType1()
        {
            string? message = null;
            SayHi(message!);
        }

        static void SayHi(string message)
        {
            Console.WriteLine($"Hello {message}");
        }

      
        internal static void TestValueType()
        {
            int? val = null;
            IsNull(val);
            val = 22;
            IsNull(val);
        }

        static void IsNull(int? obj)
        {
            if (obj == null) Console.WriteLine("null");
            else Console.WriteLine(obj);
        }

        internal static void TestValueType1()
        {
            int? number = null; // если значения нет, метод возвращает значение по умолчанию
            Console.WriteLine(number.GetValueOrDefault());      // 0  - значение по умолчанию для числовых типов
            Console.WriteLine(number.GetValueOrDefault(10));    // 10

            number = 15;    // если значение задано, оно возвращается методом
            Console.WriteLine(number.GetValueOrDefault());    // 15
            Console.WriteLine(number.GetValueOrDefault(10));  // 15
        }

        internal static void TestValueType2()
        {
            int? x1 = null;
            if (x1.HasValue)
            {
                int x2 = (int)x1;
                Console.WriteLine(x2);
            }
            else
            {
                Console.WriteLine("параметр равен null");
            }
        }
    }
}
