using System.Diagnostics;

public class Solution
{
    public int SnakesAndLadders(int[][] board)
    {
        int n = board.Length, target = n * n;
        Dictionary<int, int> movesToReachIndex = new() { {1, 0} };   // index => moves to reach index
        Queue<int> q = new([1]);
        while (q.Count > 0)
        {
            int index = q.Dequeue();
            for (int next = index + 1; next <= Math.Min(index + 6, target); next++)
            {
                (int r, int c) = indexToCoord(next, n);
                int dest = board[r][c] != -1 ? board[r][c] : next;
                if (dest == target)
                {
                    return movesToReachIndex[index]+1;
                }
                if (!movesToReachIndex.ContainsKey(dest))
                {
                    movesToReachIndex[dest] = movesToReachIndex[index] + 1;
                    q.Enqueue(dest);
                }
            }
        }
        return -1;
    }

    private (int, int) indexToCoord(int pos, int n)
    {
        int quotient = (pos - 1) / n, remainder = (pos - 1) % n;
        int row = n - 1 - quotient;
        int col = quotient % 2 == 0 ? remainder : n - 1 - remainder;
        return (row, col);
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[][] board =
        [
            [-1, -1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1, -1],
            [-1, -1, -1, -1, -1, -1],
            [-1, 35, -1, -1, 13, -1],
            [-1, -1, -1, -1, -1, -1],
            [-1, 15, -1, -1, -1, -1]
        ];
        Debug.Assert(sol.SnakesAndLadders(board) == 4);

        board =
        [
            [-1, -1],
            [-1, 3]
        ];
        Debug.Assert(sol.SnakesAndLadders(board) == 1);
    }
}