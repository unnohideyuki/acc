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
    static List<int>[] v;
    static bool[] visited;

    static void dfs(int[] lens, int n, int x)
    {
	lens[n] = x;
	visited[n] = true;
	foreach (int m in v[n])
	{
	    if (!visited[m]) dfs(lens, m, x+1);
	}
    }
    
    public static void Main()
    {
	int n = int.Parse(ReadLine());

	v = new List<int>[n];
	for (int i = 0; i < n; i++)
	    v[i] = new List<int>();
	
	for (int i = 0; i < n-1; i++)
	{
	    var tmp = ReadIntArray();
	    int a = tmp[0] - 1, b = tmp[1] - 1;
	    v[a].Add(b); v[b].Add(a);
	}

	var flens = new int[n];
	var slens = new int[n];

	visited = new bool[n];
	dfs(flens, 0, 0);

	Array.Clear(visited, 0, visited.Length);
	dfs(slens, n-1, 0);

	int fmax=0, smax=0; // f: Fennec, s: Snuke

	for (int i = 1; i < n-1; i++)
	    if (flens[i] <= slens[i]) fmax++;
	    else		      smax++;

	WriteLine(fmax > smax ? "Fennec" : "Snuke");
    }
}
