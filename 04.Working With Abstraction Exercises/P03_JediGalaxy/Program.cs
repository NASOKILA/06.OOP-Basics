using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class Program
    {
        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            int[,] matrix = new int[x, y];

            FillMatrix(x, y, matrix);

            string command = Console.ReadLine();

            long sum = 0;

            GetTotalSum(matrix, ref command, ref sum);

            Console.WriteLine(sum);
        }

        private static void GetTotalSum(int[,] matrix, ref string command, ref long sum)
        {
            while (command != "Let the Force be with you")
            {
                int[] ivoS = command
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int[] evil = Console.ReadLine()
                    .Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                EvilDestroysStars(matrix, evil);

                sum = IvoCollectingStars(matrix, sum, ivoS);

                command = Console.ReadLine();
            }
        }

        private static void EvilDestroysStars(int[,] matrix, int[] evil)
        {
            int xE = evil[0];
            int yE = evil[1];

            while (xE >= 0 && yE >= 0)
            {
                if (xE >= 0 && xE < matrix.GetLength(0) && yE >= 0 && yE < matrix.GetLength(1))
                {
                    matrix[xE, yE] = 0;
                }
                xE--;
                yE--;
            }
        }

        private static long IvoCollectingStars(int[,] matrix, long sum, int[] ivoS)
        {
            int xI = ivoS[0];
            int yI = ivoS[1];

            while (xI >= 0 && yI < matrix.GetLength(1))
            {
                if (xI >= 0 && xI < matrix.GetLength(0) && yI >= 0 && yI < matrix.GetLength(1))
                {
                    sum += matrix[xI, yI];
                }

                yI++;
                xI--;
            }

            return sum;
        }

        private static void FillMatrix(int x, int y, int[,] matrix)
        {
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }
    }
}
