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
	int a = int.Parse(ReadLine());
	ReadLine();
	ReadLine();
	ReadLine();
	int e = int.Parse(ReadLine());
	int k = int.Parse(ReadLine());

	if (e-a <= k)
	{
	    WriteLine("Yay!");
	}
	else
	{
	    WriteLine(":(");
	}
    }
}
