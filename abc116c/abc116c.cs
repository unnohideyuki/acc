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
	int n = int.Parse(ReadLine());
	var h = ReadIntArray();

	int allh = h.Sum();
	int ans = 0;
	int mode = 0;
	    
	while (allh > 0)
	{
	    for (int i = 0; i < n; i++)
	    {
		if (i == 0){ mode = 0; }
		
		if (h[i] > 0)
		{
		    if (mode == 0){ // start new watering
			ans++;
		    }
		    mode = 1;
		    h[i]--;
		    allh--;
		}
		else
		{
		    mode = 0;
		}
	    }
	}

	WriteLine(ans);
    }
}
