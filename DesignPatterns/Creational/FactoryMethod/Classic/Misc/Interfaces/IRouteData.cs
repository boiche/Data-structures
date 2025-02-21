using System.Collections.Generic;

namespace DesignPatterns.Creational.FactoryMethod.Classic.Misc
{
    public interface IRouteData
    {
        public IEnumerable<Stop> Stops { get; }
    }
}