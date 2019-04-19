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

    internal class InternalDataPrinter
    {
        private int _Data = 42;

        public int Data
        {
            get => _Data;
            set => _Data = value;
        }

        public InternalDataPrinter() { }
        public InternalDataPrinter(int Data) => _Data = Data;

        private int Sum(int X) => _Data + X;
    }
}
