using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        async static Task Main(string[] args)
        {
            //HTMLLoader.Load();
            //await NamePrinter.PrintAwait();
            await NamePrinter.PrintNoAwait();

            Console.ReadLine();
        }

    }
}
