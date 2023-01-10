using System;
using static System.Console;

namespace One
{
    public static class Palindrome : object
    {
        private static void Presentation ()
        {
            Write("---------- ");
            Write(@"PALINDROME      IDENTIFIER");
            Write(" ----------\n\n");
        }

        public static void IsPalindrome ()
        {
            Presentation();

            var word = default(string);
            var original = default(string);
            var letters = default(char[]);


            do
            {
                WriteLine("Enter a word: ");
                word = ReadLine();
                original = word;
            } while (string.IsNullOrWhiteSpace(word));

            // there NEEDS to have an assignment!!
            word = word.Replace(" ", "");
            word = word.ToLower();

            letters = word.ToCharArray();
            Array.Reverse(letters);

            WriteLine(
                word == new string(letters)
                    ? $"\n\t\t{original} IS a palindrome!"
                    : $"\n\t\t{original} is NOT a palindrome!");
        }
    }
}
