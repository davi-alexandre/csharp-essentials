using System;
using System.Diagnostics;

namespace Two.Reflection.DinamicallyInvokeMembers
{
    public partial class Program
    {
        public static void main(string[] args)
        {
            string errorMessage;
            CommandLineInfo commandLine = new CommandLineInfo();

            if (!CommandLineHandler.TryParse(args, commandLine, out errorMessage))
            {
                Console.WriteLine(errorMessage);
                DisplayHelp();
            }

            if (commandLine.Help)
                DisplayHelp();
            else
            {
                if (commandLine.Priority != ProcessPriorityClass.Normal)
                {
                    // Change thread priority
                }
            }
        }

        private static void DisplayHelp()
        {
            // Display the command-line help.
            Console.WriteLine("Compress.exe / Out:< file name > / Help \n"
                + "/ Priority:RealTime | High | "
                + "AboveNormal | Normal | BelowNormal | Idle");
        }
    }
}