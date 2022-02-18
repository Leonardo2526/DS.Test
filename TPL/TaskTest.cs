using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    static class TaskTest
    {
        public static void RunTasks()
        {
            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            task1.Wait();   // ожидаем завершения задачи task1
            task2.Wait();   // ожидаем завершения задачи task2
            task3.Wait();   // ожидаем завершения задачи task3
        }

        public static void RunTasksWithWait()
        {
            Console.WriteLine("Main Starts");
            // создаем задачу
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Task Starts");
                Thread.Sleep(1000);     // задержка на 1 секунду - имитация долгой работы
                Console.WriteLine("Task Ends");
            });
            task1.Start();  // запускаем задачу
            task1.Wait();   // ожидаем выполнения задачи
            Console.WriteLine("Main Ends");
        }

        public static void RunTasksSynchronously()
        {
            Console.WriteLine("Main Starts");
            // создаем задачу
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Task Starts");
                Thread.Sleep(1000);
                Console.WriteLine("Task Ends");
            });
            task1.RunSynchronously(); // запускаем задачу синхронно
            Console.WriteLine("Main Ends"); // этот вызов ждет завершения задачи task1 
        }

        public static void RunTasksWithInfo()
        {
            Task task1 = new Task(() =>
            {
                Console.WriteLine($"Task{Task.CurrentId} Starts");
                Thread.Sleep(1000);
                Console.WriteLine($"Task{Task.CurrentId} Ends");
            });
            task1.Start(); //запускаем задачу

            // получаем информацию о задаче
            Console.WriteLine($"task1 Id: {task1.Id}");
            Console.WriteLine($"task1 is Completed: {task1.IsCompleted}");
            Console.WriteLine($"task1 Status: {task1.Status}");

            task1.Wait(); // ожидаем завершения задачи
        }

        public static void RunArray()
        {
            Task[] tasks = new Task[3];
            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(1000); // эмуляция долгой работы
                    Console.WriteLine($"Task{i} is finished");
                });
                tasks[i].Start();   // запускаем задачу
                tasks[i].Wait();
            }
            Console.WriteLine("Завершение метода Main");

            //Task.WaitAll(tasks); // ожидаем завершения всех задач
        }
    }
}
