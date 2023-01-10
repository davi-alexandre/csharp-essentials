using System;
using System.Collections.Generic;
using System.Linq;

namespace Two.Collection_Interfaces.AnonyTypes_VarKeyword
{
    class AnonTypeCollection
    {
        private static void AnonymousCollectionInit()
        {
            var anonymousTypeCollection = new[]
            {
                new { Name = "Name1" },
                new { Name = "Name2" },
                new { Name = "Name3" }
            };
        }


        static List<T> CreateList<T>(T first, params T[] others)
        {
            List<T> list = others.ToList();
            list.Insert(0, first);
            return list;
        }

        public static void Start()
        {
            var person1 =
                new
                {
                    Name = "Albert",
                    Age = 19
                };
            var person2 =
                new
                {
                    Name = "John",
                    Age = 20
                };
            var person3 =
                new
                {
                    Name = "Clay",
                    Age = 26
                };
            var person4 =
                new
                {
                    Name = "Daemon",
                    Age = 2
                };


            var anonList = CreateList(person1, person2, person3, person4);
            foreach (var person in anonList)
                Console.WriteLine(person);
        }
    }
}
