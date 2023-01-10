using System;
using static System.Console;

namespace Two
{
    internal interface IStudies
    {
        string Name { get; set; }
        int Age { get; set; }
    }
    internal class InstanceTesting : IStudies
    {
        // EXPLICIT IMPLEMENTATION
        // is basically an instance member 
        // of the instance's interface
        // can serve as a means of encapsulation
        string IStudies.Name { get; set; }
        // (instance as interface).Name = value;
        // ( (interface) instance).Name = value;

        
        
        // IMPLICIT IMPLEMENTATION
        // regard as a core part of the object ("model") itself
        public int Age { get; set; }
        // instance.Age = value;
    }
}
