using System;
using System.IO;
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
    public static long[] ReadLongArray()
    {
 return ReadLine().Split().Select(x => long.Parse(x)).ToArray();
    }
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
   public static bool ChMin<T>(ref T a, T b) where T : IComparable
    {
 if (a.CompareTo(b) > 0)
 {
     a = b;
     return true;
 }
 return false;
    }
    public static bool ChMax<T>(ref T a, T b) where T : IComparable
    {
 if (a.CompareTo(b) < 0)
 {
     a = b;
     return true;
 }
 return false;
    }
    public static void WarshallFloyd(int[,] d, int v)
    {
 for (int k = 0; k < v; k++)
     for (int i = 0; i < v; i++)
  for (int j = 0; j < v; j++)
      d[i, j] = Math.Min(d[i, j], d[i, k] + d[k, j]);
    }
    public static bool NextPermutation<T>(T[] a) where T : IComparable
    {
 if (a.Length <= 1) return false;
 for (int i = a.Length - 1; i > 0; i--)
 {
     int k = i - 1;
     if (a[k].CompareTo(a[i]) < 0)
     {
  int j = a.Length - 1;
  while (a[k].CompareTo(a[j]) >= 0){ j--; }
  Swap(ref a[k], ref a[j]);
  Array.Reverse(a, i, a.Length - i);
  return true;
     }
 }
 Array.Reverse(a);
 return false;
    }
    public static int PopulationCount(int x)
    {
 x = (x & 0x55555555) + (x >> 1 & 0x55555555);
 x = (x & 0x33333333) + (x >> 2 & 0x33333333);
 x = (x & 0x0f0f0f0f) + (x >> 4 & 0x0f0f0f0f);
 x = (x & 0x00ff00ff) + (x >> 8 & 0x00ff00ff);
 return (x & 0x0000ffff) + (x >>16 & 0x0000ffff);
    }
    public static void AutoFlushOff()
    {
 var sw =
     new StreamWriter(Console.OpenStandardOutput()){AutoFlush = false};
 Console.SetOut(sw);
    }
    public static void Flush()
    {
 Console.Out.Flush();
    }
}
class Bisect
{
    public static
 int BisectRight<T>(T[] a, T x, int lo=0, int hi=-1) where T:IComparable
    {
 if (hi < 0) hi = a.Length;
 while (lo < hi)
 {
     int mid = lo + (hi - lo) / 2;
     if (x.CompareTo(a[mid]) < 0) { hi = mid; }
     else { lo = mid + 1; }
 }
 return lo;
    }
    public static
 int BisectLeft<T>(T[] a, T x, int lo=0, int hi=-1) where T:IComparable
    {
 if (hi < 0) hi = a.Length;
 while (lo < hi)
 {
     int mid = lo + (hi - lo) / 2;
     if (a[mid].CompareTo(x) < 0) { lo = mid + 1; }
     else { hi = mid; }
 }
 return lo;
    }
}
