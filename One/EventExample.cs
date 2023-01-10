using System;
using static System.Console;

namespace One
{
    internal class Publisher : object
    {
        public delegate void ReactionsEventHandler(object source, EventArgs args);
        public event ReactionsEventHandler Reactions;

        public void Kill()
        {
            WriteLine("Bang!");

            FireReactionsEvent();
        }

        public void FireReactionsEvent()
        {
            if (Reactions != null)
                Reactions(this, EventArgs.Empty);
        }
    }

    internal class SubscriberSad : object
    {
        public void OnReact(object source, EventArgs args)
        {
            WriteLine("Shit, I'm so sad");
        }
    }

    internal class SubscriberAngry : object
    {
        public void OnReact(object source, EventArgs args)
        {
            WriteLine("Shit, I'm so angry");
        }
    }

    internal class SubscriberIndifferent : object
    {
        public void OnReact(object source, EventArgs args)
        {
            WriteLine("hm");
        }
    }

    internal class EventExample : object
    {
        private static void main()
        {
            var publisher = new Publisher();
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