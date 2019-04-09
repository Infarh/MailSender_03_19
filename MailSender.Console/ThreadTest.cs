using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class ThreadTest
    {
        public static void Test()
        {
            Thread.CurrentThread.Name = "Mail thread";

            //var parallel_thread = new Thread(new ThreadStart(Parallel_Thread_Method));
            var parallel_thread = new Thread(Parallel_Thread_Method);
            parallel_thread.Name = "Поток часов";
            parallel_thread.IsBackground = true;
            parallel_thread.Priority = ThreadPriority.Highest;
            parallel_thread.Start();

            var second_parallel_thread = new Thread(Parametrized_Thread_Method);
            second_parallel_thread.Start("Hello World!");

            var parallel_thread_3 = new Thread(o => Parametrized_Thread_Method2((string)o));
            parallel_thread_3.Start("qwe");

            var str = "asd";
            var parallel_thread_4 = new Thread(() => Parametrized_Thread_Method2(str, 10, 1000));
            parallel_thread_4.IsBackground = true;
            parallel_thread_4.Start();

            if (!parallel_thread_4.Join(1500))
            {
                parallel_thread_4.Abort();
                //parallel_thread_4.Interrupt();
            }
        }

        private static void Parallel_Thread_Method()
        {
            while (true)
            {
                Console.Title = DateTime.Now.ToString();
                Thread.Sleep(100);
            }
        }

        private static void Parametrized_Thread_Method(object parameter)
        {
            var str = (string)parameter;
            for (var i = 0; i < 20; i++)
            {
                Console.WriteLine(str);
                Thread.Sleep(100);
            }
        }

        private static void Parametrized_Thread_Method2(string str, int count = 20, int timeout = 100)
        {
            try
            {
                for (var i = 0; i < count; i++)
                {
                    Console.WriteLine($"{i}| id:{Thread.CurrentThread.ManagedThreadId} >>{str}");
                    Thread.Sleep(timeout);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
