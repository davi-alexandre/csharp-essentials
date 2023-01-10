using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using static System.Console;

namespace Two.Collection_Interfaces.StandardQueryOperators
{
    class MethodExaples
    {
        public static void IOExample(string rootDirectory, string searchPattern)
        {
            //IEnumerable<string> filepaths = Directory.GetFiles(rootDirectory, searchPattern);
            //IEnumerable<object> files = filepaths.Select(path => new FileInfo(path));

            IEnumerable<string> fileList = Directory.EnumerateFiles(rootDirectory, searchPattern);

            // using Parallel LINQ to support multithread processing
            // Running the query in parallel across multiple CPUs can decrease 
            //      execution time by a factor corresponding to the number of CPUs
            // Can introduce race conditions => may cause data corruption
            var items = fileList.AsParallel().Select(file => // transform to anonymous type
            {
                FileInfo fileInfo = new FileInfo(file);
                return new
                {
                    FileName = fileInfo.Name,
                    Size = fileInfo.Length
                };
            });
            
            // Leaving no parameters => count all
            // Count() accepts a predicate to specify what type of item to count
            WriteLine("There are {0} items with size greater than 1000", 
                items.AsParallel().Count(item => item.Size > 1000));

            foreach (var item in items)
                WriteLine(item);
        }

        private static void LinqCount()
        {
            // If available, better use property Count than Count()
            //      Count() iterates over all elements
            // ICollection<T> includes a Count property
            // if (col.Count() > 0)    <=>    if (col.Any())
        }
    }
}
