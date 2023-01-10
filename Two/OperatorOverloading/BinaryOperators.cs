using static System.Console;

namespace Two.OperatorOverloading
{
    internal struct UnaryBinary
    {
        public UnaryBinary(int age)
        {
            Age = age;
        }
        public int Age { get; }


        // Unary [The + operator is only provided for symmetry]
        public static UnaryBinary operator +(UnaryBinary x) => x;

        public static UnaryBinary operator -(UnaryBinary x)
            => new UnaryBinary(-x.Age);


        // Binary
        public static UnaryBinary operator +(UnaryBinary x, UnaryBinary y)
            => new UnaryBinary(x.Age + y.Age);
        
        public static UnaryBinary operator -(UnaryBinary x, UnaryBinary y)
            => new UnaryBinary( (x + (-y)).Age );
    }
}
