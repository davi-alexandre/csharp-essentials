using System;
using System.Diagnostics;

namespace Two.Reflection
{
    class TypeOf
    {
        public static void Start()
        {
            ThreadPriorityLevel priority;

            priority = (ThreadPriorityLevel)
                Enum.Parse(typeof(ThreadPriorityLevel), "Idle");
        }
    }
}
