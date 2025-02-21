using System;

namespace DesignPatterns.Behavioral.Observer
{
    public class Source
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public DateTime Sent { get => DateTime.Now; }
    }
}