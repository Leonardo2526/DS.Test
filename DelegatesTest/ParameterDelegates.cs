using System;

namespace DelegatesTest
{
    static class ParameterDelegates
    {
        //static readonly Message? mes = null;
        //static readonly Message? mes = Hello;

        public static void Run()
        {
            Message? mes = Hello;
            mes -= Hello;
            mes?.Invoke(); // Hello

            Operation op = Add;
            op += Subtract;
            op += Multiply;
            int n = op.Invoke(3, 4);

            Console.WriteLine(n);   // 7
        }

        private static void Hello() => Console.WriteLine("Hello");

        private static int Add(int x, int y) => x + y;
        private static int Subtract(int x, int y) => x - y;
        private static int Multiply(int x, int y) => x * y;


        delegate int Operation(int x, int y);
        delegate void Message();
    }

   
}
