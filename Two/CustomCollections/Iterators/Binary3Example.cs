using System;
using System.Collections;
using System.Collections.Generic;

namespace Two.CustomCollections.Iterators
{
    class Binary3Example
    {
        public static void Start()
        {
            TestTreeIterator();
        }
        
        static void TestTreeIterator()
        {
            // ME
            var myFamilyTree = new BinaryTree<string>("Davi Alexandre");

            myFamilyTree.SubItems = new Pair<BinaryTree<string>>(
                new BinaryTree<string>("\t"+"Mother"),        // First: Woman
                new BinaryTree<string>("\t"+"Father"));    // Second: Man

            // Mother's parents
            myFamilyTree[OrdPair.First].SubItems = new Pair<BinaryTree<string>>(
                new BinaryTree<string>("\t\t"+"Grandma 1"),
                new BinaryTree<string>("\t\t"+"Grandpa 1"));

            // Father's parents
            myFamilyTree[OrdPair.Second].SubItems = new Pair<BinaryTree<string>>(
                new BinaryTree<string>("\t\t"+"Grandma 2"),
                new BinaryTree<string>("\t\t"+"Grandpa 2"));

            foreach (string name in myFamilyTree)
                Console.WriteLine(name);
        }

        static void TestPairIterator()
        {
            var fullname = new Pair<string>("FirstName", "LastName");
            foreach (string name in fullname)
                Console.WriteLine(name);
        }
        



        public class BinaryTree<T> : IEnumerable<T>
        {
            public BinaryTree<T> this[params OrdPair[] indices]
            {
                get
                {
                    BinaryTree<T> currentNode = this;

                    int totalLevels = indices.Length;
                    int currentLevel = 0;

                    while (currentLevel < totalLevels)
                    {
                        if (currentNode != null)
                        {
                            currentNode = currentNode.SubItems[indices[currentLevel]];
                            currentLevel++;
                        }
                    }
                    return currentNode;
                }
            }
            public BinaryTree(T value)
            {
                Value = value;
            }

            #region IEnumerable<T>
            public IEnumerator<T> GetEnumerator() // Declaring iterator
            {
                yield return Value;

                if (SubItems != null)
                {
                    foreach (BinaryTree<T> tree in SubItems)
                    {
                        if (tree != null)
                        {
                            foreach (T value in tree) // recursive call to a child node.
                                yield return value;
                        }
                    }
                }
            }
            /*
                The code above creates new “nested” iterators as it traverses the binary tree.
                As a consequence, when the value is yielded by a node, the value is yielded by
            the node’s iterator, and then yielded by its parent’s iterator, and then yielded by
            its parent’s iterator, and so on, until it is finally yielded to the original loop
            by the root’s iterator.
                A value that is n levels deep must actually pass its value up a chain of n iterators.
                If the binary tree is relatively shallow, this is not typically a problem; however, an
            imbalanced binary tree can be extremely deep, and therefore expensive to iterate recursively
            */

            IEnumerator IEnumerable.GetEnumerator()
                => GetEnumerator();
            #endregion

            public T Value { get; }
            public Pair<BinaryTree<T>> SubItems { get; set; }
        }
        
        public class Pair<T> : IEnumerable<T>
        {
            public T this[OrdPair index]
            {
                get
                {
                    switch (index)
                    {
                        case OrdPair.First:
                            return First;
                        case OrdPair.Second:
                            return Second;
                        default:
                            throw new NotImplementedException();
                    }
                }
            }

            public Pair(T first, T second)
            {
                First = first;
                Second = second;
            }
            public T First { get; }
            public T Second { get; }


            #region IEnumerable
            public IEnumerator<T> GetEnumerator()
            {
                if (First == null || Second == null)
                    yield break;
                yield return First;
                yield return Second;
            }

            IEnumerator IEnumerable.GetEnumerator ()
                => GetEnumerator();
            #endregion
        }

        public enum OrdPair
        {
            First, Second
        }
    }
}

/*
------------------------------- STRUCT VS CLASS -------------------------------
    An interesting side effect of defining Pair<T> as a struct rather than a
class is that SubItems.First and SubItems.Second cannot be assigned directly,
even if the setter were public.
    If you modify the setter to be public, the following will produce a compile
error indicating that SubItems cannot be modified, “because it is not a variable”:
var myFamilyTree = new BinaryTree<string>("Davi Alexandre");

    The issue is that SubItems is a property of type Pair<T>, a struct.
Therefore, when the property returns the value, a copy of SubItems is made, and
assigning First on a copy that is promptly lost at the end of the statement
would be misleading. Fortunately, the C# compiler prevents this error.
To overcome the issue, 
    - don’t assign First, use class rather than struct for Pair<T>,
    - don’t create a SubItems property and instead use a field, or provide properties
in BinaryTree<T> that give direct access to SubItems members.

*/