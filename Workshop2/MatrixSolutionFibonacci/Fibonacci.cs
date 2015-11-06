using System;

namespace MatrixSolutionFibonacci
{
    class Fibonacci
    {
        private const int Module = 1000000007;

        private static void Main()
        {
            long n = long.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n));
        }

        private static long Fib(long n)
        {
            long[,] matrix = new long[,]
            {
                {1, 1},
                {1, 0}
            };

            if (n == 0)
            {
                return 0;
            }

            Power(matrix, n - 1);

            return matrix[0, 0];
        }

        private static void Power(long[,] matrix, long n)
        {
            if (n == 0 || n == 1)
            {
                return;
            }

            long i;
            long[,] baseMatrix = { { 1, 1 }, { 1, 0 } };

            Power(matrix, n / 2);
            Multiply(matrix, matrix);

            if (n % 2 != 0)
            {
                Multiply(matrix, baseMatrix);
            }
        }

        private static void Multiply(long[,] matrix, long[,] baseMatrix)
        {
            long x = (matrix[0, 0] * baseMatrix[0, 0] + matrix[0, 1] * baseMatrix[1, 0]) % Module;
            long y = (matrix[0, 0] * baseMatrix[0, 1] + matrix[0, 1] * baseMatrix[1, 1]) % Module;
            long z = (matrix[1, 0] * baseMatrix[0, 0] + matrix[1, 1] * baseMatrix[1, 0]) % Module;
            long w = (matrix[1, 0] * baseMatrix[0, 1] + matrix[1, 1] * baseMatrix[1, 1]) % Module;

            matrix[0, 0] = x;
            matrix[0, 1] = y;
            matrix[1, 0] = z;
            matrix[1, 1] = w;
        }
    }
}
