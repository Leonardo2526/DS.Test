using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Misc.ReflectonsTest
{
    internal static class Reflections
    {
        public static void GetAllTypes()
        {
            string assemblyInfo = "App.Person, MyApp.dll";

            var type = Type.GetType(assemblyInfo);
            Assembly asm = Assembly.LoadFrom(@".\Apps\MyApp.dll");

            Console.WriteLine(asm.FullName);
            // получаем все типы из сборки MyApp.dll
            Type[] types = asm.GetTypes();
            foreach (Type t in types)
            {
                Console.WriteLine(t.Name);
            }
        }
    }
}
