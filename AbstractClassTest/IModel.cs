using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassTest
{
    public interface IModel<T>
    {
        public List<T> ModelGroup { get; }

        public void CreateModel();
    }

}
