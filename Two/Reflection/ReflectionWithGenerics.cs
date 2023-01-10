using static System.Console;
using System;
using System.Reflection;
using System.Collections.Generic;

namespace Two.Reflection
{
    class ReflectionWithGenerics
    {
        public static void Start()
        {
            ContainsGenericParameters();
        }

        
        static void GetGenericArguments()
        {
            Stack<int> s = new Stack<int>();
            Type t = s.GetType();

            foreach (Type type in t.GetGenericArguments())
                WriteLine("Type parameter: " + type.FullName);
        }

        static void ContainsGenericParameters()
        {
        /*      You can determine whether a class or method contains generic
         *  parameters that have not yet been set by querying the 
         *  Type.ContainsGenericParameters property 
         */

            Type type;
            type = typeof(Nullable<>);
            WriteLine("Contains Generic Parameters: " + type.ContainsGenericParameters);
            WriteLine("Is a generic type: " + type.IsGenericType);

            type = typeof(Nullable<DateTime>);
            WriteLine("Contains Generic Parameters: " + type.ContainsGenericParameters);
            WriteLine("Is a generic type: " + type.IsGenericType);
        }

        static Type TypeOf<T>()
            => typeof(T);
    }
}
