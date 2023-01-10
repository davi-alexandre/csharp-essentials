using System;
using System.Collections;
using System.Collections.Generic;

namespace Two.CustomCollections.Iterators
{
    class YieldBreak : IEnumerable<string>
    {
        public string First { get; set; }
        public string Second { get; set; }

        #region IEnumerable
        public IEnumerator<string> GetEnumerator ()
        {
            if (First == null || Second == null)
                yield break; // Make MoveNext() return false
            yield return First;
            yield return Second;
        }

        IEnumerator IEnumerable.GetEnumerator ()
        {
            return GetEnumerator();
        }
        #endregion
    }
}
