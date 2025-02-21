using DesignPatterns.Creational.FactoryMethod.Classic.Misc.Interfaces;
using System;
using System.Runtime.ExceptionServices;

namespace DesignPatterns.Creational.FactoryMethod.Polymorphic
{
    public class TravelFactory
    {
        public virtual T CreateTravel<T>() where T : ITravel, new()
        {
            try
            {
                var result = new T();
                //do some stuff with result
                return result;
            }
            catch (Exception e)
            {
                var edi = ExceptionDispatchInfo.Capture(e);
                edi.Throw();
                return default;
            }
        }
    }
}
