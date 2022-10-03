using System.Collections;

namespace Lab1_Voloshin.Sorting
{
    internal struct NewArray<T> : IEnumerable<T>, IEnumerator<T> //interfaces for loops
    {
        int count = 0;
        public int Count { get => count; } // array size
        T[] array;
        public T[] Array { get => array; } // array size


        public NewArray(int size = 1)
        {
            array = new T[size];
            count = array.Length;
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

        public T this[int index]  //indexator
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

        #region Sorting




        public void CombSort()
        {
            int arrayLength = count;
            int currentStep = arrayLength - 1;
            dynamic? value;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < array.Length; i++)
                {
                    value = array[i];
                    if (value > array[i + currentStep])
                    {
                        Swap(ref array[i], ref array[i + currentStep]);
                    }
                }
                currentStep = GetNextStep(currentStep);
            }

            //bubble sort
            for (int i = 1; i < arrayLength; i++)
            {
                bool swapFlag = false;
                for (int j = 0; j < arrayLength - i; j++)
                {
                    value = array[j];
                    if (value > array[j + 1])
                    {
                        Swap(ref array[j], ref array[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                    break;
            }
        }
        int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }
        void Swap(ref T value1, ref T value2)
        {
            dynamic temp = value1;
            value1 = value2;
            value2 = temp;
        }






        #endregion
    }
}
