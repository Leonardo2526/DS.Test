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
        void WriteDate1();
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

        public void WriteDate1()
        {
            throw new NotImplementedException();
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

        public void WriteDate1()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<ConsoleOutput1>();
            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var output = scope.Resolve<ConsoleOutput1>(new NamedParameter("s", "000"));
                output.Write(DateTime.Today.ToShortDateString() + $" {this.GetType().Name}");
            }

        }
    }
}
