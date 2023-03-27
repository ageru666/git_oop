using Lab1.Sorting;
using System.Collections;
using System.Runtime.CompilerServices;

static class SortManager///class manager for using of sorting collections
{
    public static void SortMenuSwitcher()///entry point for sorting collections
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
                     Array();
                    break;
                case "2":
                    Console.Clear();
                    List();
                    break;
                case "3":
                    Console.Clear();
                    LinkedList();
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

    static void Array()///method wrapper for creating and sorting array
    {
        IEnumerable arr;
        ChooseAndFillArray(out arr);

        Console.Clear();

        SortedCollectionOutput(arr);
    }
    static void List()///method wrapper for creating and sorting list
    {
        IEnumerable list;
        ChooseAndFillList(out list);

        Console.Clear();

        SortedCollectionOutput(list);
    }
    static void LinkedList()///method wrapper for creating and sorting linked list
    {
        IEnumerable list;
        ChooseAndFillLinkdList(out list);

        Console.Clear();

        SortedCollectionOutput(list);
    }

    static IIndexInterface<T> FillCollection<T>(IIndexInterface<T> array, ref Type type, ref int size, ref string[] cuttedValues)///fill given generic collection method
    {
        switch (type.Name)
        {
            case "Int32":
                for (int i = 0; i < size; i++)
                {
                    if (!int.TryParse(cuttedValues[i], out int newInt))
                        continue;
                    array[i] = Unsafe.As<int, T>(ref newInt);
                }
                break;
            case "Double":
                for (int i = 0; i < size; i++)
                {
                    if (!double.TryParse(cuttedValues[i], out double newDouble))
                        continue;
                    array[i] = Unsafe.As<double, T>(ref newDouble);
                }
                break;
            case "Single":
                for (int i = 0; i < size; i++)
                {
                    if (!float.TryParse(cuttedValues[i], out float newFloat))
                        continue;
                    array[i] = Unsafe.As<float, T>(ref newFloat);
                }
                break;
            case "Int16":
                for (int i = 0; i < size; i++)
                {
                    if (!short.TryParse(cuttedValues[i], out short newShort))
                        continue;
                    array[i] = Unsafe.As<short, T>(ref newShort);
                }
                break;
            case "UInt16":
                for (int i = 0; i < size; i++)
                {
                    if (!ushort.TryParse(cuttedValues[i], out ushort newUshort))
                        continue;
                    array[i] = Unsafe.As<ushort, T>(ref newUshort);
                }
                break;
            case "UInt32":
                for (int i = 0; i < size; i++)
                {
                    if (!uint.TryParse(cuttedValues[i], out uint newUint))
                        continue;
                    array[i] = Unsafe.As<uint, T>(ref newUint);
                }
                break;
        }
        return array;
    }

    static void ChooseAndFillArray(out IEnumerable collection)///method wrapper for choosing type and fill array
    {
        Type type;
        ChooseTypeOutput();
        string[] cuttedValues = default;
        int size = default;

        switch (Console.ReadLine())
        {
            case "1":
                type = typeof(int);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewArray<int>)FillCollection(new NewArray<int>(size), ref type, ref size, ref cuttedValues);
                break;
            case "2":
                type = typeof(double);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewArray<double>)FillCollection(new NewArray<double>(size), ref type, ref size, ref cuttedValues);
                break;
            case "3":
                type = typeof(float);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewArray<float>)FillCollection(new NewArray<float>(size), ref type, ref size, ref cuttedValues);
                break;
            case "4":
                type = typeof(short);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewArray<short>)FillCollection(new NewArray<short>(size), ref type, ref size, ref cuttedValues);
                break;
            case "5":
                type = typeof(ushort);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewArray<ushort>)FillCollection(new NewArray<ushort>(size), ref type, ref size, ref cuttedValues);
                break;
            case "6":
                type = typeof(uint);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewArray<uint>)FillCollection(new NewArray<uint>(size), ref type, ref size, ref cuttedValues);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                collection = null;
                type = null;
                break;
        }
        Console.Clear();
        Console.WriteLine($"Created custom array of type [{type.Name}] with size of [{size}]");
    }
    static void ChooseAndFillList(out IEnumerable list)///method wrapper for choosing type and fill list
    {
        Type type;
        ChooseTypeOutput();
        string[] cuttedValues = default;
        int size = 0;

        switch (Console.ReadLine())
        {
            case "1":
                type = typeof(int);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                list = (NewList<int>)FillCollection(new NewList<int>(size), ref type, ref size, ref cuttedValues);
                break;
            case "2":
                type = typeof(double);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                list = (NewList<double>)FillCollection(new NewList<double>(size), ref type, ref size, ref cuttedValues);
                break;
            case "3":
                type = typeof(float);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                list = (NewList<float>)FillCollection(new NewList<float>(size), ref type, ref size, ref cuttedValues);
                break;
            case "4":
                type = typeof(short);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                list = (NewList<short>)FillCollection(new NewList<short>(size), ref type, ref size, ref cuttedValues);
                break;
            case "5":
                type = typeof(ushort);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                list = (NewList<ushort>)FillCollection(new NewList<ushort>(size), ref type, ref size, ref cuttedValues);
                break;
            case "6":
                type = typeof(uint);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                list = (NewList<uint>)FillCollection(new NewList<uint>(size), ref type, ref size, ref cuttedValues);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                list = null;
                type = null;
                break;
        }
        Console.Clear();
        Console.WriteLine($"Created custom array of type [{type.Name}] with size of [{size}]");
    }
    static void ChooseAndFillLinkdList(out IEnumerable collection)///method wrapper for choosing type and fill linked list
    {
        Type type;
        ChooseTypeOutput();
        string[] cuttedValues = default;
        int size = 0;

        switch (Console.ReadLine())
        {
            case "1":
                type = typeof(int);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewList<int>)FillCollection(new NewList<int>(size), ref type, ref size, ref cuttedValues);
                break;
            case "2":
                type = typeof(double);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewList<double>)FillCollection(new NewList<double>(size), ref type, ref size, ref cuttedValues);
                break;
            case "3":
                type = typeof(float);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewList<float>)FillCollection(new NewList<float>(size), ref type, ref size, ref cuttedValues);
                break;
            case "4":
                type = typeof(short);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewList<short>)FillCollection(new NewList<short>(size), ref type, ref size, ref cuttedValues);
                break;
            case "5":
                type = typeof(ushort);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewList<ushort>)FillCollection(new NewList<ushort>(size), ref type, ref size, ref cuttedValues);
                break;
            case "6":
                type = typeof(uint);
                cuttedValues = ParseInput(type);
                size = cuttedValues.Length;
                collection = (NewList<uint>)FillCollection(new NewList<uint>(size), ref type, ref size, ref cuttedValues);
                break;
            default:
                Console.WriteLine("Incorrect input.");
                collection = null;
                type = null;
                break;
        }
        Console.Clear();
        Console.WriteLine($"Created custom array of type [{type.Name}] with size of [{size}]");
    }

    static void ChooseTypeOutput()///choose type
    {
        Console.WriteLine("Choose type");
        Console.WriteLine("1.int");
        Console.WriteLine("2.double");
        Console.WriteLine("3.float");
        Console.WriteLine("4.short");
        Console.WriteLine("5.ushort");
        Console.WriteLine("6.uint");
    }

    static void SortedCollectionOutput(IEnumerable collection)///choose type of sorting
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
    static string[]? ParseInput(Type type)///parse input to the collection 
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