using System;
using System.Collections;

public class MyList<T> : IEnumerable, IEnumerator
{
    int sizeArray = 0;
    public int SizeArray
    {
        get => sizeArray;
    }

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
        get
        {
            try
            {
                return date[position];
            }
            catch (IndexOutOfRangeException)
            {
                throw new InvalidOperationException();
            }
        }
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
