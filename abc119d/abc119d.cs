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

class Program
{
    public static void Main()
    {
	long MAX = 1000000000000;
	int a, b, q;

	var tt = ReadIntArray();
	a = tt[0];
	b = tt[1];
	q = tt[2];

	var s = new long[a+2];
	var t = new long[b+2];
	var x = new long[q];

	s[0] = -MAX; s[a+1] = MAX;
	for (int i = 1; i <= a; i++)
	{
	    s[i] = long.Parse(ReadLine());
	}
	
	t[0] = -MAX; t[b+1] = MAX;
	for (int i = 1; i <= b; i++)
	{
	    t[i] = long.Parse(ReadLine());
	}

	for (int i = 0; i < q; i++)
	{
	    x[i] = long.Parse(ReadLine());
	}

	for (int i = 0; i < q; i++)
	{
	    long ans = Solve(s, t, x[i]);
	    WriteLine(ans);
	}
    }

    static long Solve(long[] s, long[] t, long x)
    {
	long ans = 1000000000000;

	long sl, sr, tl, tr;

	int i = Bisect.BisectRight(s, x); sl = s[i-1]; sr = s[i];
	int j = Bisect.BisectRight(t, x); tl = t[j-1]; tr = t[j];
	
	ans = Math.Max(sr, tr) - x;

	long d = x - Math.Min(sl, tl);
	ans = Math.Min(ans, d);

	long d_sr = sr - x;
	long d_tl = x - tl;
	long d1 = 2 * Math.Min(d_sr, d_tl) + Math.Max(d_sr, d_tl);
	ans = Math.Min(ans, d1);

	long d_sl = x - sl;
	long d_tr = tr - x;
	long d2 = 2 * Math.Min(d_tr, d_sl) + Math.Max(d_tr, d_sl);
	ans = Math.Min(ans, d2);

	return ans;
    }
}
