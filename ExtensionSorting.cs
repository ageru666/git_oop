using System;

namespace Lab1_Voloshin.Sorting
{
    static class ExtensionSorting
    {
        static bool isRecursion = false;
        static bool CheckForCorrectClass(dynamic myClass)
        {
            if (myClass.GetType().Name == typeof(NewArray<>).Name ||
                myClass.GetType().Name == typeof(NewList<>).Name ||
                myClass.GetType().Name == typeof(NewLinkedList<>).Name) return true;

            Console.WriteLine("This methods made only for my custom generic classes");
            return false;
        }
        static dynamic Min(dynamic array)
        {
            dynamic smallest = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < smallest)
                    smallest = array[i];
            }
            return smallest;
        }
        static dynamic Max(dynamic array)
        {
            dynamic largest = array[array.Length - 1];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > largest)
                    largest = array[i];
            }
            return largest;
        }



        public static void InsertionSortGeneric<T>(this T myClass)
        {
            if (CheckForCorrectClass(myClass) == false) return;
            dynamic dynamicT = myClass;
            dynamic array = dynamicT.Array;

            int i, flag, arrSize = array.Length;
            dynamic operatingValue;

            for (i = 1; i < arrSize; i++)
            {
                operatingValue = array[i];
                if (operatingValue is null) break;

                flag = 0;
                for (int j = i - 1; j >= 0 && flag != 1;)
                {
                    if (operatingValue < array[j])
                    {
                        array[j + 1] = array[j];
                        j--;
                        array[j + 1] = operatingValue;
                    }
                    else
                    {
                        flag = 1;
                    }
                }
            }
        }

        public static void QuickSortGeneric<T>(this T myClass)
        {
            dynamic dynamicT = myClass;
            QuickSort<T>(myClass, dynamicT.Count - 1);
        }

        public static void QuickSort<T>(T myClass, int lastIndex, int startInd = 0)
        {
            isRecursion = true;
            if (CheckForCorrectClass(myClass) == false && isRecursion == false) return;
            dynamic dynamicT = myClass;
            dynamic array = dynamicT.Array;

            int i = startInd, j = lastIndex;
            dynamic flag = array[(startInd + lastIndex) / 2];
            while (i <= j)
            {
                while (array[i] < flag)
                    i++;

                while (array[j] > flag)
                    j--;

                if (i <= j)
                {
                    dynamic val = array[i];
                    array[i] = array[j];
                    array[j] = val;
                    i++;
                    j--;
                }
            }

            if (startInd < j)
                QuickSort(myClass, j, startInd);
            if (i < lastIndex)
                QuickSort(myClass, lastIndex, i);
            isRecursion = false;
        }

        public static void CountingSortGeneric<T>(this T myClass)
        {
            if (CheckForCorrectClass(myClass) == false) return;
            dynamic dynamicT = myClass;
            dynamic array = dynamicT.Array;

            var minVal = Min(array);
            var sortedArray = new dynamic[array.Length];
            int[] counts = new int[(int)(Max(array) - minVal + 1)];

            for (int i = 0; i < array.Length; i++)
                counts[(int)(array[i] - minVal)]++;
            counts[0]--;

            for (int i = 1; i < counts.Length; i++)
                counts[i] = counts[i] + counts[i - 1];

            for (int i = array.Length - 1; i >= 0; i--)
                sortedArray[counts[(int)(array[i] - minVal)]--] = array[i];

            for (int i = 0; i < array.Length; i++)
                array[i] = sortedArray[i];
        }

        public static void MergeSortGeneric<T>(this T myClass)
        {
            dynamic dynamicT = myClass;
            if ("MyLinkedList`1" == dynamicT.GetType().Name)
            {
                dynamicT.MergeSort();
                return;
            }

            isRecursion = true;
            dynamic arr = dynamicT.Array;
            if (CheckForCorrectClass(myClass) == false && isRecursion == false) return;

            MergeSortRecursion(0, dynamicT.Array.Length - 1, arr);

            isRecursion = false;
        }
        static void MergeSortRecursion(int left, int right, dynamic arr = default)
        {
            if (left < right)
            {
                var middle = left + (right - left) / 2;
                MergeSortRecursion(left, middle, arr);
                MergeSortRecursion(middle + 1, right, arr);
                MergeArr(arr, left, middle, right);
            }
        }
        static void MergeArr(dynamic arr, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new dynamic[leftArrayLength];
            var rightTempArray = new dynamic[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = arr[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = arr[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                    arr[k++] = leftTempArray[i++];
                else
                    arr[k++] = rightTempArray[j++];
            }
            while (i < leftArrayLength)
                arr[k++] = leftTempArray[i++];
            while (j < rightArrayLength)
                arr[k++] = rightTempArray[j++];
        }


        public static void CombSortGeneric<T>(this T myClass)
        {
            Console.WriteLine("Comb sort no implemented yet.");
            return;

            if (CheckForCorrectClass(myClass) == false) return;
            dynamic dynamicT = myClass;

            dynamic arr = dynamicT.Array;
            int arrayLength = arr.Length;
            int currentStep = arrayLength - 1;
            dynamic value;

            while (currentStep > 1)
            {
                for (int i = 0; i + currentStep < arr.Length; i++)
                {
                    value = arr[i];
                    if (value > arr[i + currentStep])
                    {
                        Swap(arr[i], arr[i + currentStep]);
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
                    value = arr[j];
                    if (value > arr[j + 1])
                    {
                        Swap(arr[j], arr[j + 1]);
                        swapFlag = true;
                    }
                }

                if (!swapFlag)
                    break;
            }
            dynamicT.Array = arr;
        }
        static int GetNextStep(int step)
        {
            step = step * 1000 / 1247;
            return step > 1 ? step : 1;
        }
        static void Swap<T>(T value1, T value2)
        {
            T temp = value1;
            value1 = value2;
            value2 = temp;
        }


        public static void BucketSortGeneric<T>(this T myClass)
        {
            if (CheckForCorrectClass(myClass) == false) return;
            dynamic dynamicT = myClass;
            dynamic array = dynamicT.Array;

            if (array == null || array.Length <= 1)
                return;

            dynamic maxValue = Max(array);
            dynamic minValue = Min(array);

            var bucket = new LinkedList<dynamic>[(int)(maxValue - minValue + 1)];
            for (int i = 0; i < array.Length; i++)
            {
                if (bucket[(int)(array[i] - minValue)] == null)
                    bucket[(int)(array[i] - minValue)] = new LinkedList<dynamic>();

                bucket[(int)(array[i] - minValue)].AddLast(array[i]);
            }
            var index = 0;

            for (int i = 0; i < bucket.Length; i++)
            {
                if (bucket[i] != null)
                {
                    LinkedListNode<dynamic> node = bucket[i].First;
                    while (node != null)
                    {
                        array[index] = node.Value;
                        node = node.Next;
                        index++;
                    }
                }
            }
        }

        // Algorithm was taken from this web-site https://en.wikibooks.org/wiki/Algorithm_Implementation/Sorting/Radix_sort and reworked to generic types
        public static void RadixSortGeneric<T>(this T myClass)
        {
            if (CheckForCorrectClass(myClass) == false) return;
            dynamic dynamicT = myClass;
            dynamic array = dynamicT.Array;

            // our helper array 
            dynamic t = new dynamic[array.Length];

            // number of bits our group will be long 
            int r = 4; // try to set this also to 2, 8 or 16 to see if it is 
                       // quicker or not 

            // number of bits of a C# int 
            int b = 32;

            // counting and prefix arrays
            // (note dimensions 2^r which is the number of all possible values of a 
            // r-bit number) 
            int[] count = new int[1 << r];
            int[] pref = new int[1 << r];

            // number of groups 
            int groups = (int)Math.Ceiling(b / (double)r);

            // the mask to identify groups 
            int mask = (1 << r) - 1;

            dynamic value = default;
            // the algorithm: 
            for (int c = 0, shift = 0; c < groups; c++, shift += r)
            {
                // reset count array 
                for (int j = 0; j < count.Length; j++)
                    count[j] = 0;

                // counting elements of the c-th group 
                for (int i = 0; i < array.Length; i++)
                {
                    value = array[i];
                    count[(int)value >> shift & mask]++;
                }

                // calculating prefixes 
                pref[0] = 0;
                for (int i = 1; i < count.Length; i++)
                    pref[i] = pref[i - 1] + count[i - 1];

                // from a[] to t[] elements ordered by c-th group 
                for (int i = 0; i < array.Length; i++)
                {
                    value = array[i];
                    t[pref[(int)value >> shift & mask]++] = array[i];
                }

                // a[]=t[] and start again until the last group 
                t.CopyTo(array, 0);
            }
        }
    }
}
