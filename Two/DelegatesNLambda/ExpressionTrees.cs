using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Two.DelegatesNLambda
{
    class ExpressionTrees
    {
        public static void Start ()
        {
            System.Linq.Expressions.
                Expression<Func<int, int, bool>> expression = (a, b) => a > b;

            // It has some accessible properties and members
            WriteLine($"--------------- {expression} ---------------");
        }
    }
}
