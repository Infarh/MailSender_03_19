using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class AsyncAwaitTest
    {
        public static async void TestAsync()
        {
            var factorial_24_task = Task.Run(() =>
            {
                Thread.Sleep(500);
                Console.WriteLine("Factorial calculation Thread id:{0}", Thread.CurrentThread.ManagedThreadId);
                return Program.Factorial(24);
            });

            Console.WriteLine("Before factorial awaiting Thread id:{0}", Thread.CurrentThread.ManagedThreadId);

            var factorial_result = await factorial_24_task;
            Console.WriteLine("After factorial awaiting Thread id:{0}", Thread.CurrentThread.ManagedThreadId);
        }

        private static Task<int> LongOperationMethod()
        {
            //return Task.Run(() => 42);
            //return Task.FromResult(42);
            var task = new Task<int>(() => 42);
            task.Start();
            return task;
        }

        private static async Task<int> LongOperationMethodAsync()
        {
            await Task.Delay(100);
            return 42;
        }

        private static Task LongAction()
        {
            Console.WriteLine("Looooong action....");
            //Thread.Sleep(100000);
            Task.Delay(1000).Wait();
            Console.WriteLine("Looooong action completed");
            return Task.CompletedTask;
        }

        private static async Task LongActionAsync()
        {
            Console.WriteLine("Looooong action....");
            await Task.Delay(1000);
            Console.WriteLine("Looooong action completed");
        }
    }
}
