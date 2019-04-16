using System;
using static System.Console;

class Program
{
    public static void Main()
    {
	int n = int.Parse(ReadLine());

	double ans_d = 0.0;
	double ans_i = 0;

	for (int i = 0; i < n; i++)
	{
	    var t = ReadLine().Split();
	    string s = t[0];
	    string u = t[1];

	    if (u == "JPY")
	    {
		ans_i += int.Parse(s);
	    }
	    else
	    {
		ans_d += double.Parse(s);
	    }
	}


	WriteLine((double) ans_i + 380000.0 * ans_d);
    }
}
