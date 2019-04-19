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
	var t = ReadIntArray();
	int n = t[0], m= t[1], c = t[2];

	var b = ReadIntArray();

	int ans = 0;
	
	for (int i = 0; i < n; i++)
	{
	    var a = ReadIntArray();
	    int x = c;
	    for (int j = 0; j < m; j++)
	    {
		x += a[j] * b[j];
	    }

	    if (x > 0){ ans++; }
	}

	WriteLine(ans);
    }
}
