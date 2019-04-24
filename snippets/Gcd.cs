using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static MyUtil;

class MyUtil
{
    public static int Gcd(int a, int b)
    {
	if (a < b){ return Gcd(b, a); }
	while (b != 0)
	{
	    var r = a % b;
	    a = b;
	    b = r;
	}
	return a;
    }

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
	WriteLine(Gcd(49, 7));
    }
}
