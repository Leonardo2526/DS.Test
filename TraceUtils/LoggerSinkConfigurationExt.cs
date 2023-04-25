using Newtonsoft.Json.Linq;
using Serilog;
using Serilog.Configuration;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    internal static class HttpLog
    {
        public static void PostRequest(this ILogger logger, HttpClient httpClient, string path, Person person)
        {

            NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);
            queryString.Add("name", person.name);
            queryString.Add("age", person.age.ToString());

            string requestUri = "http://localhost:3000/" + path + "?" + queryString.ToString();

            // определяем данные запроса
            using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, requestUri);
            Console.WriteLine(request.RequestUri);

            // получаем ответ
            using HttpResponseMessage response = httpClient.SendAsync(request).Result;

            // просматриваем данные ответа
            // статус
            Console.WriteLine($"Status: {response.StatusCode}\n");

            // содержимое ответа
            Console.WriteLine("\nContent");
            string content = response.Content.ReadAsStringAsync().Result;
            Console.WriteLine(content);
        }
    }
}
