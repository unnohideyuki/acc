using System;
using System.IO;
using static System.Console;
using static MyUtil;

class Test
{
    public static void Main()
    {
	int[] a = {1, 2, 3, 5, 8, 13, 21};

	StreamReader sr = new StreamReader("testperm.txt");
	
	do
	{
	    int expected = int.Parse(sr.ReadLine());
	    int actual =
		int.Parse($"{a[0]}{a[1]}{a[2]}{a[3]}{a[4]}{a[5]}{a[6]}");
	    AssertEquals(expected, actual);
	} while (NextPermutation(a));
    }
}
