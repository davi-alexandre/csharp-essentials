using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using static System.Console;

namespace Two.CollectionsQueryExpressions
{
    class Filtering
    {
        private static List<FileInfo> AllFiles = new List<FileInfo>();
        private static int Spacing 
        {
            get { return _Spacing; }
            set
            {
                if (value > _Spacing)
                    _Spacing = value;
            }
        }
        private static int _Spacing;


        public static void Start(string directory)
        {
            FindMonthOldFiles(directory, "*.cs");

            WriteLine("FILE COUNT: " + AllFiles.Count());
            WriteLine("LINE COUNT: " + CountAllLines() + "\n");

            IEnumerable<FileInfo> globalFiles = AllFiles.OrderBy(item => item.CreationTime).
                ThenBy(item => item.Name);
            foreach (FileInfo file in globalFiles)
            {
                WriteLine((Holder(0, -Spacing) + " ({1})"),
                    file.Name, file.CreationTime);
            }
        }

        static void FindMonthOldFiles (string path, string searchPattern, int ageInMonths = 0)
        {
            IEnumerable<FileInfo> files =
                from filepath in Directory.EnumerateFiles(path, searchPattern)
                where File.GetLastWriteTime(filepath) < DateTime.Now.AddMonths(ageInMonths) //filtering
                select new FileInfo(filepath);

            foreach (FileInfo file in files)
                if (!AllFiles.Contains(file))
                    AllFiles.Add(file);
            
            var nameSizes = from file in files select file.Name.Length;
            if (nameSizes.Any())
                Spacing = nameSizes.Max();
            
            foreach (string subdir in Directory.GetDirectories(path))
                FindMonthOldFiles(subdir, searchPattern);
        }
        static int CountAllLines ()
        {
            int lineCount = 0;

            foreach (FileInfo file in AllFiles)
            {
                using (StreamReader reader = new StreamReader(file.FullName))
                {
                    string input = reader.ReadLine();
                    while (input != null)
                    {
                        if (input != "")
                            lineCount++;

                        input = reader.ReadLine();
                    }
                }
            }

            return lineCount;
        }

        static string Holder (int position, int spacing)
            => "{" + position + ", " + spacing + "}";
    }
}
