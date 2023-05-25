using DS.ClassLib.DataStructure;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Misc
{
    internal static class QueueTest
    {
        public static void Run()
        {
            Queue<string> queue = new Queue<string>();
            queue.Enqueue("Kate");
            queue.Enqueue("Sam");
            queue.Enqueue("Alice");
            queue.Enqueue("Tom");

            foreach (string item in queue)
                Console.WriteLine(item);
            Console.WriteLine();

            Console.WriteLine();
            string firstItem = queue.Dequeue();
            Console.WriteLine($"Извлеченный элемент: {firstItem}");
            Console.WriteLine($"Последний элемент: { queue.Last()}\n");

            foreach (string item in queue)
                Console.WriteLine(item);
        }

        public static void ObservableQueueTest()
        {
            var queue = new ObservableQueue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);

            Console.WriteLine("Queue count: " + queue.Count);

            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine("Queue count: " + queue.Count);

        }

    }
}
