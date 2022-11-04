using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.MultithreadTest
{
    internal static class HTMLLoader
    {
        public static void Load()
        {
            string url = "https://www.dotnetfoundation.org";
            int count = 500;

            //Console.WriteLine(GetHtmlDS.ConsoleApp.MultithreadTest(url).Result);
            Console.WriteLine(GetFirstCharactersCountAsync(url, count).Result);
        }

        public static Task<string> GetHtmlAsync(string url)
        {
            // Execution is synchronous here
            var client = new HttpClient();

            return client.GetStringAsync(url);
        }

        public static async Task<string> GetFirstCharactersCountAsync(string url, int count)
        {
            // Execution is synchronous here
            var client = new HttpClient();

            // Execution of GetFirstCharactersCountDS.ConsoleApp.MultithreadTest() is yielded to the caller here
            // GetStringDS.ConsoleApp.MultithreadTest returns a Task<string>, which is *awaited*
            var page = await client.GetStringAsync("https://www.dotnetfoundation.org");

            // Execution resumes when the client.GetStringDS.ConsoleApp.MultithreadTest task completes,
            // becoming synchronous again.

            if (count > page.Length)
            {
                return page;
            }
            else
            {
                return page.Substring(0, count);
            }
        }
    }
}
