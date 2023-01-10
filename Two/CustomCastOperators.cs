using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two
{
    internal struct Boty
    {
        public string Name { get; private set; }

        public Boty(string name)
        {
            Name = name;
        }

        public Boty(Bite bite)
            : this(bite.Name)
        { }
    }

    internal struct Bite
    {
        public string Name { get; private set; }


        public Bite(string name)
        {
            Name = name;
        }

        public Bite(Boty boty)
            : this(boty.Name)
        { }


        // Boty = (Boty) Bite
        public static implicit operator Boty(Bite bite)
            => new Boty(bite);

        // Bite = (Bite) Boty
        public static implicit operator Bite(Boty boty)
            => new Bite(boty);
    }

    internal class CustomCastOperators : object
    {
        private static void Start()
        {
            var boty = new Boty("Boty");
            var bite = new Bite("Bite");

            Console.WriteLine("Boty -> Bite");
            Console.WriteLine(((Bite) boty).GetType());

            Console.WriteLine("Bite -> Boty");
            Console.WriteLine(((Boty) bite).GetType());

            Console.Read();
        }
    }
}
