using System.Collections;

namespace Lab1.Sorting
{
    public class NewList<T> : IIndexInterface<T>, IEnumerable<T>, IEnumerator<T>
    {
        int count = 0;
        public int Count { get => count; }

        T[] array = new T[1];
        public T[] Array { get => array; }
        int index = -1;

        public void Clear()
        {
            array = new T[1];
            count = 0;
            index = -1;
        }

        public T Min()
        {
            dynamic smallest = array[0];
            for (int i = 0; i < count; i++)
            {
                if (array[i] < smallest)
                    smallest = array[i];
            }
            return smallest;
        }

        public T Max()
        {
            dynamic largest = array[count];
            for (int i = 0; i < count; i++)
            {
                if (array[i] > largest)
                    largest = array[i];
            }
            return largest;
        }

        public bool Contains(T value)
        {
            foreach (T elment in array)
            {
                if (elment.Equals(value))
                    return true;
            }
            return false;
        }

        public void Add(T mass)
        {
            count++;
            System.Array.Resize(ref array, count);
            index++;
            array[index] = mass;
        }
        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }


        #region interface implemetation
        int position = -1;
        public bool MoveNext()
        {
            position++;
            return position < array.Length;
        }

        public void Reset() => position = -1;

        public T Current
        {
            get { try { return array[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }

        object IEnumerator.Current => Current;
        public IEnumerator GetEnumerator() => array.GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)array).GetEnumerator();
        public void Dispose() => Dispose();
        #endregion
    }
}
