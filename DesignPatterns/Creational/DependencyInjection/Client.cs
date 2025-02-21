using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.DependencyInjection
{
    /// <summary>
    /// Contains business logic. This class is dependant
    /// </summary>
    public class Client
    {
        private IService _service;
        public IService Service 
        { 
            get
            {
                if (_service is null)
                    throw new NullReferenceException();
                else
                    return _service;
            }
            set => _service = value; // setter injection
        }

        // constructor injection
        public Client(IService service)
        {
            _service = service;
        }
        public List<User> GetUsers()
        {
            return _service.SelectAllClients();
        }

        // method injection
        [Obsolete("Better use constructor injection")]
        public List<User> GetUsers(IService service)
        {
            _service = service;
            return GetUsers();
        }
    }
}
