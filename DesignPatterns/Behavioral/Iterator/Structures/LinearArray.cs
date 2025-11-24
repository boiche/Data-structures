using DesignPatterns.Behavioral.Iterator.Enumerators;
using DesignPatterns.Behavioral.Iterator.Interfaces;

namespace DesignPatterns.Behavioral.Iterator.Structures
{
    public class LinearArray<T> : IEnumerable<T>
    {
        private readonly LinearEnumerator<T> _enumerator;
        private readonly T[] _source;
        public LinearArray(int length)
        {
            _source = new T[length];
            _enumerator = new(_source);
        }
        public T this[int index]
        {
            get { return _source[index]; }
            set { _source[index] = value; }
        }
        public IEnumerator<T> GetEnumerator() => _enumerator;        
    }
}
