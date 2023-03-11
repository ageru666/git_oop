using Lab1.Sorting;
using System.Collections;

static class SortManager
{
    public static void SortMenuSwitcher()
    {
        try
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Choose what do you want to sort:");
            Console.WriteLine("1.Array<T>");
            Console.WriteLine("2.List<T>");
            Console.WriteLine("3.LinkedList<T>");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    ArraysSorting();
                    break;
                case "2":
                    Console.Clear();
                    ListsSorting();
                    break;
                case "3":
                    Console.Clear();
                    LinkedListsSorting();
                    break;
                default:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Wrong menu number.\n");
                    break;
            }
            SortMenuSwitcher();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception: " + ex);
        }
    }

    static void ArraysSorting()
    {
        Console.WriteLine("Enter size of the array:");
        if (!int.TryParse(Console.ReadLine(), out int size))
        {
            Console.WriteLine("Incorrect input.");
            return;
        }

        IEnumerable arr;
        Type type;
        ChooseTypeForArray(out type, out arr, ref size);


        Console.Clear();
        Console.WriteLine($"Created custom array of type [{type.Name}] with size of [{size}]");


        Console.WriteLine($"Enter numbers");
        if (!FillArray(arr, type, ref size))
            return;

        Console.Clear();
        Console.WriteLine("Entered numbers are:");
        foreach (var item in arr)
            Console.Write(" " + item);

        SortedCollectionOutput(arr);
    }
    static void ListsSorting()
    {
        IEnumerable list;
        Type type;
        ChooseTypeForList(out type, out list);

        Console.Clear();
        Console.WriteLine($"Created custom list of type [{type.Name}]");


        Console.WriteLine($"Enter numbers.");
        if (!FillList(list, type))
            return;

        SortedCollectionOutput(list);
    }
    static void LinkedListsSorting()
    {
        IEnumerable list;
        Type type;
        ChooseTypeForLinkedList(out type, out list);


        Console.Clear();
        Console.WriteLine($"Created custom LinkedList of type [{type.Name}]");


        Console.WriteLine($"Enter numbers.");
        if (!FillLinkedList(list, type))
            return;

        SortedCollectionOutput(list);
    }

    static bool FillArray(dynamic collection, Type type, ref int size)
    {
        string[] cuttedValues = ParseInput(type);

        switch (type.Name)
        {
            case "Int32":
                for (int i = 0; i < size; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be integer");
                        continue;
                    }
                    collection[i] = newInt;
                }
                break;
            case "Double":
                for (int i = 0; i < size; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be double");
                        continue;
                    }
                    collection[i] = newDouble;
                }
                break;
            case "Single":
                for (int i = 0; i < size; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be float");
                        continue;
                    }
                    collection[i] = newFloat;
                }
                break;
            case "Int16":
                for (int i = 0; i < size; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be short");
                        continue;
                    }
                    collection[i] = newShort;
                }
                break;
            case "UInt16":
                for (int i = 0; i < size; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be ushort");
                        continue;
                    }
                    collection[i] = newUshort;
                }
                break;
            case "UInt32":
                for (int i = 0; i < size; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be uint");
                        continue;
                    }
                    collection[i] = newUint;
                }
                break;
            default:
                break;
        }
        return true;
    }
    static bool FillList(dynamic collection, Type type)
    {
        string[] cuttedValues = ParseInput(type);

        switch (type.Name)
        {
            case "Int32":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be integer");
                        continue;
                    }
                    collection.Add(newInt);
                }
                break;
            case "Double":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be double");
                        continue;
                    }
                    collection.Add(newDouble);
                }
                break;
            case "Single":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be float");
                        continue;
                    }
                    collection.Add(newFloat);
                }
                break;
            case "Int16":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be short");
                        continue;
                    }
                    collection.Add(newShort);
                }
                break;
            case "UInt16":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be ushort");
                        continue;
                    }
                    collection.Add(newUshort);
                }
                break;
            case "UInt32":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be uint");
                        continue;
                    }
                    collection.Add(newUint);
                }
                break;
            default:
                break;
        }
        return true;
    }
    static bool FillLinkedList(dynamic collection, Type type)
    {
        string[] cuttedValues = ParseInput(type);


        switch (type.Name)
        {
            case "Int32":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be integer");
                        continue;
                    }
                    collection.AddLast(newInt);
                }
                break;
            case "Double":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be double");
                        continue;
                    }
                    collection.AddLast(newDouble);
                }
                break;
            case "Single":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be float");
                        continue;
                    }
                    collection.AddLast(newFloat);
                }
                break;
            case "Int16":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be short");
                        continue;
                    }
                    collection.AddLast(newShort);
                }
                break;
            case "UInt16":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be ushort");
                        continue;
                    }
                    collection.AddLast(newUshort);
                }
                break;
            case "UInt32":
                for (int i = 0; i < cuttedValues.Length; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                    {
                        Console.WriteLine(cuttedValues[i] + " - cannot be uint");
                        continue;
                    }
                    collection.AddLast(newUint);
                }
                break;
            default:
                break;
        }
        return true;
    }

    static void ChooseTypeForArray(out Type type, out IEnumerable collection, ref int size)
    {
        Console.WriteLine("Choose type for Array");
        Console.WriteLine("1.int");
        Console.WriteLine("2.double");
        Console.WriteLine("3.float");
        Console.WriteLine("4.short");
        Console.WriteLine("5.ushort");
        Console.WriteLine("6.uint");
        switch (Console.ReadLine())
        {
            case "1":
                collection = new NewArray<int>(size);
                type = typeof(int);
                break;
            case "2":
                collection = new NewArray<double>(size);
                type = typeof(double);
                break;
            case "3":
                collection = new NewArray<float>(size);
                type = typeof(float);
                break;
            case "4":
                collection = new NewArray<short>(size);
                type = typeof(short);
                break;
            case "5":
                collection = new NewArray<ushort>(size);
                type = typeof(ushort);
                break;
            case "6":
                collection = new NewArray<uint>(size);
                type = typeof(uint);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                type = null;
                collection = null;
                break;
        }
    }
    static void ChooseTypeForList(out Type type, out IEnumerable list)
    {
        Console.WriteLine("Choose type for List");
        Console.WriteLine("1.int");
        Console.WriteLine("2.double");
        Console.WriteLine("3.float");
        Console.WriteLine("4.short");
        Console.WriteLine("5.ushort");
        Console.WriteLine("6.uint");
        switch (Console.ReadLine())
        {
            case "1":
                list = new NewList<int>();
                type = typeof(int);
                break;
            case "2":
                list = new NewList<double>();
                type = typeof(double);
                break;
            case "3":
                list = new NewList<float>();
                type = typeof(float);
                break;
            case "4":
                list = new NewList<short>();
                type = typeof(short);
                break;
            case "5":
                list = new NewList<ushort>();
                type = typeof(ushort);
                break;
            case "6":
                list = new NewList<uint>();
                type = typeof(uint);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                type = null;
                list = null;
                break;
        }
    }
    static void ChooseTypeForLinkedList(out Type type, out IEnumerable collection)
    {
        Console.WriteLine("Choose type for LinkedList");
        Console.WriteLine("1.int");
        Console.WriteLine("2.double");
        Console.WriteLine("3.float");
        Console.WriteLine("4.short");
        Console.WriteLine("5.ushort");
        Console.WriteLine("6.uint");
        switch (Console.ReadLine())
        {
            case "1":
                collection = new NewLinkedList<int>();
                type = typeof(int);
                break;
            case "2":
                collection = new NewLinkedList<double>();
                type = typeof(double);
                break;
            case "3":
                collection = new NewLinkedList<float>();
                type = typeof(float);
                break;
            case "4":
                collection = new NewLinkedList<short>();
                type = typeof(short);
                break;
            case "5":
                collection = new NewLinkedList<ushort>();
                type = typeof(ushort);
                break;
            case "6":
                collection = new NewLinkedList<uint>();
                type = typeof(uint);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                type = null;
                collection = null;
                break;
        }
    }

    static void SortedCollectionOutput(IEnumerable collection)
    {
        Console.WriteLine("Collection filled up!");
        Console.WriteLine("We are almost done!\n");
        Console.WriteLine("Now choose the sorting method:");
        Console.WriteLine("1.Insertion sort");
        Console.WriteLine("2.Quick sort");
        Console.WriteLine("3.Merge sort");
        Console.WriteLine("4.Comb sort");
        Console.WriteLine("5.Counting sort");
        Console.WriteLine("6.Radix sort");
        Console.WriteLine("7.Bucket sort");

        string input = Console.ReadLine();
        if ("MyLinkedList`1" == collection.GetType().Name)
            input = "3";

        switch (input)
        {
            case "1":
                collection.InsertionSortGeneric();
                Console.WriteLine("Sorted collection is:");
                foreach (var num in collection)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "2":
                collection.QuickSortGeneric();
                Console.WriteLine("Sorted collection is:");
                foreach (var num in collection)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "3":
                collection.MergeSortGeneric();
                Console.WriteLine("Sorted collection is:");
                foreach (var num in collection)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "4":
                collection.CombSortGeneric();
                Console.WriteLine("Sorted collection is:");
                foreach (var num in collection)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "5":
                collection.CountingSortGeneric();
                Console.WriteLine("Sorted collection is:");
                foreach (var num in collection)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "6":
                collection.RadixSortGeneric();
                Console.WriteLine("Sorted collection is:");
                foreach (var num in collection)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            case "7":
                collection.BucketSortGeneric();
                Console.WriteLine("Sorted collection is:");
                foreach (var num in collection)
                    Console.Write(" " + num);
                Console.WriteLine();
                break;
            default:
                Console.WriteLine("Incorrect input.");
                return;
        }
    }
    static string[]? ParseInput(Type type)
    {
        bool isWhiteSpaceSeparator = false;
        if (type.Name == "Double" || type.Name == "Single")
            isWhiteSpaceSeparator = true;

        string format = isWhiteSpaceSeparator ? "WHITESPACE separator, example [23,4 -23,431 0,13f]" : "',' or whitespace or ';' separators";
        Console.WriteLine($"Input values of which linkedlist contains using {format}:");
        string inputValues = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inputValues))
        {
            Console.WriteLine("Try next time to input some values...");
            return null;
        }

        if (string.IsNullOrWhiteSpace(inputValues) || inputValues.Length == 0)
            return null;


        string[] cuttedValues;
        if (isWhiteSpaceSeparator)
            cuttedValues = inputValues.Split(" ", StringSplitOptions.TrimEntries);
        else
            cuttedValues = inputValues.Split(new string[] { " ", ",", ";" }, StringSplitOptions.TrimEntries);

        return cuttedValues;
    }
}