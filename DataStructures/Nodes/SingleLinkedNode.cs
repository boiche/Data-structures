using DataStructures.Linear.LinkedLists;

namespace DataStructures.Nodes
{
    public class SingleLinkedNode<T>
    {
        public T Value { get; set; }
        public SingleLinkedNode<T> NextNode { get; private set; }
        public SingleLinkedList<T> Owner { get; private set; }

        public SingleLinkedNode(T value, SingleLinkedNode<T> nextNode = null)
        {
            Value = value;
            NextNode = nextNode;
        }

        public SingleLinkedNode(T value, SingleLinkedList<T> list, SingleLinkedNode<T> nextNode = null) : this(value, nextNode)
        {
            Owner = list;
        }

        internal void LinkNode(SingleLinkedNode<T> node) => NextNode = node;

        internal void UnlinkNode() => NextNode = null;
    }
}
