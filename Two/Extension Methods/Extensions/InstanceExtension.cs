using System;

namespace Two.Extension_Methods.Extensions
{
    internal static class InstanceExtension : object
    {

        public static void PrintName(this Instance instance)
            => Console.WriteLine(instance.Name);
        
    }
}

/*
    This method will be accessible to an instance of
        the refered class, and that will get the instance
        as an argument for the method to use

    The scope of the extension method is limited
        to its namespace so, from outside it,
        a USING directive is necessary
*/
