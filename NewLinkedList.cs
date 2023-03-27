using System.Collections;
// https://codereview.stackexchange.com/questions/138142/linked-list-in-c
// used that implementation of LinkedList as base, because of the lack of time
namespace Lab1.Sorting
{
    public class Node<T>///class for one node
    {
        public T data;
        public Node<T> next;
    }

    internal class NewLinkedList<T> : IIndexInterface<T>, IEnumerable<T>, IEnumerable///custom linked list class with interfaces for loops
    {
        private Node<T> headNode;
        private int count;
        public int Count { get { { return count; } } }

        public NewLinkedList()///consturctor
        {
            headNode = null;
            count = 0;
        }

        public NewLinkedList(IEnumerable<T> Items)///constructor for filling with given collection
        {
            foreach (T item in Items)
                AddHead(item);
        }

        public NewLinkedList(int size)///constructor to create linked list with custom size
        {
            for (int i = 0; i < size; i++)
            {
                Node<T> NewNode = new Node<T>() { data = default, next = headNode };
                headNode = NewNode;
                count++;
            }
        }

        private IEnumerable<Node<T>> Nodes///get all nodes inside class
        {
            get
            {
                Node<T> node = headNode;
                while (node != null)
                {
                    yield return node;
                    node = node.next;
                }
            }
        }

        private Node<T> NodeAt(int index)///get node by index
        {
            if (index < 0 || index + 1 > count)
            {
                throw new IndexOutOfRangeException("Index");
            }
            int counter = 0;
            foreach (Node<T> item in Nodes)
            {
                if (counter == index)
                {
                    return item;
                }
                counter++;
            }
            return null;
        }


        public void AddRange(IEnumerable<T> Items)///add collection to the head
        {
            foreach (T item in Items)
            {
                AddHead(item);
            }
        }

        public void AddRange(params T[] Items)///add collection to the head
        {
            foreach (T item in Items)
            {
                AddHead(item);
            }
        }

        public T this[int index]///indexator
        {
            get { return NodeAt(index).data; }
            set { NodeAt(index).data = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (Node<T> item in Nodes)
            {
                yield return item.data;
            }
        }

        public bool Exists(T value)///check for containing value in collection
        {
            foreach (Node<T> item in Nodes)
            {
                if (Comparer<T>.Default.Compare(value, item.data) == 0)
                    return true;
            }
            return false;
        }

        public void Clear()///clear list
        {
            headNode = null;
            count = 0;
        }


        public void AddHead(T item)/// added head
        {
            Node<T> NewNode = new Node<T>() { data = item, next = headNode };
            headNode = NewNode;
            count++;
        }

        public IEnumerable<int> AllIndexesOf(T Value)///return collection of indexes of given element
        {
            int IndexCount = 0;
            foreach (Node<T> item in Nodes)
            {
                if (Comparer<T>.Default.Compare(item.data, Value) == 0)
                    yield return IndexCount;
                IndexCount++;
            }
        }

        public int IndexOf(T Value)///return index of given element
        {
            IEnumerator<int> eN = AllIndexesOf(Value).GetEnumerator();
            if (eN.MoveNext())
                return eN.Current;

            return -1;
        }

       

        public void RemoveAll(Func<T, bool> match)///delete list
        {
            while (headNode != null && match(headNode.data)) //  head node
            {
                headNode = headNode.next;
                count--;
            }
            if (headNode != null)
            {
                Node<T> nTemp = headNode;
                while (nTemp.next != null)// other nodes
                {
                    if (match(nTemp.next.data))
                    {
                        nTemp.next = nTemp.next.next;
                        count--;
                    }
                    else
                        nTemp = nTemp.next;
                }
            }
        }

        public IEnumerable<T> Find(Predicate<T> match)///find elemet by predicat
        {
            foreach (Node<T> item in Nodes)
            {
                if (match(item.data))
                    yield return item.data;
            }
        }

        public void Reverse()///list reverse
        {
            Node<T> nCurrent = headNode;
            Node<T> nBack = null;
            while (nCurrent != null)
            {
                Node<T> nTemp = nCurrent.next;
                nCurrent.next = nBack;
                nBack = nCurrent;
                nCurrent = nTemp;
            }
            headNode = nBack;
        }

        public void RemoveFirst()///remove element from the start
        {

            if (headNode != null)
            {
                headNode = headNode.next;
                count--;
            }
        }

        public void RemoveLast()///remove element from the end
        {
            if (headNode != null)
            {
                if (headNode.next == null)
                    headNode = null;
                else
                    NodeAt(Count - 2).next = null;

                count--;
            }
        }

        public void AddLast(T item)///add element to the end
        {
            Node<T> NewNode = new Node<T>() { data = item, next = null };
            if (headNode == null)
                headNode = NewNode;
            else
                NodeAt(Count - 1).next = NewNode;

            count++;
        }

        public void Insert(T item, int index)///insert element by index
        {
            if (index < 0 || index + 1 > count)
                throw new IndexOutOfRangeException("Index");

            Node<T> NewNode = new Node<T>() { data = item, next = null };
            if (index == 0)
            {
                NewNode.next = headNode;
                headNode = NewNode;
            }
            else
            {
                NewNode.next = NodeAt(index - 1).next;
                NodeAt(index - 1).next = NewNode;
            }
            count++;
        }

        public void RemoveAt(int index)///remove element by index
        {
            if (index < 0 || index + 1 > count)
                throw new IndexOutOfRangeException("Index");

            if (index == 0)
            {
                headNode = headNode.next;
            }
            else
            {
                Node<T> temp = NodeAt(index - 1);
                temp.next = temp.next.next;
            }
            count--;
        }

        public void RemoveRange(int index, int count)///remove element starting at index + counting
        {
            if (index < 0 || index + count > this.count)
                throw new IndexOutOfRangeException("Index");

            if (index == 0)
            {
                for (int i = 0; i < count; i++)
                    headNode = headNode.next;
            }
            else
            {
                Node<T> nStart = NodeAt(index - 1);
                for (int i = 0; i < count; i++)
                    nStart.next = nStart.next == null ? null : nStart.next.next;
            }
            this.count -= count;
        }
    }
}
