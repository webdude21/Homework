namespace AlgorithmComplexity
{
    internal class AlgorithmComplexity
    {
        /// <summary>
        /// Expected running time: O(n^2).
        /// The outer loop performs n iterations (n is the size of the array)
        /// and the inner loop's iterations are of the order of n.
        /// </summary>
        private static long Compute(int[] array)
        {
            var n = array.Length;
            long count = 0;

            for (var i = 0; i < n; i++)
            {
                var start = 0;
                var end = n - 1;
                while (start < end)
                {
                    if (array[start] < array[end])
                    {
                        start++;
                        count++;
                    }
                    else
                    {
                        end--;
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Returns the number of positive elements in the rows which start
        /// with an even element.
        /// Expected running time: O(n * m) 
        /// (n is the number of rows, m - the number of columns).
        /// The worst case is when the if-statements are always true:
        /// each line starts with an even number and all the elements 
        /// in the matrix are positive. Then "count++" will get executed exactly n * m times.
        /// In the other cases this number is reduced by a constant which can be ignored.
        /// </summary>
        private static long CalcCount(int[,] matrix)
        {
            long count = 0;
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);

            for (var row = 0; row < n; row++)
            {
                if (matrix[row, 0] % 2 == 0)
                {
                    for (var col = 0; col < m; col++)
                    {
                        if (matrix[row, col] > 0)
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Returns the sum of the elements in the matrix (using recursion).
        /// Expected running time: O(n * m)
        /// (n is the number of rows, m - the number of columns).
        /// </summary>
        private static long CalcSum(int[,] matrix, int row)
        {
            long sum = 0;
            var n = matrix.GetLength(0);
            var m = matrix.GetLength(1);

            for (var col = 0; col < m; col++)
            {
                sum += matrix[row, col];
            }

            if (row + 1 < n)
            {
                sum += CalcSum(matrix, row + 1);
            }

            return sum;
        }
    }
}