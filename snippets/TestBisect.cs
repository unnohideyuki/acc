using System;
using static System.Console;
using static MyUtil;

class Test
{
    public static void Main()
    {
	int[] a = {1, 2, 3, 3, 4, 4, 5};
	AssertEquals(4, Bisect.BisectRight(a, 3));
	AssertEquals(2, Bisect.BisectLeft(a, 3));

	double[] b = {1.0, 2.0, 3.14, 4.28, 5.01};
	AssertEquals(2, Bisect.BisectRight(b, 3.0));
	AssertEquals(2, Bisect.BisectRight(b, 3.0));
    }
}

