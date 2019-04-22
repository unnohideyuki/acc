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
	int a, b, k;
	var t = ReadIntArray();
	a = t[0]; b = t[1]; k = t[2];

	for (int i = Math.Min(a, b); i > 0; i--)
	{
	    if ((a%i) == 0 && (b%i) == 0){ k--; }
	    if (k == 0)
	    {
		WriteLine(i);
		return;
	    }
	}
    }
}
