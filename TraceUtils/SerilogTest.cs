using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Tracing
{
    internal class SerilogTest
    {
        public SerilogTest()
        {
            Log.Logger = new LoggerConfiguration()
           .MinimumLevel.Debug()
           .WriteTo.Console()
           .WriteTo.File("logs\\my_log.log", rollingInterval: RollingInterval.Day)
           .CreateLogger();

            JsonLog();
        }


        private void Run()
        {
            Log.Debug("Foo started");            
            // structured logging:
            Log.Debug("Requesting from URL {A} with {B}", "myUrl", "myPayload");

            var fruit = new[] { "Apple", "Pear", "Orange" };
            Log.Information("In my bowl I have {Fruit}", fruit);
        }

        private void JsonLog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.RollingFile(new CompactJsonFormatter(), "./logs/app-{Date}.json")
       .WriteTo.Console(new JsonFormatter())
       .WriteTo.Console(new CompactJsonFormatter())
       .CreateLogger();

            Log.Information("Hello, {Name}", Environment.UserName);

            Log.CloseAndFlush();
        }
    }
}
