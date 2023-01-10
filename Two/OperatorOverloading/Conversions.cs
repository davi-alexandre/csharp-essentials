using static System.Console;

namespace Two.OperatorOverloading
{
    public struct Latitude
    {
        public Latitude(double decimalDegrees)
        {
            DecimalDegrees = decimalDegrees;
        }


        public double DecimalDegrees { get; }


        // think of the <double> part as the RETURN TYPE
        public static implicit operator double(Latitude lat)
            => lat.DecimalDegrees;

        public static implicit operator Latitude(double d)
            => new Latitude(d);


        public static implicit operator string(Latitude lat)
            => lat.DecimalDegrees.ToString();
        public static explicit operator Latitude(string s)
        {
            double decimalDegrees = 0;
            if (double.TryParse(s, out decimalDegrees))
                return new Latitude(decimalDegrees);
            else
                throw new System.InvalidCastException
                    ("[CASTING] The string provided could not be converted to a double.");
        }
    }
}

/*  NOTES   
    Frequently, the pattern for conversion is that one direction (string to
        Coordinate) is explicit and the reverse (Coordinate to string) is implicit.

    DO NOT provide an implicit conversion operator if the conversion is lossy.
    DO NOT throw exceptions from implicit conversions.
*/
