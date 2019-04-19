namespace TestLibrarry
{
    internal class InternalDataSummator
    {
        private int _Data = 42;

        public int Data
        {
            get => _Data;
            private set => _Data = value;
        }

        public InternalDataSummator() { }
        public InternalDataSummator(int Data) => _Data = Data;

        private int Sum(int X) => _Data + X;
    }
}