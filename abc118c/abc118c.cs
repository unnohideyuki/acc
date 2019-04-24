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
    static int Gcd(int a, int b)
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
    
    public static void Main()
    {
	int n = int.Parse(ReadLine());
	var a = ReadIntArray();

	int x = a[0];
	for (int i = 1; i < n; i++)
	{
	    x = Gcd(x, a[i]);
	}
	
	WriteLine(x);
    }
}
