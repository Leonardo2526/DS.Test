using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Windows.Shapes;

namespace Tracing
{
    internal class SerilogTest
    {
        private readonly Person _person;
        private readonly string[] _fruit;

        public SerilogTest()
        {
            _person = new Person() { name = "Bob", age = 20 };
            _fruit = new[] { "Apple", "Pear", "Orange" };

            CreateLogger();

            //JsonLog();
            DebugLog3();
            //LoadJson();

            Log.CloseAndFlush();
            //JsonParser1();
        }

        private void CreateLogger()
        {         
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Verbose()
            .WriteTo.Console()
         .WriteTo.Debug()
         .WriteTo.File("logs\\my_log.log", rollingInterval: RollingInterval.Day)
          //.WriteTo.RollingFile(new CompactJsonFormatter(), "./logs/app-{Date}.json", Serilog.Events.LogEventLevel.Information)      
          //.WriteTo.Http(uri, null)
         .CreateLogger();
        }

        private void DebugLog1()
        {
            Log.Debug("Foo started");
            // structured logging:
            Log.Debug("Requesting from URL {A} with {B}", "myUrl", "myPayload");

            Log.Information("In my bowl I have {@Fruit}", _fruit);

        }

        private void DebugLog2()
        {
            Log.Information("You are {@Name} of {@Age} age", _person.name, _person.age);
        }

        private void DebugLog3()
        {
            Log.Verbose("You are {@Person}", _person);
            Log.Logger.PostRequest(new HttpClient(), "addq", _person);
        }

        private void JsonLog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(new JsonFormatter(), "./logs/app-{Date}.json")
       .WriteTo.Console(new JsonFormatter())
       .WriteTo.Console(new CompactJsonFormatter())
       .CreateLogger();

            //Log.Information("Hello, {Name}", Environment.UserName);

            Log.Information("Processing {@Person}", _person.name);

            //var fruit = new[] { "Apple", "Pear", "Orange" };
            //Log.Information("In my bowl I have {Fruit}", fruit);

            Log.CloseAndFlush();
        }

        public void LoadJson()
        {
            using (StreamReader reader = new StreamReader("./logs/app-20230420_1.json"))
            {
                string json = reader.ReadToEnd();

                //dynamic array = JsonConvert.DeserializeObject(json);
                //foreach (var item in array)
                //{
                //    Console.WriteLine("{0} {1}", item.Name, item.Age);
                //}
                //JObject result = JObject.Parse(json);

                //foreach (var r in result["Person"])
                //{
                //    Console.WriteLine(r["@type"]);
                //    Console.WriteLine(r["AppId"]);
                //}

                Person item = JsonConvert.DeserializeObject<Person>(json);
                Console.WriteLine(item.name + " - " + item.age);
                //foreach (Person item in items)
                //{
                //}
            }
        }

        public static void JsonParser()
        {
            using (StreamReader reader = new StreamReader("./logs/app-20230420_many.json"))
            {
                string json = reader.ReadToEnd();
                dynamic array = JsonConvert.DeserializeObject(json, typeof(object));
                foreach (var item in array.collisions)
                {
                    Console.WriteLine("{0} {1}", item.el1Id, item.elName);
                    //Console.WriteLine("{0} {1}", item.Name, item.Age);
                }
            }
        }

        public static void JsonParser1()
        {
            using (StreamReader reader = new StreamReader("./logs/app-20230424.json"))
            {
                string json = reader.ReadLine();
                while(json != null)
                {                 
                    dynamic array = JObject.Parse(json);
                    foreach (var item in array)
                    {                 
                        if(item.Name == "Person")
                        {
                            string j = JsonConvert.SerializeObject(item.Value);
                            JObject result = JObject.Parse(j);
                            Person person = result.ToObject<Person>();
                            Console.WriteLine($"Name: {person.name}, Age: {person.age}");
                            //LogExt.HTTPClient(new HttpClient(), "addq", person);
                        }
                    }
                    json = reader.ReadLine();
                }
            }
        }
    }
}
