using System;
using System.Collections;
using System.Diagnostics;

class Arrays
{
    static void Main()
    {
		Stopwatch stopwatch = new Stopwatch();

        int[] array = new int[] { -10, 2, 7, 13, 81, 99, 25, 12, 42 };

        // Шейкерная сортировка
		Console.WriteLine("Изначальный массив ");
        foreach (int i in array)
        {
            Console.WriteLine($"{i}");
        }
		
        CocktailSort(array);
        Console.WriteLine("\n");
		Console.WriteLine("Шейкерная сортировка ");
        foreach (int i in array)
        {
			Console.WriteLine($"{i}");
        }
		stopwatch.Stop();
		Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);


		array = new int[] { -10, 2, 7, 13, 81, 99, 25, 12, 42 };

		// Сортировка расческой
		stopwatch.Start();
		CombSort(array);
		Console.WriteLine("\n");
		Console.WriteLine("Сортировка расческой ");
		foreach (int i in array)
        {
            Console.WriteLine($"{i}");
        }
		stopwatch.Stop();
		Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);


		/* MyLinkedList<int> list = new MyLinkedList<int>();
        for (int i = 0; i < 10; i++)
            list.Add(i);
        
        foreach (int r in list)
        {
            Console.Write(r + "\t");
        }

        list.RemoveLast();
        Console.Write("\n");

        foreach (int r in list)
        {
            Console.Write(r + "\t");
        }

        list.AddLast(15);
        Console.Write("\n");
        
        foreach (int r in list)
        {
            Console.Write(r + "\t");
        } */

		/* MyList<int> list = new MyList<int>();
        for (int i = 0; i < 10; i++)
            list.Add(i);

        foreach (int r in list)
        {
            Console.Write(r);
        } */

		/* int[] array = new int[] { 1, 5, 10, 8, -2, -4 };
        int k = 6;
        First_Method(array, k);
        Second_Method(array, k); */
	}

    // 5 дз
	// Шейкерная сортировка
    static void Swap(int[] array, int i, int j)
    {
        int temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }

    static void CocktailSort(int[] inArray)
    {
        int left = 0,
            right = inArray.Length - 1;
        while (left < right)
        {
            for (int i = left; i < right; i++)
            {
                if (inArray[i] > inArray[i + 1])
                    Swap(inArray, i, i + 1);
            }
            right--;
            for (int i = right; i > left; i--)
            {
                if (inArray[i - 1] > inArray[i])
                    Swap(inArray, i - 1, i);
            }
            left++;
        }
    }

	// Сортировка расческой
    static int[] CombSort(int[] input)
    {
        double gap = input.Length;
        bool swaps = true;
        while (gap > 1 || swaps)
        {
            gap /= 1.247330950103979;
            if (gap < 1)
            {
                gap = 1;
            }
            int i = 0;
            swaps = false;
            while (i + gap < input.Length)
            {
                int igap = i + (int)gap;
                if (input[i] > input[igap])
                {
                    int swap = input[i];
                    input[i] = input[igap];
                    input[igap] = swap;
                    swaps = true;
                }
                i++;
            }
        }
        return input;
    }

    // 2 дз
    static void First_Method(int[] array, int k)
    {
        Console.Write("First_Method: ");
        Console.WriteLine("\n");

        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i + 1; j < array.Length; j++)
            {
                if (array[i] + array[j] == k)
                {
                    Console.WriteLine($"[{array[i]}, {array[j]}]");
                }
            }
        }
        Console.WriteLine("\n");
    }

    static void Second_Method(int[] array, int k)
    {
        Array.Sort(array);
        int first = 0;
        int last = array.Length - 1;

        Console.Write("Second_Method: ");
        Console.WriteLine("\n");

        while (first < last)
        {
            if (array[first] + array[last] == k)
            {
                Console.WriteLine($"[{array[first]}, {array[last]}]");
            }
            if (array[first] + array[last] < k)
            {
                first++;
            }
            else
            {
                last--;
            }
        }
        Console.Write("\n");
    }

    static void Third_Method(int[] array, int k)
    {
        Console.Write("Third_Method: ");
        Console.WriteLine("\n");

        Hashtable hash = new Hashtable();
        for (int i = 0; i < array.Length; i++)
        {
            if (hash.ContainsKey(k - array[i]))
            {
                Console.WriteLine($"[{k - array[i]}, {array[i]}]");
            }
            hash.Add(array[i], i);
        }
    }
}
