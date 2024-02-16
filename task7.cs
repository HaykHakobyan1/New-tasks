using System;

class QueenPlacement
{
    private static int[,] chessboard = new int[8, 8];

    static void Main(string[] args)
    {
        PlaceQueens(0);
        DisplayChessboard();
    }

    static void PlaceQueens(int row)
    {
        if (row == 8)
            return;

        for (int col = 0; col < 8; col++)
        {
            if (IsSafe(row, col))
            {
                chessboard[row, col] = 1;
                PlaceQueens(row + 1);
                chessboard[row, col] = 0;
            }
        }
    }

    static bool IsSafe(int row, int col)
    {
        for (int i = 0; i < row; i++)
        {
            if (chessboard[i, col] == 1)
                return false;

            int diff = row - i;
            if (col - diff >= 0 && chessboard[i, col - diff] == 1)
                return false;

            if (col + diff < 8 && chessboard[i, col + diff] == 1)
                return false;
        }

        return true;
    }

    static void DisplayChessboard()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                Console.Write(chessboard[i, j] + " ");
            }
            Console.WriteLine();
        }
    }
}
