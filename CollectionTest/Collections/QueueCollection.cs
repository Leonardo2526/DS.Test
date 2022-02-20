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

            for (int i = 3; i < 1000000; i++)
            {
                queue.Enqueue(i);
            }

            //Console.WriteLine("Initial queue: ");
            //Print.PrintIndexAndValues(queue);

            // получаем элемент из самого начала очереди 
            //var firstPerson = queue.Peek();
            //Console.WriteLine(firstPerson);

            int cnt = queue.Count;
            for (int i = 0; i < cnt - 1; i++)
            {
                queue.Dequeue();
            }

            return queue.ToList();

        }
       
    }
}
