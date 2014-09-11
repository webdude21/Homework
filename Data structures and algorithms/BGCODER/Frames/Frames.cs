namespace Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Frame = System.Tuple<string, string>;

    internal class Frames
    {
        private static readonly SortedSet<string> ResultSet = new SortedSet<string>();

        private static void Main()
        {
            var input = ReadInput().ToArray();
            GeneratePermutations(input, 0);
            Console.WriteLine(ResultSet.Count);
            Console.WriteLine(string.Join(Environment.NewLine, ResultSet));
        }

        private static IEnumerable<Frame> ReadInput()
        {
            var frameCount = int.Parse(Console.ReadLine());
            var frames = new List<Frame>();

            for (var i = 0; i < frameCount; i++)
            {
                var currentFrame = Console.ReadLine().Split();
                frames.Add(new Frame(currentFrame[0], currentFrame[1]));
            }

            return frames;
        }

        private static void GeneratePermutations(Frame[] arr, int k)
        {
            if (k >= arr.Length)
            {
                ResultSet.Add(ResultToString(arr));
            }
            else
            {
                for (var i = k; i < arr.Length; i++)
                {
                    Swap(ref arr[k], ref arr[i]);
                    GeneratePermutations(arr, k + 1);
                    FlipFrame(ref arr[k]);
                    GeneratePermutations(arr, k + 1);
                    FlipFrame(ref arr[k]);
                    Swap(ref arr[k], ref arr[i]);
                }
            }
        }

        private static void FlipFrame(ref Frame tuple)
        {
            tuple = new Frame(tuple.Item2, tuple.Item1);
        }

        private static string ResultToString(IEnumerable<Frame> arr)
        {
            return string.Join(" | ", arr.Select(frame => string.Format("({0}, {1})", frame.Item1, frame.Item2)));
        }

        private static void Swap<T>(ref T first, ref T second)
        {
            var oldFirst = first;
            first = second;
            second = oldFirst;
        }
    }
}