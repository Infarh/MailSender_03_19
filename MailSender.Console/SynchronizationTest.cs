using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class SynchronizationTest
    {
        public static void Test()
        {
            //for (var i = 0; i < 10; i++) ThreadMethod();
            for (var i = 0; i < 10; i++)
                ThreadPool.QueueUserWorkItem(o => ThreadMethod());
        }

        public static readonly object SyncRoot = new object();

        private static void ThreadMethod()
        {
            for (var i = 0; i < 10; i++)
            {
                lock (SyncRoot)
                {
                    Console.Write($"{Thread.CurrentThread.ManagedThreadId}:");
                    for (var j = 0; j < 10; j++)
                        Console.Write("{0},", j);

                    Console.WriteLine("10");
                }

                Thread.Sleep(100);
            }
        }

        private static void ThreadMethod2()
        {
            for (var i = 0; i < 10; i++)
            {
                Monitor.Enter(SyncRoot);
                try
                {
                    Console.Write($"{Thread.CurrentThread.ManagedThreadId}:");
                    for (var j = 0; j < 10; j++)
                        Console.Write("{0},", j);

                    Console.WriteLine("10");
                }
                finally
                {
                    if (Monitor.IsEntered(SyncRoot))
                        Monitor.Exit(SyncRoot);
                }

                Thread.Sleep(100);
            }
        }

        [MethodImpl(MethodImplOptions.Synchronized)]
        private static void PrintOperation()
        {
            Console.Write($"{Thread.CurrentThread.ManagedThreadId}:");
            for (var j = 0; j < 10; j++)
                Console.Write("{0},", j);

            Console.WriteLine("10");
        }

        private static void ThreadMethod3()
        {
            for (var i = 0; i < 10; i++)
            {
                PrintOperation();

                Thread.Sleep(100);
            }
        }
    }
}
