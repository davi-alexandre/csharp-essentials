using static System.Console;

namespace Two.OperatorOverloading
{
    internal struct AtLeastOneHundred
    {
        public AtLeastOneHundred (int number)
        {
            Number = number;
        }

        // Field Declarations
        private int Number { get; }


        // Overloading
        public static bool operator true (AtLeastOneHundred x)
            => x.Number >= 100;
        
        public static bool operator false (AtLeastOneHundred x)
            => x.Number < 100;


        public override string ToString()
            => this ? true.ToString() : false.ToString();
    }
}