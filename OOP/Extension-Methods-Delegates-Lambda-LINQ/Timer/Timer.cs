// Using delegates write a class Timer that has can execute certain method at each t seconds.

using System;
using System.Threading;

class Timer
{
    static void Main()
    {
        int i = 0;
        SetTimer(new Action(() => Console.WriteLine(i++)), 0.5);
    }

    static void SetTimer(Action doAction, dynamic t)
    {
        while (true)
        {
            Thread.Sleep((int)(t * 1000));
            doAction();
        }
    }
}
