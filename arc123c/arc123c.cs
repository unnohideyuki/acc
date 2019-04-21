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
	int n = int.Parse(ReadLine());
	var vs = ReadIntArray();

	var h0 = new Dictionary<int, int>();
	var h1 = new Dictionary<int, int>();

	for(int i = 0; i < n; i += 2)
	{
	    int v0 = vs[i];
	    if (!h0.ContainsKey(v0)){ h0[v0] = 0; }
	    h0[v0] += 1;

	    int v1 = vs[i + 1];
	    if (!h1.ContainsKey(v1)){ h1[v1] = 0; }
	    h1[v1] += 1;
	}

	int mfv0 = 0, mfv1 = 0; // most frequent values
	int maxf0 = 0, secondf0 = 0, maxf1 = 0, secondf1 = 0;
	
	foreach (int v0 in h0.Keys)
	{
	    int f = h0[v0];
	    if      (f > maxf0)   { mfv0 = v0; maxf0 = f; }
	    else if (f > secondf0){ secondf0 = f; }
	}

	foreach (int v1 in h1.Keys)
	{
	    int f = h1[v1];
	    if      (f > maxf1)   { mfv1 = v1; maxf1 = f; }
	    else if (f > secondf1){ secondf1 = f; }
	}

	int ans;
	
	if (mfv0 != mfv1)
	{
	    ans = n - maxf0 - maxf1;
	}
	else
	{
	    int ans0 = n - maxf0 - secondf1;
	    int ans1 = n - maxf1 - secondf0;
	    ans = Math.Min(ans0, ans1);
	}
    
	WriteLine(ans);
    }
}
