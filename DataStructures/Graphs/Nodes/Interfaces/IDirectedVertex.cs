namespace DataStructures.Graphs.Nodes.Interfaces
{
    internal interface IDirectedVertex : IVertex
    {
        public INode Source { get; }
        public INode Destination { get; }
    }
}
