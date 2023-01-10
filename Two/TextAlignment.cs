using System;
using static System.Console;

namespace ConsoleApplication2
{
    class TextAlignment
    {
        public static void TextAlignExample()
        {
            // (2) columns of size ----------------- 10 (for the name)
            // (1) column of size ------------------ 5  (for the age)
            // (2) lines of size ------------------- 3  (for organization) 
            // 10 + 10 + 5 + (3*2) = 31
            WriteLine("-------------------------------");
            WriteLine("First Name | Last Name  |   Age");
            WriteLine("-------------------------------");
            WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "Bill", "Gates", 51));
            WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "Edna", "Parker", 114));
            WriteLine(String.Format("{0,-10} | {1,-10} | {2,5}", "Johnny", "Depp", 44));
            WriteLine("-------------------------------");

            // Seems to create a string of 31 empty spaces and assign the second one
            //      either to the left side (-)
            //      or to the right side (+) of it
            //
            WriteLine(String.Format("{0, 31}", ""));    // right
            WriteLine(String.Format("{0, -31}", ""));   // left
        }
    }
}
