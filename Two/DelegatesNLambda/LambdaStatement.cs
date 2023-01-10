using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using static System.Console;

namespace Two.DelegatesNLambda
{
    class LambdaStatement
    {
        
        Func<string> getUserInput = () =>
            {
                string input;
                do
                {
                    input = ReadLine();
                } while (input.Trim().Length == 0);
                return input;
            };




        static void DisplayPhysicalMemoryUtilizationProcesses ()
        {
            IEnumerable<Process> processes = Process.GetProcesses().
                Where(process => process.WorkingSet64 > 100000000);

            foreach (var p in processes)
                WriteLine(p.ProcessName);

            ReadLine();
        }


        
        static void main ()
        {
            int sum;


            #region Equivalent Lambda Statements to Expression

            sum = BinaryOperation(1, 2, 
                (int x, int y) => { return x + y; } );

            sum = BinaryOperation(1, 2,
                (x, y) => { return x + y; });

            sum = BinaryOperation(1, 2,
                (x, y) => x + y);

            #endregion


            ReadLine();
        }
        static int BinaryOperation (int a, int b, Func<int, int, int> operation)
            => operation(a, b);

    }
}
