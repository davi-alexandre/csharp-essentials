using System;
using System.IO;
using static System.Console;

class Logging
{
    public static void Start()
    {
        using (StreamWriter w = File.AppendText("log.txt"))
        {
            Log("Test-1", w);
            Log("Test-2", w);
        }

        using (StreamReader r = File.OpenText("log.txt"))
        {
            DumpLog(r);
        }

        Read();
    }

    public static void Log(string logMessage, TextWriter w)
    {
        w.Write("\t\nLog Entry : ");
        w.WriteLine(
            $"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
        w.WriteLine("  :");
        w.WriteLine($"  :{logMessage}");
        w.WriteLine("-------------------------------");
    }

    public static void DumpLog(StreamReader r)
    {
        string line;
        while ((line = r.ReadLine()) != null)
        {
            WriteLine(line);
        }
    }
}