using System;
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
	int n = int.Parse(ReadLine());
	var l = ReadIntArray();
	Array.Sort(l);
	if (l.Sum() > 2*l[n-1]){ WriteLine("Yes"); }
	else                 { WriteLine("No"); }
    }
}
