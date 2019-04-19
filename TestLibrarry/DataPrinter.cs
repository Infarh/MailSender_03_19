using System;
using System.IO;

namespace TestLibrarry
{
    public class DataPrinter
    {
        private string _Data;

        public DataPrinter(string Data) => _Data = Data;

        public void Print(TextWriter writer) => writer.WriteLine($"{DateTime.Now} : {_Data}");
    }
}
