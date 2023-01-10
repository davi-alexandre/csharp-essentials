using System;
using System.Collections;
using System.Collections.Generic;

namespace Two.CustomCollections.Iterators
{
    class MultipleIterators
    {
        public class Starter
        {
            public static void Start()
            {
                var myName = new MyCollection("Davi", "Alexandre");

                foreach (string name in myName.GetReverseEnumerator())
                    Console.WriteLine(name);
            }
        }

        class MyCollection : IEnumerable<string>
        {
            public MyCollection (string firstName, string lastName)
            {
                FirstName = firstName;
                LastName = lastName;
            }

            public string FirstName { get; set; }
            public string LastName { get; set; }

            #region IEnumerable
            public IEnumerator<string> GetEnumerator()  // Default iterator
            {
                yield return FirstName;
                yield return LastName;
            }

            // In this case, IEnumerable<string> and NOT IEnumerator<string>
            //
            public IEnumerable<string> GetReverseEnumerator() // Custom iterator
            {
                yield return LastName;
                yield return FirstName;
            }

            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
            #endregion
        }
    }
}
