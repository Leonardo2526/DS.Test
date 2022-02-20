using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollectionTest.Collections
{
    class QueueCollection : ICollectionCreator
    {
        public List<int> GetValues()
        {

            var queue = new Queue<int>();

            for (int i = 3; i < 10; i++)
            {
                queue.Enqueue(i);
            }

            Print.PrintIndexAndValues(queue);

            // получаем элемент из самого начала очереди 
            //var firstPerson = queue.Peek();
            //Console.WriteLine(firstPerson);

            var item1 = queue.Dequeue();
            Console.WriteLine(item1); 

            Print.PrintIndexAndValues(queue);

            List<int> outlist = new List<int>();
            for (int i = 0; i < queue.Count; i++)
            {
                var item = queue.Dequeue();
                outlist.Add(item);
            }



            return outlist;

        }
    }
}
