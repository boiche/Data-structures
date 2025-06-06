﻿using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.DependencyInjection
{
    /// <summary>
    /// Model for user
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<object> Work { get; set; }
    }
}
