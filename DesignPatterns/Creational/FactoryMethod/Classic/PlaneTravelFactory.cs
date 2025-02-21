using DesignPatterns.Creational.FactoryMethod.Classic.Misc;
using DesignPatterns.Creational.FactoryMethod.Classic.Misc.Interfaces;

namespace DesignPatterns.Creational.FactoryMethod.Classic
{
    public class PlaneTravelFactory : BaseFactory
    {
        public override ITravel CreateTravel()
        {
            //do some plane stuff
            return new PlaneTravel();
        }
    }
}
