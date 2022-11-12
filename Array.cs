using System;
class Arrays
{
	static void Main()
	{
		int[] array = new int[] { 1, 5, 10, 8, -2, -4 };
		int k = 6;
		First_Method(array, k);
		Second_Method(array, k);
	}

	static void First_Method(int[] array, int k)
	{
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

	}
}