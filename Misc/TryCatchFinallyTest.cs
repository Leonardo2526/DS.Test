using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class TryCatchFinallyTest
    {
        public static void Run()
        {
            try
            {
                try
                {
                    Console.WriteLine("Executing the try statement.");
                    int x = 5;
                    int y = x / 0;
                    Console.WriteLine($"Результат: {y}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine("Возникло исключение!");
                }
                finally
                {
                    Console.WriteLine("Блок finally");
                }

                Console.WriteLine("End of the try statement");
            }

            catch { }

            Console.WriteLine("Конец программы");
            Console.ReadKey();
        }
    }
}
