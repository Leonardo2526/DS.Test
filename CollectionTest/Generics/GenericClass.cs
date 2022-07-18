using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Generics
{

    internal class GenericClass1<T> : AbstractClass, IProperty<T>, IProperty
    {
        public override string Name { get; set; }
        //object IProperty.Age
        //{
        //    get { return (object)Age; }
        //    set { this.Age = (T)value; }
        //}

        T IProperty<T>.Age { get; set; }
    }

    internal class GenericClass2<T> : AbstractClass, IProperty<T>, IProperty
    {
        public string SecondName { get; set; }
        public override string Name { get; set; }

        T IProperty<T>.Age { get; set; }
    }

    internal class ConreteGenericClass : AbstractClass, IProperty<int>, IProperty
    {
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public override string Name { get; set; }      

        int IProperty<int>.Age { get; set; }
    }


}
