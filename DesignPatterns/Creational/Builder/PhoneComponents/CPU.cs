namespace DesignPatterns.Creational.Builder.PhoneComponents
{
    public class CPU
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public byte Cores { get; set; }
        /// <summary>
        /// Average clock speed
        /// </summary>
        public float ClockSpeed { get; set; }
    }
}
