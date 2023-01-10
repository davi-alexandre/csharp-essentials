using System;
using System.Collections.Generic;

namespace Two.CustomCollections.DictionaryClasses
{
    class KeyEqualsComparison
    {
        public static void Start ()
        {
            var dic = new Dictionary<Contact, string>(); // Contact as key
            
        }


        class ContactEqualComparer : IEqualityComparer<Contact>
        {
            public bool Equals (Contact x, Contact y)
            {
                if (ReferenceEquals(x, y))
                    return true;
                if (x == null || y == null)
                    return false;

                return x.LastName == y.LastName &&
                    x.FirstName == y.FirstName;
            }

            public int GetHashCode (Contact x)
            {
                if (ReferenceEquals(x, null))
                    return 0;

                int h1 = x.FirstName == null ? 0 : x.FirstName.GetHashCode();
                int h2 = x.LastName == null ? 0 : x.LastName.GetHashCode();

                return h1 * 23 + h2;
            }
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
        }
    }
}
