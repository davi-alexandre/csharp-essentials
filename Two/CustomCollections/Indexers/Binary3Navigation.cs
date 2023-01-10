using System;

namespace Two.CustomCollections.Indexers
{
    class Binary3Navigation
    {
        // USAGE: tree[PairItem.Second, PairItem.First].Value

        public enum PairItem
        {
            First, Second
        }
        public struct Pair<T>
        {
            public T this[PairItem index]
            {
                get
                {
                    switch(index)
                    {
                        case PairItem.First:
                            return First;
                        case PairItem.Second:
                            return Second;
                        default:
                            throw new NotImplementedException(
                                $"The enum { nameof(PairItem) } has not been implemented");
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
        }

        internal class BinaryTree<T>
        {
            public BinaryTree<T> this[params PairItem[] branches]
            {
                get
                {
                    BinaryTree<T> currentNode = this;

                    int totalLevels = branches?.Length ?? 0;
                    int currentLevel = 0;

                    while (currentLevel < totalLevels)
                    {
                        currentNode = currentNode.SubItems[branches[currentLevel]];
                        if (currentNode == null)
                            throw new IndexOutOfRangeException();

                        currentLevel++;
                    }
                    return currentNode;
                }
            }
            
            public Pair<BinaryTree<T>> SubItems { get; }
        }
    }
}
