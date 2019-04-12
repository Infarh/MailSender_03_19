using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    class Program
    {
        public static long Factorial(int n)
        {
            long result = 1;
            for (var i = 1; i <= n; i++)
                result *= i;
            return result;
        }

        static void Main(string[] args)
        {  
            //var factorial_task = new ThreadTask<long>(() => Factorial(24));
            //factorial_task.Start();
            //var result_0 = factorial_task.Result;
            //factorial_task.Wait();
            //var result = factorial_task.Result;

            //var task = new Task<long>(() => Factorial(24));
            ////task.RunSynchronously();
            //task.Start();
            //var result = task.Result;

            //ParallelTest.Test();
            //TasksTest.Test();

            AsyncAwaitTest.TestAsync();


            Console.WriteLine("Главный поток завершился");
            Console.ReadLine();
        }
    }
}
