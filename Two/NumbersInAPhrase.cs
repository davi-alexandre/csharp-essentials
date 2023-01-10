using System.Collections.Generic;
using static System.Console;

namespace ConsoleApplication2
{
    class NumbersInAPhrase
    {
        public static void Start()
        {
            Write(" - Enter a phrase with words and numbers\n\t>> ");
            string input = ReadLine();

            WriteLine("\n-------------------------------------------\n");
            WriteLine(input);

            string result = input;
            for (int i = 0; i < input.Length; i++)
            {
                if (!IsNumeral(input[i]))
                {
                    result = result.Replace(input[i], '.');
                    WriteLine(result);
                }
            }

            WriteLine("\n-------------------------------------------\n");

            IEnumerable<string> numbersText = result.Split('.');
            Write("Found numbers: ");
            foreach (string number in numbersText)
            {
                if (number != string.Empty)
                {
                    Write("[" + number + "] ");
                }
            }

            ReadLine();
        }

        static bool IsNumeral(char c) {
            int a;
            return int.TryParse(c.ToString(), out a);
        }
    }
}