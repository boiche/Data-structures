namespace DesignPatterns.Creational.Prototype
{
    public interface ICloneable
    {
        public ICloneable DeepClone();
        public ICloneable ShallowClone();
    }
}
