namespace Miscellaneous.IoC_Container
{
    public class Container
    {
        private readonly Dictionary<Type, Type> _types = new();

        public void Register<TInterfaceService, TService>() where TInterfaceService : IServiceProvider
        {
            _types[typeof(TInterfaceService)] = typeof(TService);
        }

        public IServiceProvider Create()
        {
            return (IServiceProvider)Create(typeof(IServiceProvider));
        }

        private object Create(Type type)
        {
            var concreteType = _types[type];
            var constructor = concreteType.GetConstructors().First();
            var constructorParams = constructor.GetParameters();
            var parameters = constructorParams.Select(p => Create(p.ParameterType)).ToArray();

            return constructor.Invoke(parameters);
        }
    }
}
