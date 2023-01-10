using System;
using System.Collections.Generic;

namespace Two.CustomCollections.DictionaryClasses
{
    class Temp
    {
        static Dictionary<string, ConsoleColor> colorMap = new Dictionary<string, ConsoleColor>()
        {
            ["Error"] = ConsoleColor.Red,
            ["Warning"] = ConsoleColor.Yellow,
            ["Information"] = ConsoleColor.Green
        };
        
        static void Print(IEnumerable<KeyValuePair<string, ConsoleColor>> items)
        {
            foreach(KeyValuePair<string, ConsoleColor> item in items)
            {
                Console.WriteLine($"Value: {item.Value} \n\t(key = {item.Key})");
            }
        }

        static void ChangingKey ()
        {
            // Changing the value a key refers to is legal
            colorMap["Error"] = ConsoleColor.Blue;

            // Repeated keys are not legal
            // colorMap.Add("Error", ConsoleColor.Blue);
        }
    }
}
