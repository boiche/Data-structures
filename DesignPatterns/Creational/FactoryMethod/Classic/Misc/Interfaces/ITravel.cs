namespace DesignPatterns.Creational.FactoryMethod.Classic.Misc.Interfaces
{
    /// <summary>
    /// Describes basic props and actions for a single travel
    /// </summary>
    public interface ITravel
    {
        public TravelStatus Status { get; }
        public IVehicle Vehicle { get; }
        public IRouteData RouteData { get; }
        public void Postpone();
        public void Cancel();
        public void Finish();
    }
}
