using System.Collections;

namespace Lab1_Voloshin
{
    public class MyList<T> : IEnumerable<T>, IEnumerator<T> // interfaces for acessing loops
    {
        int count = 0; 
        public int Count { get => count; } // array size

        T[] array = new T[1]; //list based on generic array
        public T[] Array { get => array; } // array size
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
            System.Array.Resize(ref this.array, count);
            index++; 
            this.array[index] = mass; 
        }
        public T this[int index]  //indexator, list[]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }

        #region interface implemetation
        int position = -1;
        public bool MoveNext() 
        {
            position++;
            return (position < array.Length);
        }

        public void Reset() => position = -1; 

        public T Current
        {
            get { try { return array[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
        }

        object IEnumerator.Current => Current;
        public IEnumerator GetEnumerator() => array.GetEnumerator();
        IEnumerator<T> IEnumerable<T>.GetEnumerator() => ((IEnumerable<T>)array).GetEnumerator();
        public void Dispose() => this.Dispose();
        #endregion

    }
}
