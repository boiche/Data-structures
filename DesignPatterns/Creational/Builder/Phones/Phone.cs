using DesignPatterns.Creational.Builder.PhoneBuilders.Interfaces;
using DesignPatterns.Creational.Builder.PhoneComponents;

namespace DesignPatterns.Creational.Builder.Phones
{
    public class Phone
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public ushort Year { get; set; }
        public Camera Camera { get; } = new Camera();
        public Memory Memory { get; } = new Memory();
        public OS OperatingSystem { get; } = new OS();
        public CPU CentralPowerUnit { get; } = new CPU();        
    }
}
