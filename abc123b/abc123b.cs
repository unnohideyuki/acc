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
}

class Program
{
    public static void Main()
    {
	var a = new int[5];
	for (int i = 0; i < 5; i++)
	{
	    a[i] = int.Parse(ReadLine());
	}

	int rmax = 0;
	for (int i = 0; i < 5; i++){
	    int r = a[i] % 10;
	    if (r != 0){ r = 10 - r; }
	    if (r > rmax)
	    {
		Swap(ref a[0], ref a[i]);
		rmax = r;
	    }
	}

	int ans = a[0];
	for (int i = 1; i < 5; i++){
	    int r = a[i] % 10;
	    ans += a[i];
	    if (r != 0)
	    {
		ans += (10 - r);
	    }
	}

	WriteLine(ans);
    }
}
