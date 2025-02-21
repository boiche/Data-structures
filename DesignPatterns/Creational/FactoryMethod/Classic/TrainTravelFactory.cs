using DesignPatterns.Creational.FactoryMethod.Classic.Misc;
using DesignPatterns.Creational.FactoryMethod.Classic.Misc.Interfaces;

namespace DesignPatterns.Creational.FactoryMethod.Classic
{
    public class TrainTravelFactory : BaseFactory
    {
        public override ITravel CreateTravel()
        {
            //do some train stuff
            return new TrainTravel();
        }
    }
}
