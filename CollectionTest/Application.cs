using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest
{
    class Application : IApplication
    {
        ICollectionCreator _collectionCreator;

        public Application(ICollectionCreator collectionCreator)
        {
            _collectionCreator = collectionCreator;
        }

        public List<int> Run()
        {
            return _collectionCreator.GetValues();
        }
    }
}
