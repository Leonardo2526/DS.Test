using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.AutofacTest.Writer
{
    public interface IDateWriter
    {
        void WriteDate();
    }

    public class TodayWriter : IDateWriter
    {
        private IOutput _output;
        public TodayWriter(IOutput output)
        {
            this._output = output;
        }

        public void WriteDate()
        {
            this._output.Write(DateTime.Today.ToShortDateString());
        }
    }

    public class TodayWriter1 : IDateWriter
    {

        public void WriteDate()
        {
            var builder = new ContainerBuilder();
            builder.RegisterInstance(new ConsoleOutput1("123")).As<IOutput>();
            var container = builder.Build();  

            using (var scope = container.BeginLifetimeScope())
            {
                var output = scope.Resolve<IOutput>();
                output.Write(DateTime.Today.ToShortDateString() +$" {this.GetType().Name}");
            }

        }
    }
}
