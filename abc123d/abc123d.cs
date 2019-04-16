using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static MyUtil;

class MyUtil
{
    public static void Swap<T>(ref T a, ref T b)
    {
	var t = a;
	a = b;
	b = t;
    }

    public static int[] ReadIntArray()
    {
	return ReadLine().Split().Select(x => int.Parse(x)).ToArray();
    }

    public static long[] ReadLongArray()
    {
	return ReadLine().Split().Select(x => long.Parse(x)).ToArray();
    }
}

class PriorityQueue<T> where T : IComparable
{
    public IComparer<T> comp = null;

    private T[] heap;
    private int sz = 0;
    private int ct = 0;

    public PriorityQueue(int max_size)
    {
	heap = new T[max_size];
    }

    private int Compare(T x, T y)
    {
	if (comp == null)
	{
	    return x.CompareTo(y);
	}
	else
	{
	    return comp.Compare(x, y);
	}
    }

    public void Push(T x)
    {
	ct++;
	var i = sz++;
	while (i > 0)
	{
	    var p = (i - 1) / 2;
	    if (Compare(heap[p], x) >= 0){ break; }
	    heap[i] = heap[p];
	    i = p;
	}
	heap[i] = x;
    }

    public T Top()
    {
	return heap[0];
    }

    public void Pop()
    {
	ct--;
	T x = heap[--sz];
	int i = 0;
	while (i*2 + 1 < sz)
	{
	    int a = i*2 + 1;
	    int b = i*2 + 2;
	    if (b < sz && Compare(heap[b], heap[a]) > 0){ a = b; }
	    if (Compare(heap[a], x) < 0){ break; }
	    heap[i] = heap[a];
	    i = a;
	}
	heap[i] = x;
    }
}

class Program
{
    public static void Main()
    {
	int x, y, z, n;
	var t = ReadIntArray();
	x = t[0]; y = t[1]; z = t[2]; n = t[3];

	long[] a = ReadLongArray();
	long[] b = ReadLongArray();
	long[] c = ReadLongArray();
	Array.Sort(a); Array.Reverse(a);
	Array.Sort(b); Array.Reverse(b);
	Array.Sort(c); Array.Reverse(c);

	var s = new HashSet<Tuple<int, int, int>>();
	var q = new PriorityQueue<Tuple<long, Tuple<int, int, int>>>(10000);

	q.Push(new Tuple<long, Tuple<int, int, int>>(a[0]+b[0]+c[0], new Tuple<int, int, int>(0,0,0)));
	s.Add(new Tuple<int, int, int>(0, 0, 0));

	for (int ct = 0; ct < n; ct++)
	{
	    long score = q.Top().Item1;
	    var tt = q.Top().Item2;
	    q.Pop();

	    WriteLine(score);

	    int i = tt.Item1;
	    int j = tt.Item2;
	    int k = tt.Item3;

	    if ((i < x-1) && ! s.Contains(new Tuple<int, int, int>(i+1, j, k)))
	    {
		q.Push(new Tuple<long, Tuple<int, int, int>>
		       (a[i+1]+b[j]+c[k], new Tuple<int, int, int>(i+1,j,k)));
		s.Add(new Tuple<int, int, int>(i+1,j,k));
	    }

	    if ((j < y-1) && ! s.Contains(new Tuple<int, int, int>(i, j+1, k)))
	    {
		q.Push(new Tuple<long, Tuple<int, int, int>>
		       (a[i]+b[j+1]+c[k], new Tuple<int, int, int>(i,j+1,k)));
		s.Add(new Tuple<int, int, int>(i,j+1,k));
	    }
	    if ((k < z-1) && ! s.Contains(new Tuple<int, int, int>(i, j, k+1)))
	    {
		q.Push(new Tuple<long, Tuple<int, int, int>>
		       (a[i]+b[j]+c[k+1], new Tuple<int, int, int>(i,j,k+1)));
		s.Add(new Tuple<int, int, int>(i,j,k+1));
	    }
	}
    }
}
