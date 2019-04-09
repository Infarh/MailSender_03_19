using System;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace MailSender.ConsoleTest
{
    [Synchronization]
    public class Logger : ContextBoundObject
    {
        private string _FileName;

        public Logger(string FileName)
        {
            _FileName = FileName;
        }

        public void Log(string item)
        {
            File.AppendAllText(_FileName, $"{DateTime.Now}:{item}");
        }
    }
}