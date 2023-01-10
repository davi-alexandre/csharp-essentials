using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.DelegatesNLambda
{
    public delegate bool ComparisonHandler(int a, int b);

    class BubbleSort
    {
        private static int[] array = { 10, 101, 102, 5, 55, 0, 6, 22, 2, 1 };

        public static void Sort(int[] arr, ComparisonHandler ComparisonMethod)
        {
            int i, j, temp;

            if (ComparisonMethod == null)
                throw new ArgumentNullException(nameof(ComparisonMethod), "Comparison method is null");

            if (arr == null)
                return;

            for (i = arr.Length - 1; i >= 0; i--)
            {
                for (j = 1; j <= i; j++)
                {
                    if ( ComparisonMethod(arr[j - 1], arr[j]) )
                    {
                        temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }
            }
        }

        public static bool Ascending(int a, int b)
            => a > b;
        public static bool Descending(int a, int b)
            => a < b;
        public static bool Alphabetical(int a, int b)
            => a.ToString().CompareTo(b.ToString()) > 0;


        public static void Mainn ()
        {
            // delegate is ref type, but no need for <new> keyword
            // ComparisonHandler method = Ascending;

            foreach (var i in array)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.Write("ASCENDING: \t");
            Sort(array, Ascending);
            foreach (var i in array)
                Console.Write(i + " ");

            Console.WriteLine();

            Console.Write("DESCENDING: \t");
            Sort(array, Descending);
            foreach (var i in array)
                Console.Write(i + " ");

            Console.WriteLine();

            Console.Write("ALPHABETICAL:\t");
            Sort(array, Alphabetical);
            foreach (var i in array)
                Console.Write(i + " ");

            Console.ReadLine();
        }
    }
}
