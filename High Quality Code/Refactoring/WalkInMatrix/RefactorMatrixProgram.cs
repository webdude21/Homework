namespace RefactoredWalkInMatrix
{
    using System;

    using RefactorMatrix;

    internal class RefactorMatrixProgram
    {
        private static void Main()
        {
            var size = GetInput();

            var walk = new WalkInMatrix(size);

            walk.FillMatrix();

            Console.WriteLine(walk.ToString());
        }

        private static int GetInput()
        {
            Console.WriteLine("Enter a positive number ");
            var input = Console.ReadLine();
            int n;
            while (!int.TryParse(input, out n) || n < 0 || n > 100)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }
    }
}