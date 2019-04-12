using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class TasksTest
    {
        public static void Test()
        {
            //var task_1 = new Task(ParallelOperation);
            //task_1.Start();

            //Console.WriteLine(task_1.Status);

            //try
            //{
            //    task_1.Wait();
            //    Console.WriteLine(task_1.Status);
            //    // task_1.Exception
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e);
            //    throw;
            //}

            //var factorial_24_task = new Task<long>(() => Program.Factorial(24));
            ////factorial_24_task.CreationOptions
            ////factorial_24_task.Exception.InnerExceptions
            ////factorial_24_task.Id
            ////factorial_24_task.IsFaulted
            //factorial_24_task.Start();

            //var factorial_24 = factorial_24_task.Result;

            //var factorial_23_task = Task.Run(() => Program.Factorial(23));
            //var factorial_23 = factorial_23_task.Result;

            //var factorial_22_task = Task.Factory.StartNew(n => Program.Factorial((int) n), 22);
            //var factorial_22 = factorial_22_task.Result;

            var messages = Enumerable.Range(1, 100).Select(n => $"Message {n}")/*.ToArray()*/;

            //var msg_process_tasks_enum = messages
            //    .Select(msg => Task.Run(() => Console.WriteLine(msg))); // Здесь мы описываем лишь как создать эти задачи

            //var msg_process_tasks = msg_process_tasks_enum.ToArray();

            //Task.WaitAll(msg_process_tasks/*, 100*/);
            //Task.WaitAny(msg_process_tasks);

            //var parallel_msg_length_computing_tasks = messages
            //    .Select(msg => Task.Run(() =>
            //    {
            //        Thread.Sleep(100);
            //        return msg.Length;
            //    }));

            //var lengths_task = Task.WhenAll(parallel_msg_length_computing_tasks);
            //var lengths = lengths_task.Result;

            var when_all_task = Task.WhenAll(messages.Select(m => Task.Run(() => m.Length)));
            var continuation_task = when_all_task.ContinueWith(t => { Console.WriteLine($"Данная задача {t.Id} завершилась c ошибкой"); }, TaskContinuationOptions.OnlyOnFaulted);
            continuation_task.ContinueWith(t => { /* Завершение продолжения предыдущей задачи */ });
            var lengths = when_all_task.Result;

            var first_task_result = Task.WhenAny(messages.Select(m => Task.Run(() => m.Length))).Result;
        }

        private static void ParallelOperation()
        {
            Thread.Sleep(300);
            Console.WriteLine("Операция в потоке {0}",
                Thread.CurrentThread.ManagedThreadId);
        }
    }
}
