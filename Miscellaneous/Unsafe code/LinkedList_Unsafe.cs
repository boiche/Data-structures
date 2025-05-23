using System.Text;

namespace Miscellaneous.Unsafe_code
{
    public unsafe class LinkedList_Unsafe
    {
        private Node* _head = null;
        private Node* _tail = null;

        public struct Node
        {
            public int data;
            public Node* next;

            public override string ToString()
            {
                return $"{data}";
            }
        }

        public void CreateNode(int data)
        {
            Node newNode = new Node()
            {
                data = data,
                next = null
            };
            Node* newNodePtr = &newNode;

            if (_head == null)
            {
                _head = newNodePtr;
                return;
            }
            Node* temp = _head;
            while (temp->next != null)
            {
                temp = temp->next;
            }
            temp->next = newNodePtr;
        }

        public Node* Reverse()
        {
            Node* previous = null;
            Node* current = _head;
            Node* next = null;

            while (current != null)
            {
                next = current->next;
                current->next = previous;
                previous = current;
                current = next;
            }

            return previous;
        }

        public string PrintList()
        {
            while (_head != null)
            {
                Console.WriteLine($"{((int)_head->data)}");
                _head = _head->next;
            }

            return string.Empty;
        }
    }
}
