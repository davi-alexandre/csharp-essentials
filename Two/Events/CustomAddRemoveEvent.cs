using System;

namespace Two.Events
{
    class CustomAddRemoveEvent
    {
        public event EventHandler<EventArgs> OnChange
        {
            add
            {
                // switches param. pos.: LAST ADDED => FIRST NOTIFIED (like LIFO)
                System.Delegate.Combine(value, _OnChange);
            }
            remove
            {
                System.Delegate.Remove(_OnChange, value);
            }
        }
        protected EventHandler<EventArgs> _OnChange;    // this delegate is private by default
    }
}
