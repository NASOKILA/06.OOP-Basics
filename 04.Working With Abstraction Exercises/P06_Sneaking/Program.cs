using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] room;
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            room = new char[n][];

            FillRoom(n);

            var moves = Console.ReadLine().ToCharArray();

            int[] samPosition = new int[2];
            FindSamPosition(samPosition);
            IterateMoves(moves, samPosition);

        }

        private static void IterateMoves(char[] moves, int[] samPosition)
        {
            for (int i = 0; i < moves.Length; i++)
            {
                IterateRoom();

                int[] getEnemy = new int[2];
                GetEnemy(samPosition, getEnemy);

                SamDies(samPosition, getEnemy);

                SamMoves(moves, samPosition, i);

                SamStepsOverEnemy(samPosition, getEnemy);

                if (room[getEnemy[0]][getEnemy[1]] == 'N' && samPosition[0] == getEnemy[0])
                {
                    SamKillesNikolay(getEnemy);
                }
            }
        }

        private static void SamDies(int[] samPosition, int[] getEnemy)
        {
            if (samPosition[1] < getEnemy[1] && room[getEnemy[0]][getEnemy[1]] == 'd' && getEnemy[0] == samPosition[0])
            {
                SamKilledByEnemyOne(samPosition);
            }
            else if (getEnemy[1] < samPosition[1] && room[getEnemy[0]][getEnemy[1]] == 'b' && getEnemy[0] == samPosition[0])
            {
                SamKilledByEnemyTwo(samPosition);
            }
        }

        private static void SamStepsOverEnemy(int[] samPosition, int[] getEnemy)
        {
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
        }

        private static void GetEnemy(int[] samPosition, int[] getEnemy)
        {
            for (int j = 0; j < room[samPosition[0]].Length; j++)
            {
                if (room[samPosition[0]][j] != '.' && room[samPosition[0]][j] != 'S')
                {
                    getEnemy[0] = samPosition[0];
                    getEnemy[1] = j;
                }
            }
        }

        private static void SamKillesNikolay(int[] getEnemy)
        {
            room[getEnemy[0]][getEnemy[1]] = 'X';
            Console.WriteLine("Nikoladze killed!");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void SamMoves(char[] moves, int[] samPosition, int i)
        {
            room[samPosition[0]][samPosition[1]] = '.';
            switch (moves[i])
            {
                case 'U':
                    samPosition[0]--;
                    break;
                case 'D':
                    samPosition[0]++;
                    break;
                case 'L':
                    samPosition[1]--;
                    break;
                case 'R':
                    samPosition[1]++;
                    break;
                default:
                    break;
            }
            room[samPosition[0]][samPosition[1]] = 'S';
        }

        private static void SamKilledByEnemyTwo(int[] samPosition)
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void SamKilledByEnemyOne(int[] samPosition)
        {
            room[samPosition[0]][samPosition[1]] = 'X';
            Console.WriteLine($"Sam died at {samPosition[0]}, {samPosition[1]}");
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    Console.Write(room[row][col]);
                }
                Console.WriteLine();
            }
            Environment.Exit(0);
        }

        private static void IterateRoom()
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                  col = MoveEnemies(row, col);
                }
            }
        }

        private static int MoveEnemies(int row, int col)
        {
            if (room[row][col] == 'b')
            {
                col = MoveEnemyOne(row, col);
            }
            else if (room[row][col] == 'd')
            {
                MoveEnemyTwo(row, col);
            }

            return col;
        }

        private static int MoveEnemyOne(int row, int col)
        {
            if (row >= 0 && row < room.Length && col + 1 >= 0 && col + 1 < room[row].Length)
            {
                room[row][col] = '.';
                room[row][col + 1] = 'b';
                col++;
            }
            else
            {
                room[row][col] = 'd';
            }

            return col;
        }

        private static void MoveEnemyTwo(int row, int col)
        {
            if (row >= 0 && row < room.Length && col - 1 >= 0 && col - 1 < room[row].Length)
            {
                room[row][col] = '.';
                room[row][col - 1] = 'd';
            }
            else
            {
                room[row][col] = 'b';
            }
        }

        private static void FindSamPosition(int[] samPosition)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col] == 'S')
                    {
                        samPosition[0] = row;
                        samPosition[1] = col;
                    }
                }
            }
        }

        private static void FillRoom(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var input = Console.ReadLine().ToCharArray();
                room[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    room[row][col] = input[col];
                }
            }
        }
    }
}
