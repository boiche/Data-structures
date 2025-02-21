using DesignPatterns.Creational.FactoryMethod.Classic.Misc.Interfaces;
using System;

namespace DesignPatterns.Creational.FactoryMethod.Classic.Misc
{
    internal class PlaneTravel : ITravel
    {
        public TravelStatus Status => throw new NotImplementedException();

        public IVehicle Vehicle => throw new NotImplementedException();

        public IRouteData RouteData => throw new NotImplementedException();

        public void Cancel()
        {
            throw new NotImplementedException();
        }

        public void Finish()
        {
            throw new NotImplementedException();
        }

        public void Postpone()
        {
            throw new NotImplementedException();
        }
    }
}
