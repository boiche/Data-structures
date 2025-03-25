namespace DataStructures.Graphs.Nodes.Interfaces
{
    public interface IWeightedNode<T, W> : INode<T>, IWeightedNode
    {
        public new W Weight { get; set; }
    }

    public interface IWeightedNode : INode
    {
        public object Weight { get; }
    }
}
