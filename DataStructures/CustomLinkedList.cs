using System;

namespace DataStructures
{
    class Node<T>
    {
        public T value { get; set; }
        public Node<T> Next { get; set; }
    }
    public class CustomLinkedList<T> where T : IComparable
    {
        Node<T> First;
        public int Length { get; set; }

        public CustomLinkedList<T> Find(Func<T, bool> where)
        {
            var outputList = new CustomLinkedList<T>();
            var current = First;
            while(current != null)
            {
                if(where.Invoke(current.value))
                {
                    outputList.Add(current.value);
                }
                current = current.Next;
            }

            return outputList;
        }

        public void Add(T value, Delegate comparer = null)
        {
            if (Length < 1)
            {
                First = new Node<T>
                {
                    value = value,
                    Next = null
                };
                Length++;
                return;
            }
            var current = First;
            var next = First.Next;

            if (next == null)
            {
                First.Next = new Node<T>
                {
                    value = value,
                    Next = null
                };
                Length++;
                return;
            }

            while (current != null)
            {
                if (comparer != null && (int)comparer.DynamicInvoke(current.value, value) == 0)
                {
                    throw new InvalidOperationException("This LinkedList requires not duplicated items");
                }

                if (comparer == null && current.value.CompareTo(value) == 0)
                {
                    throw new InvalidOperationException("This LinkedList requires not duplicated items");
                }

                current = current.Next;
            }

            current = new Node<T>
            {
                value = value,
                Next = null
            };

            Length++;
        }

        public override string ToString()
        {
            var current = First;
            var text = "";
            while(current != null)
            {
                text += $" {current.value.ToString()}";
                current = current.Next;
            }

            return text;
        }
    }
}
