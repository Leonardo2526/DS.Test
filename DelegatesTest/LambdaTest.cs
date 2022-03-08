using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTest
{
    static class LambdaTest
    {
        delegate void Operation(int x, int y);
        public static void SumCalc()
        {
            Operation sum = (int x, int y) => Console.WriteLine($"{x} + {y} = {x + y}");
            sum(1, 2);       // 1 + 2 = 3
            sum(22, 14);    // 22 + 14 = 36
        }


        delegate void Message();
        public static void AddRemoveExp()
        {
            Message hello = () => Console.WriteLine("METANIT.COM");

            Message message = () => Console.Write("Hello ");
            message += () => Console.WriteLine("World"); // добавляем анонимное лямбда-выражение
            message += hello;   // добавляем лямбда-выражение из переменной hello
            message += Print;   // добавляем метод

            message();
            Console.WriteLine("--------------"); // для разделения вывода

            message -= Print;   // удаляем метод
            message -= hello;   // удаляем лямбда-выражение из переменной hello

            message?.Invoke();  // на случай, если в message больше нет действий

            void Print() => Console.WriteLine("Welcome to C#");
        }



        delegate bool IsEqual(int x);
        public static void LamdaArg()
        {
            int[] integers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // найдем сумму чисел больше 5
            int result1 = Sum(integers, x => x > 5);
            Console.WriteLine(result1); // 30

            // найдем сумму четных чисел
            int result2 = Sum(integers, x => x % 2 == 0);
            Console.WriteLine(result2);  //20

            int Sum(int[] numbers, IsEqual func)
            {
                int result = 0;
                foreach (int i in numbers)
                {
                    if (func(i))
                        result += i;
                }
                return result;
            }
        }
    }
}
