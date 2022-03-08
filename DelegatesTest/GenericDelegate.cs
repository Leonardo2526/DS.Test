using System;

namespace DelegatesTest
{
    static class GenericDelegate
    {
        delegate T Operation<T, K>(K val);

        public static void Run()
        {
            Operation<decimal, int> squareOperation = Square;
            decimal result1 = squareOperation(5);
            Console.WriteLine(result1);  // 25

            Operation<int, int> doubleOperation = Double;
            int result2 = doubleOperation(5);
            Console.WriteLine(result2);  // 10

            decimal Square(int n) => n * n;
            int Double(int n) => n + n;

        }
    }
}
