using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    internal class Singleton
    {
        private static Lazy<Singleton> instance = new Lazy<Singleton>(() =>
        {
            return new Singleton();
        });

        public static Singleton Instance => instance.Value;

        public string Name { get;  set; }

        private static int instanceCount;
        public static int Count => instanceCount;

        private Singleton()
        {
            //Name = System.Guid.NewGuid().ToString();
        }

        public static Singleton GetInstance()
        {
            instanceCount++;
            return instance.Value;
        }
    }
}
