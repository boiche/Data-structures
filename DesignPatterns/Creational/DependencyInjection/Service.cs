using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.DependencyInjection
{
    /// <summary>
    /// Contains data access layer logic. This class is dependency (can be DI since it implements IService interface)
    /// </summary>
    public class Service : IService
    {
        public List<User> SelectAllClients()
        {
            // select/parse from a source
            return new List<User>();
        }
    }
}
