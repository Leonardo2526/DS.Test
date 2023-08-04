using MoreLinq;
using System;
using System.Collections.Generic;

namespace Misc
{
    class Program
    {

        static void Main(string[] args)
        {

            var classTest1 = ClassTest1.GetInstance();
            classTest1.Name = "Test1";
            classTest1.TestEnum = new List<string>() { "1",  "2" };
            Console.WriteLine(classTest1.Name);

            var classTest2 = ClassTest2.GetInstance();
            classTest2.TestEnum.ForEach(x => Console.WriteLine("id " +x));
            Console.WriteLine("classTest2: " + classTest2.Name);
            classTest2.Name = "Test2";
            Console.WriteLine("classTest2: " + classTest2.Name);

            Console.ReadLine();
        }

        static int GetIndex(string line)
        {
            string symb = "|";
            int charLocation = line.IndexOf(symb, StringComparison.Ordinal);

            return charLocation;
        }
    }

    public class TestClass
    {
        private string _s;

        public TestClass(string s)
        {
            _s = s;
        }

        public string Prop1 => GetString();

        private string GetString()
        {
            var s = "GetString";
            Console.WriteLine(s);

            return s;
        }

        public void Change()
        {
            _s = "new s";
        }
    }

}
