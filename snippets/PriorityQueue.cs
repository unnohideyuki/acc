using System;
using System.Collections.Generic;

// https://github.com/yambe2002/topcoder_template/blob/master/MyLibrary.cs
public class PriorityQueue<T> where T: IComparable
{
    private int _type = 0;
    private T[] _heap;
    private int _sz = 0;
    private int _count = 0;

    /// <summary>
    /// Priority queue
    /// </summary>
    /// <param name="type">0: asc, 1:desc</param>
    public PriorityQueue(int type = 0)
    {
	_heap = new T[128];
	_type = type;
    }

    private int Compare(T x, T y)
    {
	return _type == 0 ? x.CompareTo(y) : y.CompareTo(x);
    }

    public void Push(T x)
    {
	_count++;
	if (_count > _heap.Length)
	{
	    var newheap = new T[_heap.Length * 2];
	    for (int n = 0; n < _heap.Length; n++) newheap[n] = _heap[n];
	    _heap = newheap;
	}

	//node number
	var i = _sz++;

	while (i > 0)
	{
	    //parent node number
	    var p = (i - 1) / 2;
	    
	    if (Compare(_heap[p], x) <= 0) break;

	    _heap[i] = _heap[p];
	    i = p;
	}

	_heap[i] = x;
    }

    public T Pop()
    {
	_count--;

	T ret = _heap[0];
	T x = _heap[--_sz];

	int i = 0;
	while (i * 2 + 1 < _sz)
	{
	    //children
	    int a = i * 2 + 1;
	    int b = i * 2 + 2;

	    if (b < _sz && Compare(_heap[b], _heap[a]) < 0) a = b;

	    if (Compare(_heap[a], x) >= 0) break;
	    
	    _heap[i] = _heap[a];
	    i = a;
	}

	_heap[i] = x;

	return ret;
    }

    public int Count(){ return _count; }
    public T Peek(){ return _heap[0]; }
}
