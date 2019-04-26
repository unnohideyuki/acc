using System;
using static System.Console;

class Program
{
    public static void Main()
    {
	var h = new int[1000000+1];

	int n = int.Parse(ReadLine());
	h[n] = 1;

	for (int i = 2; i < 1000000; i++)
	{
	    n = (n&1) == 0 ? n/2 : 3*n + 1; 
	    if (h[n] != 0)
	    {
		WriteLine(i);
		break;
	    }
	    h[n] = 1;
	}
    }
}
