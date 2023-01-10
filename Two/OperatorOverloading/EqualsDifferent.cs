using static System.Console;

namespace Two.OperatorOverloading
{
    internal class Weirdo : object
    {
        public Weirdo(long weirdness)
        {
            Weirdness = weirdness;
        }


        public long Weirdness { get; }


        public bool Equals(Weirdo w)
        {
            if (w == null)
                return false;
            if (ReferenceEquals(this, w))
                return true;
            if (GetHashCode() != w.GetHashCode())
                return false;

            return Weirdness == w.Weirdness;
        }
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            if (GetType() != obj.GetType())
                return false;
            return Equals((Weirdo)obj);
        }
        public override int GetHashCode()
        {
            return Weirdness.GetHashCode();
        }

        public static bool operator ==(Weirdo a, Weirdo b)
        {
            if (ReferenceEquals(a, null))
                return ReferenceEquals(b, null);
            else if (ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }
        public static bool operator !=(Weirdo a, Weirdo b)
        {
            return !(a == b);
        }
    }
}

/*  NOTES   
    
    Unless the intent is for a type to act like a
        primitive type (a numeric type, for example),
        you should avoid overloading an operator.

    AVOID using the equality comparison operator (==) from within
        the implementation of the == operator overload. [Use ReferenceEquals()]
    Doing so would be recursive, resulting in a loop that
        continues to call back until the stack overflows.
        
*/
