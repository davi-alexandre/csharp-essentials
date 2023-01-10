using System;
using static System.Console;

namespace Two.Events
{
    internal class WeaponEventArgs : EventArgs
    {
        public string Weapon { get; set; }
    }

    internal class publisher1 : object
    {
        // public delegate void ReactionsEventHandler(object source, WeaponEventArgs args);
        // public event ReactionsEventHandler Reactions;
        // is equivalent to...
        public event EventHandler<WeaponEventArgs> Reactions;


        private string Weapon { get; set; } = "Pistol";

        public void Kill()
        {
            WriteLine("Bang!");

            FireReactionsEvent();
        }

        protected virtual void FireReactionsEvent()
        {
            if (Reactions != null)
                Reactions(this, new WeaponEventArgs() { Weapon = this.Weapon });
        }
    }

    internal class SubscriberSad : object
    {
        public void OnReact(object source, WeaponEventArgs args)
        {
            WriteLine("Oh no :(");
        }
    }

    internal class SubscriberAngry : object
    {
        public void OnReact(object source, WeaponEventArgs args)
        {
            WriteLine("I hate that " + args.Weapon);
        }
    }

    internal class SubscriberIndifferent : object
    {
        public void OnReact(object source, WeaponEventArgs args)
        {
            WriteLine("Oh");
        }
    }

    internal class EventExample : object
    {
        public static void main()
        {
            var publisher = new publisher1();
            var sad = new SubscriberSad();
            var angry = new SubscriberAngry();
            var indifferent = new SubscriberIndifferent();

            publisher.Reactions += sad.OnReact;
            publisher.Reactions += angry.OnReact;
            publisher.Reactions += indifferent.OnReact;

            publisher.Kill();

            Read();
        }
    }
}