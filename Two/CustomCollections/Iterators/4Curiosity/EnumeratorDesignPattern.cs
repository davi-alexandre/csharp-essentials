using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Two.CustomCollections.Iterators
{
    class EnumeratorDesignPattern
    {
        public class Starter
        {
            public static void Start()
            {
                var collection = new MyCollection("Davi", "Alexandre");
                
                IEnumerator<string> enumerator = collection.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    Console.WriteLine(enumerator.Current);
                }
            }
        }

        class MyCollection : IEnumerable<string>
        {
            public MyCollection (string first, string second)
            {
                First = first;
                Second = second;
            }

            public string First { get; set; }
            public string Second { get; set; }

            public virtual IEnumerator<string> GetEnumerator()
            {
                var enumerator = new MyEnumerator(0);
                enumerator._Collection = this;
                return enumerator;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private sealed class MyEnumerator : IEnumerator<string>
            {
                public MyEnumerator(int startAt)
                {
                    _ItemCount = startAt;
                }

                public string Current
                {
                    get
                    {
                        return _Current;
                    }
                }
                object IEnumerator.Current
                {
                    get
                    {
                        return Current;
                    }
                }
                
                public MyCollection _Collection;
                string _Current;
                int _ItemCount;
                
                public bool MoveNext()
                {
                    switch(_ItemCount)
                    {
                        case 0:
                            _Current = _Collection.First;
                            _ItemCount++;
                            return true;
                        case 1:
                            _Current = _Collection.Second;
                            _ItemCount++;
                            return true;
                        default:
                            return false;
                    }
                }

                public void Reset()
                {
                    throw new NotImplementedException();
                }

                #region IDisposable Support
                private bool disposedValue = false; // To detect redundant calls

                void Dispose(bool disposing)
                {
                    if (!disposedValue)
                    {
                        if (disposing)
                        {
                            // TODO: dispose managed state (managed objects).
                        }

                        // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                        // TODO: set large fields to null.

                        disposedValue = true;
                    }
                }

                // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
                // ~MyEnumerator() {
                //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                //   Dispose(false);
                // }

                // This code added to correctly implement the disposable pattern.
                public void Dispose()
                {
                    // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
                    Dispose(true);
                    // TODO: uncomment the following line if the finalizer is overridden above.
                    // GC.SuppressFinalize(this);
                }
                #endregion

            }
        }
    }
}
