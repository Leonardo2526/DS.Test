using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    internal static class TaskTest
    {
        public static void RunAndWait1Task()
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

        public static void RunTasks()
        {
            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));
        }

        public static void RunAndWait3Tasks()
        {
            Task task1 = new Task(() => Console.WriteLine("Task1 is executed"));
            task1.Start();

            Task task2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed"));

            Task task3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            task1.Wait();   // ожидаем завершения задачи task1
            task2.Wait();   // ожидаем завершения задачи task2
            task3.Wait();   // ожидаем завершения задачи task3
        }

        public static void RunAndWaitMultipleTasks()
        {
            Task[] tasks = new Task[3];
            for (var i = 0; i < tasks.Length; i++)
            {
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(1000); // эмуляция долгой работы
                    Console.WriteLine($"Task{i} finished");
                });
                tasks[i].Start();   // запускаем задачу
            }

            // ожидаем завершения всех задач
            Task.WaitAll(tasks);

            Console.WriteLine("All tasks are executed!");
        }

        public static void RunAndWaitMultipleTasks_InterLocked()
        {
            Task[] tasks = new Task[3];
            for (var i = 0; i < tasks.Length; i++)
            {
                int j = i + 1;
                Interlocked.Increment(ref j);
                tasks[i] = new Task(() =>
                {
                    Thread.Sleep(1000); // эмуляция долгой работы
                    Console.WriteLine($"Task{j} finished");
                });
                tasks[i].Start();   // запускаем задачу
            }

            // ожидаем завершения всех задач
            Task.WaitAll(tasks);

            Console.WriteLine("All tasks are executed!");
        }

        public static void RunAndWaitMultipleTasks_Locked()
        {
            object oLock = new();

            Task[] tasks = new Task[3];
            for (var i = 0; i < tasks.Length; i++)
            {
                int j;
                lock (oLock)
                {
                    j = i;
                }
                tasks[i] = new Task(() =>
                {
                    Console.WriteLine($"Task{j} started");
                    Thread.Sleep(1000); // эмуляция долгой работы
                    Console.WriteLine($"Task{j} finished");
                });
                tasks[i].Start();   // запускаем задачу
            }

            // ожидаем завершения всех задач
            Task.WaitAll(tasks);

            Console.WriteLine("All tasks are executed!");
        }
    }
}
