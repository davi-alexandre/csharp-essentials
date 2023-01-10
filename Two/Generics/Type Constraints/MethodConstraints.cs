using System;
using System.Collections;
using System.Collections.Generic;

namespace Two.Generics.Type_Constraints
{
    class MethodConstraints
    {
        public static bool Equal<T>(T a, T b) where T : IComparable<T>
            => a.CompareTo(b) == 0;
    }



    interface IMethod
    {
        int Method<A>(A a, A b) where A : IComparable<A>;
    }

    class Method : IMethod
    {
        // Inherits the interface's constraints
        int IMethod.Method<A>(A a, A b) /*where A : ICollection<A>*/
            => a.CompareTo(b);
    }




    class Base
    {
        public virtual void Method<T>(T t)
            where T : IComparable<T> { }
    }

    class Derived : Base
    {
        // Inherits the base version's constraints and thus
        // Constraints may not be repeated on overriding members
        public override void Method<T>(T t) /*where T : IComparable<T>*/
        { }

    }


}

/*
    Additional constraints could break polymorphism,
        so they are not allowed
*/
