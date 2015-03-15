// Using delegates write a class Timer that has can execute certain method at each t seconds.

namespace Timer
{
    using System;
    using System.Threading;

    internal class Timer
    {
        private static void Main()
        {
            var i = 0;
            SetTimer(() => Console.WriteLine(i++), 0.5);
        }

        private static void SetTimer(Action doAction, dynamic t)
        {
            while (true)
            {
                Thread.Sleep((int)(t * 1000));
                doAction();
            }
        }
    }
}