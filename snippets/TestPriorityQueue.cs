using System;
using static System.Console;
using static MyUtil;
using System.Collections.Generic;
using static PriorityQueue<int>;

public class Program
{
    public static void Main()
    {
        PriorityQueue<int> Q0 = new PriorityQueue<int>(0);
        Q0.Push(1);
        Q0.Push(3);
        Q0.Push(2);
        Q0.Push(1);

        AssertEquals(1, Q0.Pop());
        AssertEquals(1, Q0.Pop());
        AssertEquals(2, Q0.Pop());
        AssertEquals(3, Q0.Pop());

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
