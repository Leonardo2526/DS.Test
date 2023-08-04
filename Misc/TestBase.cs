using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{

    interface ITest
    {
        string Name { get; }
    }

    internal abstract class TestBase : ITest
    {
        public string Name {get; set;}
        public IEnumerable<string> TestEnum { get; set;}
    }

    class ClassTest1  : TestBase
    {
        private static readonly Lazy<ClassTest1> _instance =
            new(() => new ClassTest1());

        private ClassTest1()
        {
            
        }

        public static ClassTest1 GetInstance()
        {
            return _instance.Value;
        }
    }

    class ClassTest2 : TestBase
    {
        private static readonly Lazy<ClassTest2> _instance =
            new(() => new ClassTest2());

        private ClassTest2()
        {

        }

        public static ClassTest2 GetInstance()
        {
            return _instance.Value;
        }
    }
}
