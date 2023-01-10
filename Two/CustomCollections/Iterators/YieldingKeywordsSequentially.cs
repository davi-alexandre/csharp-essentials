using System;
using System.Collections; // For the non-generic IEnumerator
using System.Collections.Generic;


namespace Two.CustomCollections.Iterators
{
    class Starter
    {
        public static void Start()
        {
            CSharpBuiltInTypes Keywords = new CSharpBuiltInTypes();
            foreach (string keyword in Keywords)
                Console.WriteLine(keyword);
        }
    }

    class CSharpBuiltInTypes : IEnumerable<string>
    {
        public IEnumerator<string> GetEnumerator()
        {
            yield return "object";
            yield return "byte";
            yield return "uint";
            yield return "ulong";
            yield return "float";
            yield return "char";
            yield return "bool";
            yield return "ushort";
            yield return "decimal";
            yield return "int";
            yield return "sbyte";
            yield return "short";
            yield return "long";
            yield return "void";
            yield return "double";
            yield return "string";
        }

        // The IEnumerable.GetEnumerator method is also required
        // because IEnumerable<T> derives from IEnumerable.
        IEnumerator IEnumerable.GetEnumerator()
            => GetEnumerator();
        // Invoke IEnumerator<string> GetEnumerator() above.

        /*
        Since the signatures for both GetEnumerator()s are identical (the
return type does not distinguish a signature), one or both implementations
must be explicit. Given the additional type safety offered by IEnumerable<T>’s
version, you implement IEnumerable’s implementation explicitly.
        */
    }
}