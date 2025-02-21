namespace DesignPatterns.Creational.Singleton
{
    public class CustomSingleton
    {
        private static CustomSingleton _instance;
        private static readonly object _lockObject = new();
        private CustomSingleton() { }
        public static CustomSingleton Instance 
        { 
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new CustomSingleton();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
