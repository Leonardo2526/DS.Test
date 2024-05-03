using MoreLinq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Misc
{
    public static class OperatorOverloadTest
    {
        public static void Main(string[] args)
        {
            int a = 1;
            int b = 2;
            int c = 3;

            var A = (OpIntRec)a;
            var B = (OpIntRec)b;
            var C = (OpIntRec)c;
            //Console.WriteLine(A.Item);

            var items2 = new List<OpIntRec>() { B, C };
            var result = A + B;
            Console.WriteLine(result);

            int resultInt = (int)result;
            Console.WriteLine(resultInt);

            var A1 = (OpIntRec)a;
            Console.WriteLine(A.Equals(A1));
            Console.WriteLine(A == A1);

            Console.ReadLine();
        }
    }

    internal record OpIntRec(int Item)
    {
        public static explicit operator OpIntRec(int item) => new(item);
        public static explicit operator int(OpIntRec opIntRec) => opIntRec.Item;

        public static OpIntRec operator +(OpIntRec left, OpIntRec right)
        {
            var result = left.Item + right.Item;
            return new OpIntRec(result);
        }

        public static OpIntRec operator +(OpIntRec left, IEnumerable<OpIntRec> right)
        {
            var result = left.Item;
            right.ForEach(r => result += r.Item);
            return new OpIntRec(result);
        }

        public override string ToString()
        {
            return Item.ToString();
        }
    }

}
