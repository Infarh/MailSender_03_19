using System;
using System.Threading;

namespace MailSender.ConsoleTest
{
    internal class ThreadTask<TResult>
    {
        private Thread _Thread;
        private readonly Func<TResult> _Computer;

        private TResult _Result;

        public TResult Result
        {
            get
            {
                if(IsInProcess)
                    Wait();
                return _Result;
            }
            private set => _Result = value;
        }

        public bool IsInProcess => _Thread?.IsAlive ?? true;

        public ThreadTask(Func<TResult> Computer)
        {
            _Thread = new Thread(ThreadMethod);
            _Computer = Computer;
        }

        private void ThreadMethod()
        {
            Result = _Computer();
            _Thread = null;
        }

        public void Start()
        {
            _Thread.Start();
        }

        public void Wait() => _Thread.Join();
    }
}