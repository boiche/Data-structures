using System.Collections.Generic;

namespace DesignPatterns.Creational.DependencyInjection
{
    /// <summary>
    /// This service provides members that can be implemented via the dependencies
    /// </summary>
    public interface IService
    {
        List<User> SelectAllClients();
    }
}
