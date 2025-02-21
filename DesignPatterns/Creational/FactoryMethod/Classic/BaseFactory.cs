using DesignPatterns.Creational.FactoryMethod.Classic.Misc.Interfaces;
using System;

namespace DesignPatterns.Creational.FactoryMethod.Classic
{
    public abstract class BaseFactory
    {
        public abstract ITravel CreateTravel();
        public void CheckCreated()
        {
            var travel = CreateTravel();
            Console.WriteLine($"Current factory resulted in new object of type {travel.GetType().Name}");
        }
    }
}
