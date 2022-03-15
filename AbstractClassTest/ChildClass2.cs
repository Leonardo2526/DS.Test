using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassTest
{
    class ChildClass2 :IModel<int>
    {
        private int A;
        private int B;

        public ChildClass2(int a, int b) 
        {
            A = a;
            B = b;
            CreateModel();
        }

        public List<int> ModelGroup { get; private set; }

        public void CreateModel()
        {
            throw new NotImplementedException();
        }
    }
    
}
