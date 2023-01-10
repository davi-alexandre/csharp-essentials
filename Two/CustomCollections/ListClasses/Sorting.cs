using System;
using System.Collections.Generic;

namespace Two.CustomCollections.ListClasses
{
    class Sorting
    {
        public static void Start()
        {
            var list = new List<Contact>();
            list.Add(new Contact("Jon", "Snow"));
            list.Add(new Contact("Daemon", "Targaryen"));
            list.Add(new Contact("Eren", "Jaeger"));
            list.Add(new Contact("Davi", "Alexandre"));
            list.Sort(new NameComparison());

            foreach (var item in list)
                Console.WriteLine(item);
        }

        class Contact
        {
            public Contact(string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; private set; }
            public string LastName { get; private set; }

            public override string ToString()
                => $"{LastName.ToUpper()}, {FirstName}";
        }

        class NameComparison : IComparer<Contact>
        {
            // It would not be legal to say, “If either element is null,
            // then return zero,” for example, because then two non-null
            // things could be equal to null but not equal to each other.
            //
            public int Compare (Contact x, Contact y)
            {
                if (ReferenceEquals(x, y))
                    return 0;
                if (x == null)
                    return 1;
                if (y == null)
                    return -1;

                int result = StringCompare(x.LastName, y.LastName);
                if (result == 0)
                    result = StringCompare(x.FirstName, y.FirstName);
                return result;
            }

            private static int StringCompare (string x, string y)
            {
                if (ReferenceEquals(x, y))
                    return 0;
                if (x == null)
                    return 1;
                if (y == null)
                    return -1;
                return x.CompareTo(y); // Compares by the CompareTo criteria
            }
        }
    }
}
