using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Two.Collection_Interfaces
{
    class EnumeratorIteration
    {
        // Collection => class that implements at least IEnumerable<T>
        // IEnumerable is the minimum needed to support iterating over the collection

        public static void Start()
        {
            var stack = new Stack<int>();
            stack.Push(1);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(5);

            using (Stack<int>.Enumerator enumerator = stack.GetEnumerator())
            {
                while (enumerator.MoveNext())
                    Console.WriteLine(enumerator.Current);
            }
        }
    }
}
