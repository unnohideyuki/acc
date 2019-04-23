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

class Bisect
{
    /* BisectRight(a, x) returns the index where to insert x in a sorted list a.
     * 
     * The return value i is such that for all 0 < j < i, a[j] <= x and
     * for all j > i, a[j] > x.
     */
    public static int BisectRight<T>(T[] a, T x) where T : IComparable
    {
	int lo = 0, hi = a.Length;
	while (lo < hi)
	{
	    int mid = (lo + hi) / 2;
	    if (x.CompareTo(a[mid]) < 0) { hi = mid; }
	    else { lo = mid + 1; }
	}
	return lo;
    }
}

class Dummy
{
    public static void Main()
    {
	int[] a = {1, 2, 3, 3, 4, 4, 5};
	WriteLine(Bisect.BisectRight(a, 3));

	double[] b = {1.0, 2.0, 3.14, 4.28, 5.01};
	WriteLine(Bisect.BisectRight(b, 3.0));
    }
}
