using System;
using System.Collections;

public class Node<T>
{
    public T data;
    public Node<T> next;
}

public class MyLinkedList<T> : IEnumerable<T>
{
    private Node<T> _headNode;
    private int _count;
    public int Count
    {
        get
        {
            {
                return _count;
            }
        }
    }

    private IEnumerable<Node<T>> Nodes
    {
        get
        {
            Node<T> node = _headNode;
            while (node != null)
            {
                yield return node;
                node = node.next;
            }
        }
    }

    private Node<T> Pop()
    {
        Node<T> tResult = null;
        if (_headNode != null)
        {
            tResult = _headNode;
            _headNode = _headNode.next;
            _count--;
        }
        return tResult;
    }

    private void Push(Node<T> item)
    {
        item.next = _headNode;
        _headNode = item;
        _count++;
    }

    private Node<T> NodeAt(int index)
    {
        if (index < 0 || index + 1 > _count)
        {
            throw new IndexOutOfRangeException("Index");
        }
        int counter = 0;
        foreach (Node<T> item in Nodes)
        {
            if (counter == index)
            {
                return item;
            }
            counter++;
        }
        return null;
    }

    public MyLinkedList()
    {
        _headNode = null;
        _count = 0;
    }

    public MyLinkedList(IEnumerable<T> Items)
    {
        foreach (T item in Items)
        {
            Add(item);
        }
    }

    public void ForEach(Action<T> action)
    {
        foreach (Node<T> item in Nodes)
        {
            action(item.data);
        }
    }

    public T this[int index]
    {
        get { return NodeAt(index).data; }
        set { NodeAt(index).data = value; }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public IEnumerator<T> GetEnumerator()
    {
        foreach (Node<T> item in Nodes)
        {
            yield return item.data;
        }
    }

    public void Clear()
    {
        _headNode = null;
        _count = 0;
    }

    public void Add(T item)
    {
        Node<T> NewNode = new Node<T>() { data = item, next = _headNode };
        _headNode = NewNode;
        _count++;
    }

    public IEnumerable<int> AllIndexesOf(T Value)
    {
        int IndexCount = 0;
        foreach (Node<T> item in Nodes)
        {
            if (Comparer<T>.Default.Compare(item.data, Value) == 0)
            {
                yield return IndexCount;
            }
            IndexCount++;
        }
    }

    public void RemoveAll(Func<T, bool> match)
    {
        while (_headNode != null && match(_headNode.data))
        {
            _headNode = _headNode.next;
            _count--;
        }
        if (_headNode != null)
        {
            Node<T> nTemp = _headNode;
            while (nTemp.next != null)
            {
                if (match(nTemp.next.data))
                {
                    nTemp.next = nTemp.next.next;
                    _count--;
                }
                else
                {
                    nTemp = nTemp.next;
                }
            }
        }
    }

    public void RemoveFirst()
    {
        if (_headNode != null)
        {
            _headNode = _headNode.next;
            _count--;
        }
    }

    public void RemoveLast()
    {
        if (_headNode != null)
        {
            if (_headNode.next == null)
            {
                _headNode = null;
            }
            else
            {
                NodeAt(Count - 2).next = null;
            }
            _count--;
        }
    }

    public void AddLast(T item)
    {
        Node<T> NewNode = new Node<T>() { data = item, next = null };
        if (_headNode == null)
        {
            _headNode = NewNode;
        }
        else
        {
            NodeAt(Count - 1).next = NewNode;
        }
        _count++;
    }
}
