using static System.Console;

namespace One
{
    internal class CharLetterDistance : object
    {
        public static void LetterDistance(char first, char second)
        {
            // chars are integral types for letters (integer-based type)
            float distance = first - second;

            WriteLine(distance);
            Read();
        }
    }
}
