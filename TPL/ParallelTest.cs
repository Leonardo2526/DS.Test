using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    static class ParallelTest
    {
        public static void Run()
        {
            // метод Parallel.Invoke выполняет три метода
            Parallel.Invoke(
                Print,
                () =>
                {
                    Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                    Thread.Sleep(3000);
                },
                () => Square(5)
            );

            void Print()
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            }
            // вычисляем квадрат числа
            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Результат {n * n}");
            }
        }

        public static void Run1()
        {
            // метод Parallel.Invoke выполняет три метода
            Parallel.Invoke(
               () => Square(5), Print
            );

            void Print()
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
            }
            // вычисляем квадрат числа
            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(3000);
                Console.WriteLine($"Результат {n * n}");
            }
        }

        public static void ParallelFor()
        {
            Parallel.For(1, 20, Square);

            // вычисляем квадрат числа
            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(2000);
                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
            }
        }

        public static void ParallelForEach()
        {
            ParallelLoopResult result = Parallel.ForEach<int>(
                   new List<int>() { 1, 3, 5, 8 },
                   Square
            );

            // вычисляем квадрат числа
            void Square(int n)
            {
                Console.WriteLine($"Выполняется задача {Task.CurrentId}");
                Thread.Sleep(2000);
                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
            }

            Console.WriteLine($"\nCompleted: { result.IsCompleted}");
        }

        public static void ParallelForEachPremature()
        {
            ParallelLoopResult result = Parallel.For(1, 10, Square1);
            if (!result.IsCompleted)
                Console.WriteLine($"Выполнение цикла завершено на итерации {result.LowestBreakIteration}");

            // вычисляем квадрат числа
            void Square(int n, ParallelLoopState pls)
            {
                if (n == 5) pls.Break();    // если передано 5, выходим из цикла

                Console.WriteLine($"Квадрат числа {n} равен {n * n}");
                Thread.Sleep(2000);
            }
        }

        static void Square1(int n, ParallelLoopState pls)
        {
            if (n == 3) pls.Break();    // если передано 5, выходим из цикла

            Console.WriteLine($"Квадрат числа {n} равен {n * n}");
            Thread.Sleep(2000);
        }
    }
}
