using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    class QuestionMark
    {
        private static void Mainn(string[] args)
        {
            if (args?.Length == 0)   // (args != null) ? (int?) args.Length : null;
            {
                WriteLine("No arguments fed in");
            }
            else if (args[0]?.ToLower().StartsWith("file:") ?? false)   // if null then false
            {
                string fileName = args[0]?.Remove(0, 5);
            }

            bool? var1 = null;    
            bool? var2 = null;      // To nullable types
            bool? var3 = true;
            if ((var1 ?? var2 ?? var3) == true)
                WriteLine("True");
        }
    }
}
