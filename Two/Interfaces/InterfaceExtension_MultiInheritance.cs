using System;

namespace Two
{
    #region - Interface Extension -

    internal interface INamable
    {
        string Name { get; set; }
    }
    // Emulate multiple inheritance through interface extension
    internal static class NamableExtension
    {
        public static void GetName(this INamable instance)
        {
            Console.WriteLine(instance.Name);
        }
    }

    #endregion

    #region - Inheritance -

    // LifeForm ocupies the single-class inheritance spot
    abstract class LifeForm { }

    internal class Human : LifeForm, INamable
    {
        public Human(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    internal class Alien : LifeForm, INamable
    {
        public Alien(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }

    #endregion


    internal class Initiate
    {
        private static void Start()
        {
            // The interface's extended method acts
            // just like an inherited one

            var person = new Human("Davi");
            person.GetName();

            var alien = new Alien("Ford Prefect");
            alien.GetName();


            Console.Read();
        }
    }
}