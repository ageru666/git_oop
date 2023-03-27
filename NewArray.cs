using System.Collections;

namespace Lab1.Sorting 
{
    public interface IIndexInterface<T>///interface for indexator pattern
    {
        public T this[int index]
        {
            get;
            set;
        }
    }

    internal struct NewArray<T> : IIndexInterface<T>, IEnumerable<T>, IEnumerator<T> ///custom array class with interfaces for loops
    {
        int count = 0;
        public int Count { get => count; } // array size
        T[] array;
        public T[] Array { get => array; } // array size


        public NewArray(int size = 1)/// constructor
        {
            array = new T[size];
            count = array.Length;
        }

        public T Min() ///finding the minimum element in an array
        {
            dynamic smallest = array[0];
            for (int i = 0; i < count; i++)
            {
                if (array[i] < smallest)
                    smallest = array[i];
            }
            return smallest;
        }

        public T Max() ///finding the maximum element in an array
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

        public T this[int index]  ///indexator
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        #region interface implemetation
        int position = -1;

        public T Current
        {
            get { try { return array[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }

        object IEnumerator.Current => Current;

        public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>)array).GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => array.GetEnumerator();

        public bool MoveNext()
        {
            position++;
            return position < array.Length;
        }

        public void Reset() => position = -1;

        public void Dispose() => array = new T[0];

        #endregion

       
    }
}
