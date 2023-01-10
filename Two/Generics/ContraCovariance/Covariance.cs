using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.Generics.ContraCovariance
{
    class Thing { }
    class Contact : Thing
    {
        public Contact (string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }

    interface IReadOnlyPair<out T>
    {
        T First { get; }
        T Second { get; }
    }
    interface IPair<T>
    {
        T First { get; set; }
        T Second { get; set; }
    }
    public struct Pair<T> : IPair<T>, IReadOnlyPair<T>
    {
        #region Covariance Members
        T IReadOnlyPair<T>.First  => First;
        T IReadOnlyPair<T>.Second  => Second;
        #endregion

        #region IPair Implementation
        public T First { get; set; }
        public T Second { get; set; }
        #endregion

        public Pair (T first, T second)
        {
            First = first;
            Second = second;
        }
    }

    class Test
    {
        static void main()
        {
            Pair<Contact> contacts = new Pair<Contact>(
                new Contact("Girl 1"),
                new Contact("Girl 2"));

            IReadOnlyPair<Thing> pair = contacts;
            Thing thing1 = pair.First;
            Thing thing2 = pair.Second;
        }
    }
}

/*
List<string> may not be assigned to List<objects> even though
    string can be assigned to object

EX: X converts to Y [Y is X's base (remember the inheritance "is a" relationship)]
    I<X> converts to I<Y>       =>      I<T> is covariant (in T)
    The conversion from I<X> to I<Y> is called a covariant conversion



{
    Pair<Contact> contacts = new Pair<Contact>
        (new Contact("Princess"), new Contact("Prince"));
// This gives an error: Cannot convert type ...
// But suppose it did not.
    IPair<PdaItem> pdaPair = (IPair<PdaItem>) contacts;
// This is perfectly legal, but not type-safe.
    pdaPair.First = new Address("123 Sesame Street");
}

*/
