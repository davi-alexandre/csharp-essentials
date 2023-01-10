using System;
using System.Collections.Generic;

namespace Two.Generics
{
    internal interface Pair<T>
    {
        T Main { get; }
        T Child { get; }
    }

    internal struct Couple<T> : Pair<T>
    {
        public Couple(T main) :
            this(main, default(T))
        { }

        public Couple(T main, T child)
        {
            Main = main;
            Child = child;
        }

        public T Main { get; }
        public T Child { get; }
    }
}