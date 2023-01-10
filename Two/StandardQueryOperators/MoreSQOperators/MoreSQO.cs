using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace Two.Collection_Interfaces.StandardQueryOperators
{
    // Each method will trigger deferred execution
    class MoreSQO
    {
        // None of the API calls requires a lambda expression
        public static void Start()
        {
            IEnumerable<object> stuff = new object[]
                { new object(), 1, 3, 5, 7, 9, "\"thing\"", Guid.NewGuid() };
            Print("Stuff: {0}\n\n", stuff);


            IEnumerable<int> even = new int[] { 0, 2, 4, 6, 8 };
            Print("\tEven integers: {0}", even);

            IEnumerable<int> odd = stuff.OfType<int>();
            Print("\tOdd integers: {0}\n", odd);


            IEnumerable<int> numbers = even.Union(odd);
            Print("Union of odd and even: {0}", numbers);

            Print("Union with even: {0}", numbers.Union(even));
            Print("Concat with odd: {0}", numbers.Concat(odd));
            Print("Intersection with even: {0}", numbers.Intersect(even));
            Print("Distinct: {0}\n\n", numbers.Concat(odd).Distinct());


            if (!numbers.SequenceEqual(numbers.Concat(odd).Distinct()))
                throw new Exception("Unexpectedly unequal");
            else 
                WriteLine(@"Collection ""SequenceEquals""" +
                    $" {nameof(numbers)}.Concat(odd).Distinct())");


            Print("Reverse: {0}", numbers.Reverse());
            Print("Average: {0}", numbers.Average());
            Print("Sum: {0}", numbers.Sum());
            Print("Max: {0}", numbers.Max());
            Print("Min: {0}", numbers.Min());
        }


        private static void Print<T>(string format, IEnumerable<T> items) =>
            WriteLine(format, string.Join( ", ", items.Select(x => x.ToString())));

        private static void Print<T>(string format, T item)
            => WriteLine(format, item);
    }
}