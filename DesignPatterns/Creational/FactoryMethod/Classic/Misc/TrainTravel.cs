using DesignPatterns.Creational.FactoryMethod.Classic.Misc.Interfaces;

namespace DesignPatterns.Creational.FactoryMethod.Classic.Misc
{
    internal class TrainTravel : ITravel
    {
        public TravelStatus Status { get; private set; }
        public IVehicle Vehicle { get; }
        public IRouteData RouteData { get; }

        public void Cancel() => Status = TravelStatus.Canceled;
        public void Finish() => Status = TravelStatus.Finished;
        public void Postpone() => Status = TravelStatus.Postponed;
    }
}
