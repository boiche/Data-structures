using DesignPatterns.Creational.FactoryMethod.Classic.Misc;
using DesignPatterns.Creational.FactoryMethod.Classic.Misc.Interfaces;
using System;

namespace DesignPatterns.Creational.FactoryMethod.Static
{
    public class StaticFactory
    {
        private static Func<object, ITravel> _trainTravelFactoryMethod = (args) =>
        {
            //do some stuff with args
            return new TrainTravel();
        };
        private static Func<object, ITravel> _planeTravelFactoryMethod = (args) =>
        { 
            //do some stuff with args
            return new PlaneTravel();
        };
        public static ITravel Create(dynamic options)
        {
            if (options.Type == "train")
            {
                //do some stuff
                return _trainTravelFactoryMethod(options);
            }
            else if (options.Type == "plane")
            {
                //do some stuff
                return _planeTravelFactoryMethod(options);
            }
            else
                throw new NotSupportedException($"No logic for type {options.Type} is available");
        }
    }
}
