using System;
using System.Collections.Generic;

namespace Two.CustomCollections.ListClasses
{
    class BinarySearch
    {
        public static void Start ()
        {
            var list = new List<string>() {
                "public", "protected", "private" };
            int search;

            list.Sort();

            search = list.BinarySearch("protected internal");
            if (search < 0)
                list.Insert(~search, "protected internal");
            // The bitwise complement (~) of BinarySearch's return value (a negative number)
            //      is the index of where the element being sought would be as to maintain sorting

            foreach (string accessModifier in list)
                Console.WriteLine(accessModifier);
        }
    }
}
