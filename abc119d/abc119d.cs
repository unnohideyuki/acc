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

	for (int i = 1; i <= a; i++){ s[i] = long.Parse(ReadLine()); }
	s[0] = -MAX; s[a+1] = MAX;
	
	for (int i = 1; i <= b; i++){ t[i] = long.Parse(ReadLine()); }
	t[0] = -MAX; t[b+1] = MAX;

	for (int i = 0; i < q; i++){ x[i] = long.Parse(ReadLine()); }

	for (int i = 0; i < q; i++)
	{
	    long ans = Solve(s, t, x[i]);
	    WriteLine(ans);
	}
    }

    // return i that satisfies a[i] < x <= a[i+1]
    static int Search(long[] a, long x)
    {
	int l = 0, r = a.Length - 2;

	while(true)
	{
	    if (l > r){ return -1; } // Must not occur in this program.

	    int m = (l + r) / 2;

	    if (a[m]  >= x)
	    {
		r = m - 1;
	    }
	    else if (a[m+1] < x)
	    {
		l = m + 1;
	    }
	    else
	    {
		return m;
	    }
	}
    }
       
    static long Solve(long[] s, long[] t, long x)
    {
	long ans = 1000000000000;

	long sl, sr, tl, tr;

	int i = Search(s, x); sl = s[i]; sr = s[i+1];
	int j = Search(t, x); tl = t[j]; tr = t[j+1];
	
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
