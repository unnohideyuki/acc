using System;
using static System.Console;
using static MyUtil;

class Test
{
    public static void Main()
    {
	int[,] d = new int[3, 3];

	int inf = 1000000000;
	
	d[0, 1] = 2;
	d[0, 2] = 10;
	d[1, 0] = inf;
	d[1, 2] = 3;
	d[2, 0] = inf;
	d[2, 1] = inf;

	WarshallFloyd(d, 3);
	
	AssertEquals(2, d[0, 1]);
	AssertEquals(5, d[0, 2]);
	AssertEquals(3, d[1, 2]);
    }
}
