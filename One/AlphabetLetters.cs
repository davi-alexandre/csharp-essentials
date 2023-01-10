using static System.Console;

namespace One
{
    internal class AlphabetLetters : object
    {
        private static void Mainn()
        {
            for (var letter = 'z'; letter >= 'a'; letter--)
                Write(letter + " ");

            Read();
        }
    }
}
