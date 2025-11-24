using DesignPatterns.Behavioral.Iterator.Enumerators;
using DesignPatterns.Behavioral.Iterator.Interfaces;

namespace DesignPatterns.Behavioral.Iterator.Structures
{
    public class CircularArray<T> : IEnumerable<T>
    {
        private readonly CircularEnumerator<T> _enumerator;
        private readonly T[] _source;

        public CircularArray(int length, int startIndex)
        {
            _source = new T[length];
            _enumerator = new(_source, startIndex);
        }
        public T this[int index]
        {
            get { return _source[index]; }
            set { _source[index] = value; }
        }
        public IEnumerator<T> GetEnumerator() => _enumerator;        
    }
}
