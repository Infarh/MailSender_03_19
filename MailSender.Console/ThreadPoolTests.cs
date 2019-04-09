using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class ThreadPoolTest
    {
        public static void Test()
        {
            ThreadPool.SetMinThreads(4, 4);
            ThreadPool.SetMaxThreads(4, 4);
            //Environment.ProcessorCount

            for (var i = 0; i < 20; i++)
            {
                var tmp_i = i;
                ThreadPool.QueueUserWorkItem(o => ThreadMethod($"Message {tmp_i}", tmp_i));
            }
        }

        private static void ThreadMethod(string msg, int index)
        {
            for (var i = 0; i < 10; i++)
            {
                Console.WriteLine($"Thread id:{Thread.CurrentThread.ManagedThreadId} ({i}) ==> {msg} [{index}]");
                Thread.Sleep(250);
            }
        }
    }
}
