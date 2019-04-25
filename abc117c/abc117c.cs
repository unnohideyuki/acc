using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using static MyUtil;

class MyUtil
{
    public static int[] ReadIntArray()
    {
	return ReadLine().Split().Select(x => int.Parse(x)).ToArray();
    }
}

class Program
{
    public static void Main()
    {
	var t = ReadIntArray();
	int n = t[0], m = t[1];

	var x = ReadIntArray();
	Array.Sort(x);

	var d = new int[m-1];
	for (int i = 0; i < m-1; i++)
	{
	    d[i] = x[i+1] - x[i];
	}

	Array.Sort(d);

	int ncut = Math.Min(m, n) - 1;
	int ans = x[m-1]-x[0];

	for (int i = 0; i < ncut; i++){
	    ans -= d[m-2-i];
	}

	WriteLine(ans);
    }
}
