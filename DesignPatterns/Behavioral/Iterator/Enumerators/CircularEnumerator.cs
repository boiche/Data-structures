using DesignPatterns.Behavioral.Iterator.Interfaces;

namespace DesignPatterns.Behavioral.Iterator.Enumerators
{
    public class CircularEnumerator<T> : IEnumerator<T>
    {
        private readonly int _startIndex;
        private int _index;
        private bool _iteratorStarted;
        private readonly T[] _source;
        private T _current;
        public T Current => _current;

        public CircularEnumerator(T[] source, int startIndex)
        {
            _iteratorStarted = false;
            _startIndex = startIndex;
            _index = startIndex;
            _source = source;
        }

        public bool MoveNext()
        {
            if (_index + 1 > _source.Length)            
                _index = 0;

            if (_index == _startIndex)
            {
                if (_iteratorStarted)
                    return false;
                else
                    _iteratorStarted = true;
            }                

            _current = _source[_index++];
            return true;
        }

        public void Reset()
        {
            _index = _startIndex;
            _current = _source[_index];
        }
    }
}
