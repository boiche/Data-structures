namespace DesignPatterns.Creational.Builder.PhoneBuilders.Interfaces
{
    public interface IPhoneBuilder<T> : IBuilder<T> where T : class
    {
        public IPhoneBuilder<T> BuildOS();
        public IPhoneBuilder<T> BuildCamera();
        public IPhoneBuilder<T> BuildProcessor();
    }
}
