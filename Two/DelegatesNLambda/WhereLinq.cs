using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Two.DelegatesNLambda
{
    class WhereLinq
    {
        static void ChooseItemsIn (IEnumerable<int> array, Func<int, bool> expression)
        {
            IEnumerable<int> final = array.Where(expression);

            foreach(int num in final)
                WriteLine(num);
        }


        static IEnumerable<int> ages = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        static void main ()
        {
            ChooseItemsIn(ages, (num => num > 5));

            ReadLine();
        }
    }
}