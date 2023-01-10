using static System.Console;
using System;
using System.Reflection;

namespace Two.Reflection
{
    class GetType
    {
        public static void Start()
        {
            DateTime dt = new DateTime();

            Type type = dt.GetType();

            foreach (PropertyInfo property in type.GetProperties())
                WriteLine(property.Name);
        }
    }
}
