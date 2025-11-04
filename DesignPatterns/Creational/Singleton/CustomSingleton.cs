using System;

namespace DesignPatterns.Creational.Singleton
{
    public class CustomSingleton<T> where T : new()
    {
        private static T _instance;
        private static readonly object _lockObject = new();
        private CustomSingleton() { }
        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = (T)typeof(T).GetConstructor(Type.EmptyTypes).Invoke(null);
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
