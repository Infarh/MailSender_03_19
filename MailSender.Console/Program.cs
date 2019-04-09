using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace MailSender.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //ThreadTest.Test();
            //ThreadPoolTest.Test();
            SynchronizationTest.Test();

            lock (SynchronizationTest.SyncRoot)
                Console.WriteLine("Главный поток завершил свою работу");
            Console.ReadLine();
        }


    }
}
