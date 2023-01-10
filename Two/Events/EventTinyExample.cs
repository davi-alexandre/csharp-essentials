using System;

namespace Two.Events
{
    class EventTinyExample
    {

        class Shouter
        {
            public event EventHandler OnShout = delegate { };

            public void Shout() => OnShout(this, EventArgs.Empty);
        }

        public static void Start()
        {
            var shouter = new Shouter();

            // Subscribing event-handlers
            shouter.OnShout += (src, args) => Console.WriteLine("Yeah, I heard that.");
            shouter.OnShout += (src, args) => Console.WriteLine("Me too...");

            shouter.Shout();
        }

    }
}
