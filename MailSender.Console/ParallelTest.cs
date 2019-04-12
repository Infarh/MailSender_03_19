using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MailSender.ConsoleTest
{
    static class ParallelTest
    {
        public static void Test()
        {
            Action<string> printer = str =>
            {
                for (var i = 0; i < 10; i++)
                {
                    Thread.Sleep(500);
                    Console.WriteLine("{0}: {1}", Thread.CurrentThread.ManagedThreadId, str);
                }
            };

            //printer.Invoke("123");
            //printer.BeginInvoke(
            //    "123", 
            //    result => { Console.WriteLine("Работу закончил"); }, 
            //    null);

            var messages = Enumerable.Range(1, 100).Select(n => $"Message {n}")/*.ToArray()*/;

            //messages
            //    .AsParallel()
            //    .WithDegreeOfParallelism(16)
            //    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //    .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
            //    .Select(msg => new { msg, Count = msg.Length })
            //    //.AsSequential()
            //    .ForAll(m => Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {m.msg}({m.Count})"));

            //var parallel_messages = messages
            //    .AsParallel()
            //    .WithDegreeOfParallelism(16)
            //    .WithExecutionMode(ParallelExecutionMode.ForceParallelism)
            //    .WithMergeOptions(ParallelMergeOptions.FullyBuffered)
            //    .Select(msg => new {msg, Count = msg.Length});

            //foreach (var m in parallel_messages)
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.ManagedThreadId}: {m.msg}({m.Count})");
            //}

            //Parallel.Invoke(/*new ParallelOptions { MaxDegreeOfParallelism = 1 },*/
            //    ParallelOperation,
            //    ParallelOperation,
            //    ParallelOperation,
            //    () => Console.WriteLine("Ещё одна параллельная операция"));

            //Parallel.For(0, 100, i => Console.WriteLine(i));

            //for (var i = 0; i < 100; i++)
            //{
            //    if(i > 20)
            //        break;
            //    Console.WriteLine(i);
            //}

            //var result = Parallel.For(0, 100, (i, state) =>
            //{
            //    Thread.Sleep(10);
            //    if(i > 20)
            //        state.Break();
            //    Console.WriteLine(i);
            //});

            //Console.WriteLine(result.LowestBreakIteration);

            //Parallel.ForEach(messages, m => Console.WriteLine(m));

            var result = Parallel.ForEach(messages, (m, state) =>
            {
                if (m.EndsWith("10"))
                    state.Break();
                Console.WriteLine(m);
            });
        }

        private static void ParallelOperation()
        {
            Thread.Sleep(300);
            Console.WriteLine("Операция в потоке {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
