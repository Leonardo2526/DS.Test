using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTest
{
    static class ReturnDelegate
    {
        enum OperationType
        {
            Add, Subtract, Multiply
        }

        delegate int Operation(int x, int y);

        public static void Run()
        {
            Operation operation = SelectOperation(OperationType.Add);
            Console.WriteLine(operation(10, 4));    // 14

            operation = SelectOperation(OperationType.Subtract);
            Console.WriteLine(operation(10, 4));    // 6

            operation = SelectOperation(OperationType.Multiply);
            Console.WriteLine(operation(10, 4));    // 40

            Operation SelectOperation(OperationType opType)
            {
                switch (opType)
                {
                    case OperationType.Add: return Add;
                    case OperationType.Subtract: return Subtract;
                    default: return Multiply;
                }
            }

            int Add(int x, int y) => x + y;
            int Subtract(int x, int y) => x - y;
            int Multiply(int x, int y) => x * y;
        }
    }
}
