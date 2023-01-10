using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using static System.Console;

namespace Two
{
    internal class BoxingValueTypes
    {
        private static int CountTo = 2000;
        private delegate void ToOneHundred(); // Type

        private static long BoxingMs = 0L;
        private static long NonBoxMs = 0L;


        private static void Mainn()
        {
            int repeatCount = 1;
            string input = string.Empty;
            do
            {
                WriteLine("Enter the number of times to check: ");
                input = ReadLine();
            } while (!int.TryParse(input, out repeatCount));

            Clear();
            
            for (int i = 0; i < repeatCount; i++)
                CompareTime();
            WriteLine(
                $"TIME FOR BOXINGCODE: {BoxingMs}\n" +
                $"TIME FOR NONBOXCODE: {NonBoxMs}\n");

            WriteLine("Press any key to exit... ");
            Read();
        }
        


        private static void CompareTime ()
        {
            long lineOne = GetElapsedTime(new ToOneHundred(BoxingCode));
            long lineTwo = GetElapsedTime(new ToOneHundred(NonBoxCode));
            BoxingMs += lineOne;
            NonBoxMs += lineTwo;


            //var stream = new FileStream("log.txt", FileMode.OpenOrCreate);
            var reader = new StreamReader("log.txt");

            string input = string.Empty;
            decimal IN1 = 0M;
            decimal IN2 = 0M;

            input = reader.ReadLine();
            if (input != null)
                IN1 = decimal.Parse(input);

            input = reader.ReadLine();
            if (input != null)
                IN2 = decimal.Parse(input);

            reader.Close();

            var writer = new StreamWriter("log.txt");
            writer.WriteLine(lineOne + IN1);
            writer.WriteLine(lineTwo + IN2);

            writer.Close();
        }

        private static long GetElapsedTime (ToOneHundred method)
        {   
            var watch = System.Diagnostics.Stopwatch.StartNew();
            method();
            watch.Stop();
            Clear();

            return watch.ElapsedMilliseconds;
        }



        private static void NonBoxCode()
        {
            var array = new ArrayList();
            for (int i = 0; i < CountTo; i++)
                array.Add(new IntegralValue(i));    // box

            foreach (object i in array)      
                WriteLine("{0}", i);
        }
        private static void BoxingCode()
        {
            var array = new ArrayList();
            for (int i = 0; i < CountTo; i++)
                array.Add(new IntegralValue(i));    // box

            foreach (IntegralValue i in array)      // unbox
                WriteLine("{0}", i);                // box
        }

        private static ToOneHundred ChooseMethod ()
        {
            string input = null;
            Clear();
            WriteLine(""
                + "[0] for Box/Unbox code\n"
                + "[1] for clean code\n\n");
            input = ReadLine().ToUpper();

            switch (input[0])
            {
                case '0':
                    return new ToOneHundred(BoxingCode);
                case '1':
                    return new ToOneHundred(NonBoxCode);
                default:
                    return null;
            }
        }
    }
}