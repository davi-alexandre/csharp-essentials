using System;
using System.Collections.Generic;
using static System.Console;

class Publisher
{
    public Publisher(bool setUp)
    {
        Change = setUp;
    }

    /* 
        delegate{}  is an empty delegate of a collection of zero subscribers
        empty   =>  not null
                =>  Assuming null is never assigned, there will be no need 
                    to check for null whenever the code invokes the delegate.
    */
    public event EventHandler<EventArgs> OnChange = delegate { }; // publisher

    public bool Change
    {
        get { return _Change; }
        set
        {
            if (value != _Change)
            {
                _Change = value;

                OnChange(this, EventArgs.Empty); // no need to check for null

                /*
                var exceptionList = new List<Exception>();
                foreach (EventHandler<EventArgs> handler in OnChange.GetInvocationList())
                {
                    try
                    {
                        handler(this, EventArgs.Empty);
                    }
                    catch (Exception e)
                    {
                        exceptionList.Add(e);
                    }
                }

                if (exceptionList.Count > 0)
                {
                    throw new AggregateException("There were exceptions" +
                                "thrown by OnTemperatureChange Event subscribers", exceptionList);
                } 
                */
            }
        }
    }
    private bool _Change;
}

class Subscriber
{
    public void OnChanged(object source, EventArgs args)
    {
        WriteLine("Event Fired");
    }
}

class Starter
{
    public static void Start()
    {
        var publisher = new Publisher(true);
        var subscriber = new Subscriber();
        
        publisher.OnChange += subscriber.OnChanged;

        publisher.Change = false;
    }
}