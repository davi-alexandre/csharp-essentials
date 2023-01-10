using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two
{
    class nameofOperator
    {
        public static void Start()
        {
            string textDigit = "adj";
            throw new ArgumentException(
                "The argument did not represent a digit", nameof(textDigit));
        }
    }
}
/*
    nameof() produces a constant string containing the UNQUALIFIED NAME
of whatever program element is specified as an argument

*/
