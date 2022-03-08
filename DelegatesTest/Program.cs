using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesTest
{
    class Program
    {
        delegate void Message();

        static void Main(string[] args)
        {
            //Run();
            //RunMultiiple();
            //ParameterDelegates.Run();
            //GenericDelegate.Run();
            ReturnDelegate.Run();
            Console.ReadLine();
        }

        static void Run()
        {

            Message message1 = Welcome.Print;
            Message message2 = new Hello().Display1;

            message1(); // Welcome
            message2(); // Привет

        }
        static void RunMultiiple()
        {

            Message message = Welcome.Print;
            message += new Hello().Display;

            message();

        }

    }



    class Welcome
    {
        public static void Print() => Console.WriteLine("Welcome");
    }
    class Hello
    {
        public void Display() => Console.WriteLine("Привет");
        public void Display1()
        {
            Console.WriteLine("Привет1");
        }
    }
}
