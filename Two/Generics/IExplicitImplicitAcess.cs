using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.Generics
{

    interface IAm
    {
        bool Cool { get; set; }
    }

    class Person : IAm
    {
        // Explicitly implemented
        bool IAm.Cool { get; set; } = true;
    }


    
/*  Type constraint => Implicit access to explicit
        interface type constraint members */
    static class JudgeOf<T> where T : IAm   // where T implements IAm (so I can use it's IAm members)
    {
        public static bool Judge(T me)
            => me.Cool = true;
    }


    static class JudgeOfPerson
    {
        public static bool Judge(Person me)
        {
            // Error ;)
            // me.Cool = false;
            return ((IAm) me).Cool;
        }
    }


    class Starter
    {
        static void main()
        {
            var eeRtL = new Person();
            Console.WriteLine(JudgeOf<Person>.Judge(eeRtL));
            Console.WriteLine(JudgeOfPerson.Judge(eeRtL));
            Console.ReadLine();
        }
    }
}
