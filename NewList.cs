using System.Collections;

namespace Lab1.Sorting
{
    public class NewList<T> : IIndexInterface<T>, IEnumerable<T>, IEnumerator<T>///custom list class with interfaces for loops
    {
        public NewList(int size)///create new list
        {
            array = new T[size];
            count = size;
        }

        int count = 0;
        public int Count { get => count; }

        T[] array = new T[1];
        public T[] Array { get => array; }
        int index = -1;

        public void Clear()///clear list
        {
            array = new T[1];
            count = 0;
            index = -1;
        }

        public T Min()///finding the minimum element in an array
        {
            dynamic smallest = array[0];
            for (int i = 0; i < count; i++)
            {
                if (array[i] < smallest)
                    smallest = array[i];
            }
            return smallest;
        }

        public T Max()///finding the maximum element in an array
        {
            dynamic largest = array[count];
            for (int i = 0; i < count; i++)
            {
                if (array[i] > largest)
                    largest = array[i];
            }
            return largest;
        }

        public bool Contains(T value)///check for contatining elements in array
        {
            foreach (T elment in array)
            {
                if (elment.Equals(value))
                    return true;
            }
            return false;
        }

        public void Add(T mass)///added element to array
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
