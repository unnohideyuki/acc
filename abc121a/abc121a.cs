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
	int H, W, h, w;
	var t = ReadIntArray();
	H = t[0];
	W = t[1];
	t = ReadIntArray();
	h = t[0];
	w = t[1];

	int ans = (H-h)*(W-w);
	WriteLine(ans);
    }
}
