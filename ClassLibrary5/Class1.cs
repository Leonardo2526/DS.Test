using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Sinks.MongoDB;
using Serilog.Formatting.Compact;
using Serilog.Formatting.Json;

using System;
using System.Collections;
using System.IO;

namespace ClassLibrary5
{
    public class Class1
    {
        void Run()
        {
            var builder = new ConfigurationBuilder()
              .AddJsonFile(@"Appsettings.json");

            var configuration = builder.Build();

            // use Bson structured logs
            var log1 = new LoggerConfiguration()
                .WriteTo.MongoDBBson("mongodb://mymongodb/logs")
                .CreateLogger();

            Action<MongoDBSinkConfiguration> action = (a) => { };
            void add(MongoDBSinkConfiguration m) => new MongoDBSinkConfiguration();

            var cfg = new MongoDBSinkConfiguration();
            //new LoggerConfiguration().WriteTo.MongoDBBson("", add).CreateLogger();

            //cfg.SetConnectionString(databaseUrl);
            //cfg.SetBatchPostingLimit(batchPostingLimit);
            //if (period.HasValue) cfg.SetBatchPeriod(period.Value);
            //cfg.SetCollectionName(collectionName);

            //capped collection using Bson structured logs
            //var log = new LoggerConfiguration()
            //    .WriteTo.MongoDBBson("mongodb://mymongodb/logs", cfg =>
            //    {
            //        // optional configuration options:
            //        cfg.SetCollectionName("log");
            //        cfg.SetBatchPeriod(TimeSpan.FromSeconds(1));

            //        // create capped collection that is max 100mb
            //        cfg.SetCreateCappedCollection(100);
            //    })
            //    .CreateLogger();
        }

        void Test()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath("ContentRootPath")
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{"EnvironmentName"}.json", optional: true);
          
            var Configuration = builder.Build();

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.RollingFile(Path.Combine("ContentRootPath", "C:\\logs\\log-{Date}.txt"),
                                outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] [{SourceContext}] [{EventId}] {Message}{NewLine}{Exception}")
                .ReadFrom.Configuration(Configuration)
                .CreateLogger();

            Log.Logger.Information("test");
        }
    }
}
