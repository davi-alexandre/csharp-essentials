using System;
using static System.Console;

namespace Two
{
    internal class IsAs
    {
        private static void Save(object data)
        {
            if (data is string)
                WriteLine("STRING");
            else
                WriteLine("NOT string");
        }

        // <as> returns null if the source type
        // is not inherently of the target type
        // this avoids exceptions that could result from casting
        private static string Print (object data)
            => data as string;
    }
}
