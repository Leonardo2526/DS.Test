using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS.ConsoleApp.SingletonTest
{
    public class StaticModel
    {
        private static readonly Lazy<StaticModel> instance = new Lazy<StaticModel>(() =>
        {
            return new StaticModel();
        });

        public static CancellationTokenSource TotalCancelSource { get; private set; }
        public static CancellationToken TotalToken { get; private set; }

        public static StaticModel Create(CancellationTokenSource totalCancelSource)
        {
            TotalCancelSource = totalCancelSource;
            TotalToken  = TotalCancelSource.Token;
            return instance.Value;
        }

        public static StaticModel Create()
        {
            return instance.Value;
        }
    }
}
