using System;

namespace Two.Generics.TypeConstraints
{
    internal interface IPair<T>
    {
        T First { get; }
        T Second { get; }
    }
    internal struct Pair<T> : IPair<T>
    {
        public T First { get; }
        public T Second { get; }
    }


    internal class BinaryTree<T>
        where T : IComparable<T>    // interface type constraint
    {
        public T Item { get; set; }

        private Pair<BinaryTree<T>> _SubItems;
        public Pair<BinaryTree<T>> SubItems
        {
            get { return _SubItems; }
            set
            {
                IComparable<T> first;
                first = value.First.Item;   // this constraint hides the need for casting
                                            // even when the member is implemented explicitly

                if (first.CompareTo(value.Second.Item) < 0)
                {
                    // first is less than second
                }
                else
                {
                    // first is greater or equal to second
                }
                _SubItems = value;
            }
        }
    }
}