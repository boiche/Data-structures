using DesignPatterns.Behavioral.Iterator.Interfaces;

namespace DesignPatterns.Behavioral.Iterator.Enumerators
{
    public class LinearEnumerator<T> : IEnumerator<T>
    {
        private readonly T[] _source;
        private T _current;
        private int _index;

        public LinearEnumerator(T[] source)
        {
            _source = source;
            _index = 0;
            _current = _source[_index];
        }
        public T Current { get => _current; }

        public bool MoveNext()
        {
            if (_index + 1 > _source.Length)
                return false;

            _current = _source[_index++];
            return true;
        }

        public void Reset()
        {
            _index = 0;
            _current = _source[_index];
        }
    }
}
