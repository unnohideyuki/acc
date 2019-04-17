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
	int a, b, q;

	var tt = ReadIntArray();
	a = tt[0];
	b = tt[1];
	q = tt[2];

	var s = new long[a];
	var t = new long[b];
	var x = new long[q];
	
	for (int i = 0; i < a; i++){ s[i] = long.Parse(ReadLine()); }
	for (int i = 0; i < b; i++){ t[i] = long.Parse(ReadLine()); }
	for (int i = 0; i < q; i++){ x[i] = long.Parse(ReadLine()); }

	for (int i = 0; i < q; i++)
	{
	    long ans = Solve(s, t, x[i]);
	    WriteLine(ans);
	}
    }

    static long Solve(long[] s, long[] t, long x)
    {
	long ans = 1000000000000;

	long sl = -1, sr = -1;
	long tl = -1, tr = -1;

	for (int i = 0; i < s.Length; i++){
	    if (x > s[i]){ sl = s[i]; }

	    if (x <= s[i])
	    {
		sr = s[i];
		break;
	    }
	}
	
	for (int i = 0; i < t.Length; i++){
	    if (x > t[i]){ tl = t[i]; }

	    if (x <= t[i])
	    {
		tr = t[i];
		break;
	    }
	}

	//           X ------->
	if ((sr >= 0) && (tr >= 0)){
	    ans = Math.Max(sr, tr) - x;
	}

	// <-------- X
	if ((sl >= 0) && (tl >= 0)){
	    long d = x - Math.Min(sl, tl);
	    ans = Math.Min(ans, d);
	}

	if ((sr >= 0) && (tl >= 0)){
	    long d_sr = sr - x;
	    long d_tl = x - tl;
	    long d1 = 2 * Math.Min(d_sr, d_tl) + Math.Max(d_sr, d_tl);
	    ans = Math.Min(ans, d1);
	}

	if ((tr >= 0) && (sl >= 0)){
	    long d_sl = x - sl;
	    long d_tr = tr - x;
	    long d2 = 2 * Math.Min(d_tr, d_sl) + Math.Max(d_tr, d_sl);
	    ans = Math.Min(ans, d2);
	}
	return ans;
    }
			    
}
