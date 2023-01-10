using static System.Console;

namespace One
{
    internal class ParamsNFilePaths : object
    {
        private static void Main()
        {
            string fullname;

            fullname = Combine(new string[]
                {"C:\\", "Data", "Home", "index.b"});
            WriteLine(fullname);


            fullname = Combine(
                System.IO.Directory.GetCurrentDirectory(),
                "New Folder", "Three parameters");
            WriteLine(fullname);


            fullname = Combine(
                System.Environment.SystemDirectory,
                "Two", "Three", "Four",
                "Five", "Unlimited *params*");
            WriteLine(fullname);


            Read();
        }

        private static string Combine(params string[] paths)
        {
            var result = string.Empty;

            foreach (var path in paths)
                result = System.IO.Path.Combine(result, path);

            return result;
        }
    }
}