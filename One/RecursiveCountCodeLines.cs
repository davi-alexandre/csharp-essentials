using static System.Console;
using System.IO;

namespace One
{
    internal class RecursiveCountCodeLines : object
    {
        private static void Mainn ()
        {
            int lineCount = 0;

            lineCount = DirectoryCountLines(
                @"C: \Users\New One\Documents\Visual Studio 2015\Projects\ConsoleApplication1");
            
            WriteLine(lineCount);
            Read();
        }

        // Find the files and call the line-counter method
        private static int DirectoryCountLines (string directory)
        {
            int lineCount = 0;

            // Count lines in each file found
            foreach (var filename in Directory.GetFiles(directory, "*.cs"))
                lineCount += CountLines(filename);

            foreach (var subdirectory in Directory.GetDirectories(directory))
                lineCount += DirectoryCountLines(subdirectory);

            return lineCount;
        }

        // Take in the filename and count up every non-null and non-empty line
        private static int CountLines (string filename)
        {
            int lineCount = 0;
            string line;

            var stream = new FileStream(filename, FileMode.Open);
            var reader = new StreamReader(stream);

            line = reader.ReadLine();
            while (line != null)
            {
                if (line.Trim() != string.Empty)
                    lineCount++;

                line = reader.ReadLine();
            }

            reader.Close();
            return lineCount;
        }
    }
}