using System;
using System.Collections;

class MyList<T> : IEnumerable, IEnumerator
{
	int sizeArray = 0;
	public int SizeArray { get => sizeArray; }

	T[] date = new T[1];

	int position = -1;
	int pos = -1;

	public void Clear()
	{
		date = new T[1];
		sizeArray = 0;
		pos = -1;
	}

	public void Add(T mass)
	{
		sizeArray++;
		Array.Resize(ref this.date, sizeArray);
		pos++;
		this.date[pos] = mass;
	}
	public bool MoveNext()
	{
		position++;
		return (position < date.Length);
	}

	public void Reset()
	{
		position = -1;
	}
	public T Current
	{
		get { try { return date[position]; } catch (IndexOutOfRangeException) { throw new InvalidOperationException(); } }
	}


	object IEnumerator.Current
	{
		get { return Current; }
	}

	public IEnumerator GetEnumerator()
	{
		return date.GetEnumerator();
	}

	public T this[int index]
	{
		get { return date[index]; }
		set { date[index] = value; }
	}
}
class Arrays
{
	static void Main()
	{
		MyList<int> list = new MyList<int>();

		for (int i = 0; i < 10; i++)
			list.Add(i);

		foreach (int r in list)
		{
			Console.WriteLine(r);
		}
		/* int[] array = new int[] { 1, 5, 10, 8, -2, -4 };
		int k = 6;
		First_Method(array, k);
		Second_Method(array, k);
		Third_Method(array, k); */
	}

	/*	static void First_Method(int[] array, int k)
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
		}*/
}