using System;
using System.IO;

namespace Two
{
    internal class CopyDirectoryFiles : object
    {
        public static void CopyTo (
            string sourceDirectory, string target, string fileExtension)
        {
            if (target[target.Length - 1] !=
                Path.DirectorySeparatorChar)
            {
                target += Path.DirectorySeparatorChar;
            }
            
            // File handling
            foreach (string filepath in // directories with files with these extensions
                Directory.GetFiles(sourceDirectory, fileExtension))
            {
                if (!Directory.Exists(target)) // inside foreach => no empty folders
                    Directory.CreateDirectory(target);

                File.Copy(filepath, 
                    target + GetFilename(filepath), true);
            }

            // Recursion for subdirectories
            foreach (string subdirectory in 
                Directory.GetDirectories (sourceDirectory))
            {
                CopyTo(subdirectory, 
                    target + GetFilename(subdirectory), fileExtension);
            }
        }

        public static string GetFilename (string filepath)
        {
            int lastSeparatorIndex = filepath.LastIndexOf(
                Path.DirectorySeparatorChar);
            int nameSize = filepath.Length - (lastSeparatorIndex + 1);

            var name = new char[nameSize];
            filepath.CopyTo(lastSeparatorIndex + 1, name, 0, name.Length);

            return new string (name);
        }


        private static void Mainn()
        {
            CopyTo(
                @"C:\Users\New One\Documents\visual studio 2015\",
                @"C:\Users\New One\Documents\Target", "*.cs");

            Console.WriteLine("Copying files...");
            Console.WriteLine("\nFiles copied successfully!");
            Console.Read();
        }
    }
}
