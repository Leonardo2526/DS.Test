using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public static class Class1
    {
        public static MyCollection1 ObjectModels { get; set; } = new MyCollection1();
        public static MyCollection1 ObjectModels1 { get; set; } = new MyCollection1();

        public static void Refresh(MyCollection1 objectModels)
        {
            ObjectModels1.Clear();
            foreach (var item in objectModels)
            {
                if (item.Name == "1")
                {
                    ObjectModels1.Add(item);
                }
            }
        }
    }
}
