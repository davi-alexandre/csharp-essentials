using System;
using System.Collections;
using System.Collections.Generic;

namespace Two.Generics.Type_Constraints
{
    class Private
    {
        private Private() { }
    }
    class Public
    {
        // has to be public and parameterless
        public Public() { }
    }

    
    class Generical<T>
        where T : new()
    {
        public static T GetInstance()
            => new T();
    }




    class Example
    {
        static void Start()
        {
            Public yes = Generical<Public>.GetInstance();
            var works = new Generical<Public>();

            // Private no = Generical<Private>.GetInstance();
            // var doesnt = new Generical<Private>();
        }
    }

}