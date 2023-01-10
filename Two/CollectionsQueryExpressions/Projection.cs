using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;

namespace Two.CollectionsQueryExpressions
{
    class Projection
    {
        private static void ListFiles(string path, string searchPattern)
        {
            IEnumerable<string> filepaths = Directory.GetFiles(path, searchPattern);

            // Use anonymous type instead of FileInfo to PROJECT only relevant information
            //      Therefore, there's no need here to instantiate and store every member of a full FileInfo.
            //      Only Name and LastWriteTime properties are relevant in this context.
            //
            var fileInfoList =  // var replaces IEnumerable<T> where T is the anonymous type
                from filepath in filepaths
                select new
                {

                    Name = filepath,
                    LastWriteTime = File.GetLastWriteTime(filepath)
                };

            foreach (var file in fileInfoList)
            {
                WriteLine($"{file.Name} ({file.LastWriteTime})");
            }
        }
    }
}
