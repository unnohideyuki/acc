using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;
using System.Runtime.CompilerServices;
using static MyUtil;
class MyUtil
{
    public static void AssertEquals<T>(
           T expected,
           T actual,
           [CallerLineNumber] int lno = 0
           )
 where T : IComparable
    {
 if (expected.CompareTo(actual) != 0)
 {
     WriteLine($"Assertion Error at line {lno}:");
     WriteLine($"\texpected: {expected}");
     WriteLine($"\t  actual: {actual}");
     Environment.Exit(1);
 }
    }
    public static int Gcd(int a, int b)
    {
 if (a < b){ return Gcd(b, a); }
 while (b != 0)
 {
     var r = a % b;
     a = b;
     b = r;
 }
 return a;
    }
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
class Bisect
{
    public static int BisectRight<T>(T[] a, T x) where T : IComparable
    {
 int lo = 0, hi = a.Length;
 while (lo < hi)
 {
     int mid = (lo + hi) / 2;
     if (x.CompareTo(a[mid]) < 0) { hi = mid; }
     else { lo = mid + 1; }
 }
 return lo;
    }
}
