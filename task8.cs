using System;
using System.Linq;

class KnightMoving
{
    private static int[,] chessboard = new int[8, 8];
    private static int[] moveX = { 2, 1, -1, -2, -2, -1, 1, 2 };
    private static int[] moveY = { 1, 2, 2, 1, -1, -2, -2, -1 };

    static void Main(string[] args)
    {
        MoveKnight(0, 0, 1);
        DisplayChessboard();
    }

    static void MoveKnight(int x, int y, int moveCount)
    {
        chessboard[x, y] = moveCount;

        var nextMoves = GetNextMoves(x, y);
        var sortedMoves = nextMoves.OrderBy(pos => GetNextMoves(pos.Item1, pos.Item2).Count()).ToList();

        foreach (var nextMove in sortedMoves)
        {
            int nextX = nextMove.Item1;
            int nextY = nextMove.Item2;
            if (chessboard[nextX, nextY] == 0)
                MoveKnight(nextX, nextY, moveCount + 1);
        }

        chessboard[x, y] = 0;
    }

    static List<Tuple<int, int>> GetNextMoves(int x, int y)
    {
        List<Tuple<int, int>> nextMoves = new List<Tuple<int, int>>();

        for (int i = 0; i < 8; i++)
        {
            int nextX = x + moveX[i];
            int nextY = y + moveY[i];
            if (IsValidMove(nextX, nextY))
                nextMoves.Add(new Tuple<int, int>(nextX, nextY));
        }

        return nextMoves;
    }

    static bool IsValidMove(int x, int y)
    {
        return x >= 0 && x < 8 && y >= 0 && y < 8;
    }

    static void DisplayChessboard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(chessboard[i, j].ToString().PadLeft(3));
            }
            Console.WriteLine();
        }
    }
}
