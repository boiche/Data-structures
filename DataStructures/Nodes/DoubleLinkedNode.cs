namespace DataStructures.Nodes
{
    public class DoubleLinkedNode<T>
    {
        public T Value { get; set; }
        public DoubleLinkedNode<T> NextNode { get; private set; }
        public DoubleLinkedNode<T> PrevNode { get; private set; }

        public DoubleLinkedNode(T value, DoubleLinkedNode<T> next = null, DoubleLinkedNode<T> prev = null)
        {            
            Value = value;
            NextNode = next;
            PrevNode = prev;
        }

        public void LinkNextNode(DoubleLinkedNode<T> next) => NextNode = next;
        public void LinkPrevNode(DoubleLinkedNode<T> prev) => PrevNode = prev;

        public void UnlinkNextNode() => NextNode = null;
        public void UnlinkPrevNode() => PrevNode = null;
    }
}
