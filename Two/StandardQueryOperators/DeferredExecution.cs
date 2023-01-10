using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.Collection_Interfaces.StandardQueryOperators
{
    class DeferredExecution // Subtle triggering of standard query operators
    {
        public static void Start()
        {
            IEnumerable<Patent> patents = PatentData.Patents;
            bool result;
            patents = patents.Where(patent =>
            {
                if (result = patent.YearOfPublication.StartsWith("18"))
                    Console.WriteLine("\t" + patent);
                return result;
            });

            Console.WriteLine("1. Patents prior to the 1900s are:");
            foreach (Patent patent in patents) { }  // lambda trigger
            Console.WriteLine();

            Console.WriteLine("2. A second listing of patents prior to the 1900s:");
            Console.WriteLine(
                $@"There are { patents.Count() } patents prior to 1900."); // lambda trigger
            Console.WriteLine();

            Console.WriteLine( "3. A third listing of patents prior to the 1900s:");
            patents = patents.ToArray(); // lambda trigger 
                                         // ToList(), ToDictionary(), or ToLookup() also trigger the lambda
            /*  
            However, converting the
                collection with one of these “To” methods is extremely helpful. Doing so
                returns a collection on which the standard query operator has already
                executed 

            Collection types returned by a “To” method are generally safe to
                work with (until another standard query operator is called) 
            However, be aware that this will bring the entire result
                set into memory (it may have been backed by a database or file prior to this
                step). Furthermore, the “To” method will take a snapshot of the underlying
                data, such that no fresh results will be returned upon requerying the “To”
                method result.

            If you want the behavior of an in-memory collection snapshot, it is a best practice 
                to assign a query expression to a cached collection to avoid unnecessary iterations.
            The query object represents the query, not the results. When you ask the query for the results, 
                the whole query executes (perhaps even again) because the query object doesn’t know that the results
                will be the same as they were during a previous execution (if one existed).
            */

            Console.WriteLine($"There are { patents.Count() } patents prior to 1900.");
        }
    }
}
/*
    Predicates should do exactly one thing — evaluate a condition —
        and they should not have any side effects (even printing to the console, 
        as in this example
*/
