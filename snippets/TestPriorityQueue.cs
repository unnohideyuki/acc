using System;
using static System.Console;
using static MyUtil;
using System.Collections.Generic;
using static PriorityQueue<int>;

public class Program
{
    public static void Main()
    {
        PriorityQueue<int> Q = new PriorityQueue<int>(1);
        Q.Push(1);
        Q.Push(3);
        Q.Push(2);
        Q.Push(1);

        AssertEquals(3, Q.Pop());
        AssertEquals(2, Q.Pop());
        AssertEquals(1, Q.Pop());
        AssertEquals(1, Q.Pop());
    }
}
