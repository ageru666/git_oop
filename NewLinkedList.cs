using System.Collections;
// https://codereview.stackexchange.com/questions/138142/linked-list-in-c
// used that implementation of LinkedList as base, because of the lack of time
namespace Lab1_Voloshin.Sorting
{
    public class Node<T>
    {
        public T data;
        public Node<T> next;
    }

    internal class NewLinkedList<T> : IEnumerable<T>, IEnumerable
    {
        private Node<T> headNode;
        private int count;
        public int Count { get { { return count; } } }
        public NewLinkedList()
        {
            headNode = null;
            count = 0;
        }
        public NewLinkedList(IEnumerable<T> Items)
        {
            foreach (T item in Items)
                AddHead(item);
        }

        private IEnumerable<Node<T>> Nodes
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

        private Node<T> NodeAt(int index)
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

        public void ForEach(Action<T> action)
        {
            foreach (Node<T> item in Nodes)
            {
                action(item.data);
            }
        }

        public void AddRange(IEnumerable<T> Items)
        {
            foreach (T item in Items)
            {
                AddHead(item);
            }
        }

        public void AddRange(params T[] Items)
        {
            foreach (T item in Items)
            {
                AddHead(item);
            }
        }

        public T this[int index]
        {
            get { return NodeAt(index).data; }
            set { NodeAt(index).data = value; }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (Node<T> item in Nodes)
            {
                yield return item.data;
            }
        }

        public bool Exists(T value)
        {
            foreach (Node<T> item in Nodes)
            {
                if (Comparer<T>.Default.Compare(value, item.data) == 0)
                    return true;
            }
            return false;
        }

        public void Clear()
        {
            headNode = null;
            count = 0;
        }

        public void Shuffle()
        {
            if (headNode != null)
            {
                Random rRand = new Random();
                T[] aResult = new T[count];
                int i = 0;

                foreach (Node<T> nItem in Nodes)
                {
                    int j = rRand.Next(i + 1);
                    if (i != j)
                        aResult[i] = aResult[j];

                    aResult[j] = nItem.data;
                    i++;
                }
                this.Clear();
                this.AddRange(aResult);
            }
        }

        public void MergeSort() => headNode = MergeSortSub(headNode);

        private Node<T> MergeSortSub(Node<T> nHead)
        {
            if (nHead == null || nHead.next == null) { return nHead; }
            Node<T> nSeeker = nHead;
            Node<T> nMiddle = nSeeker;
            while (nSeeker.next != null && nSeeker.next.next != null)
            {
                nMiddle = nMiddle.next;
                nSeeker = nSeeker.next.next;
            }
            Node<T> sHalf = nMiddle.next;
            nMiddle.next = null;
            Node<T> nFirst = MergeSortSub(nHead);
            Node<T> nSecond = MergeSortSub(sHalf);
            Node<T> nResult = new Node<T>();
            Node<T> nCurrent = nResult;
            while (nFirst != null && nSecond != null)
            {
                IComparer<T> comparer = Comparer<T>.Default;
                if (comparer.Compare(nFirst.data, nSecond.data) < 1)
                {
                    nCurrent.next = nFirst;
                    nFirst = nFirst.next;
                }
                else
                {
                    nCurrent.next = nSecond;
                    nSecond = nSecond.next;
                }
                nCurrent = nCurrent.next;
            }
            nCurrent.next = (nFirst == null) ? nSecond : nFirst;
            return nResult.next;
        }

        public void AddHead(T item)
        {
            Node<T> NewNode = new Node<T>() { data = item, next = headNode };
            headNode = NewNode;
            count++;
        }

        public IEnumerable<int> AllIndexesOf(T Value)
        {
            int IndexCount = 0;
            foreach (Node<T> item in Nodes)
            {
                if (Comparer<T>.Default.Compare(item.data, Value) == 0)
                    yield return IndexCount;
                IndexCount++;
            }
        }

        public int IndexOf(T Value)
        {
            IEnumerator<int> eN = AllIndexesOf(Value).GetEnumerator();
            if (eN.MoveNext())
                return eN.Current;

            return -1;
        }

        public int LastIndexOf(T Value)
        {
            IEnumerator<int> eN = AllIndexesOf(Value).GetEnumerator();
            int Result = -1;
            while (eN.MoveNext())
                Result = eN.Current;

            return Result;
        }

        public void RemoveAll(Func<T, bool> match)
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

        public IEnumerable<T> Find(Predicate<T> match)
        {
            foreach (Node<T> item in Nodes)
            {
                if (match(item.data))
                    yield return item.data;
            }
        }

        public void Reverse()
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

        public void RemoveFirst()
        {

            if (headNode != null)
            {
                headNode = headNode.next;
                count--;
            }
        }

        public void RemoveLast()
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

        public void AddLast(T item)
        {
            Node<T> NewNode = new Node<T>() { data = item, next = null };
            if (headNode == null)
                headNode = NewNode;
            else
                NodeAt(Count - 1).next = NewNode;

            count++;
        }

        public void Insert(T item, int index)
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

        public void RemoveAt(int index)
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

        public void RemoveRange(int index, int count)
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
