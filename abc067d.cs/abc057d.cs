using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Runtime.CompilerServices;
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
    static int v;
    static Dictionary<Tuple<int, int>, int> dic;

    static int d(int i, int j)
    {
	var key = Tuple.Create(i, j);
	if (dic.ContainsKey(key))
	{
	    return dic[key];
	}
	return v;
    }

    static void setD(int i, int j, int v)
    {
	var key = Tuple.Create(i, j);
	if (dic.ContainsKey(key))
	{
	    dic[key] = v;
	}
    }
    
    public static void WarshallFloyd()
    {
	for (int k = 0; k < v; k++)
	    for (int i = 0; i < v; i++)
		for (int j = 0; j < v; j++)
		    setD(i, j, Math.Min(d(i, j), d(i, k) + d(k, j)));
    }

    public static void Main()
    {
	int n = int.Parse(ReadLine());
	v = n;
	dic = new Dictionary<Tuple<int, int>, int>();
	
	for (int i = 0; i < n-1; i++)
	{
	    var tmp = ReadIntArray();
	    int a = tmp[0] - 1, b = tmp[1] - 1;
	    dic[Tuple.Create(a,b)] = dic[Tuple.Create(b,a)] = 1;
	}

	WarshallFloyd();

	int fmax=0, smax=0; // f: Fennec, s: Snuke

	for (int i = 1; i < n-1; i++)
	{
	    // calc fmax
	    int flen = (int) d(0, i);
	    int slen = (int) d(n-1, i);
	    if (flen <= slen) // >= because f moves first
	    {
		fmax++;
	    }
	    else
	    {
		smax++;
	    }
	}

	WriteLine(fmax > smax ? "Fennec" : "Snuke");
    }
}
