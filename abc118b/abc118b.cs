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
	int n, m;
	var t = ReadIntArray();
	n = t[0]; m = t[1];

	var d = new int[m+1];
	for (int i = 0; i <= m; i++){ d[i] = 0; }

	for (int i = 0; i < n; i++)
	{
	    t = ReadIntArray();
	    int k = t[0];
	    for (int j = 1; j <= k; j++)
	    {
		int a = t[j];
		d[a]++;
	    }
	}

	int ans = 0;
	for (int i = 1; i <=m; i++)
	{
	    if (d[i] == n){ ans++; }
	}

	WriteLine(ans);
    }
}
