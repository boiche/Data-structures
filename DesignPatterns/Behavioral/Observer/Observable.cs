using System;

namespace DesignPatterns.Behavioral.Observer
{
    /// <summary>
    /// Denotes a property to be part of a notification package for every subscriber.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    sealed class Observable : Attribute
    {

    }
}
