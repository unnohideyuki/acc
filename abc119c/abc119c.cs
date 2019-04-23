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
	int n, a, b, c;
	var t = ReadIntArray();
	n = t[0]; a = t[1]; b = t[2]; c = t[3];

	var l = new int[n];
	for (int i = 0; i < n; i++)
	{
	    l[i] = int.Parse(ReadLine());
	}
	
	int maxi = 1 << (n*2);
	int ans = 1000000000;

	for (int i = 0; i < maxi; i++)
	{
	    int alen = 0, anum = 0;
	    int blen = 0, bnum = 0;
	    int clen = 0, cnum = 0;

	    int pat = i;
	    for (int j = 0; j < n; j++)
	    {
		switch (pat&3)
		{
		    case 0: /* nothing to do */
			break;
		    case 1: /* used for A */
			alen += l[j];
			anum++;
			break;
		    case 2: /* used for B */
			blen += l[j];
			bnum++;
			break;
		    case 3: /* used for C */
			clen += l[j];
			cnum++;
			break;
		}
		pat >>= 2;
	    }

	    if (anum > 0 && bnum > 0 && cnum > 0)
	    {
		int score = Math.Abs(a - alen) + 10 * (anum - 1)
		    +       Math.Abs(b - blen) + 10 * (bnum - 1)
		    +       Math.Abs(c - clen) + 10 * (cnum - 1);
		ans = Math.Min(ans, score);
	    }
	}

	WriteLine(ans);
    }
}
