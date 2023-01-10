using Two.Extension_Methods.Extensions;
/*
If this class were anywhere within the namespace
    of the extended method, the USING directive  
    would not be needed
*/

namespace Two.Extension_Methods.Test
{
    internal class InstanceTest : object
    {
        public static void Start(string name)
        {
            var instance = new Instance(name);
            instance.PrintName();
        }
    }
}
