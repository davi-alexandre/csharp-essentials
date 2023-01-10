using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Two.Collection_Interfaces.AnonyTypes_VarKeyword
{
    class CollectionInitializer
    {
        public static void Start()
        {
            // Shares the same syntax of array and object initialization
            var sevenWorldBlunders = new List<string>()
            { 
                // Quotes from Ghandi
                "Wealth without work",
                "Pleasure without conscience",
                "Knowledge without character",
                "Commerce without morality",
                "Science without humanity",
                "Worship without sacrifice",
                "Politics without principle"
            };

            var colorMap = new Dictionary<string, ConsoleColor>
            {
                ["Error"] = ConsoleColor.Red,
                ["Warning"] = ConsoleColor.Yellow,
                ["Information"] = ConsoleColor.Green,
                ["Verbose"] = ConsoleColor.White
            };


            Print(sevenWorldBlunders);
        }

        private static void Print<T>(IEnumerable<T> items)
        {
            foreach (T item in items)
            {
                WriteLine(item);
            }
        }
    }
}

/*
    The collection type has to implement ICollection<T> 
        so that the compiler to use the Add() method
    Or the collection type has to have an Add() as an extension 
        or instance method on a type that implements IEnumerable<T>
*/