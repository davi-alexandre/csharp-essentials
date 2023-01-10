using System.CodeDom;
using static System.Console;

namespace One
{
    internal class PostOrPrefixIncrement : object
    {
        private static void Main()
        {
            var x = 100;

            WriteLine($"X = {x}");
            WriteLine($"Postfix Increment: {x++} => {x++} => {x}");

            x = 100;
            WriteLine("\n\n" + $"X = {x}");
            WriteLine($"Prefix Increment:  {++x} => {++x} => {x}");

            Read();
        }
    }
}