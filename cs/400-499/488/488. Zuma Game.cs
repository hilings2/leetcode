using System.Diagnostics;

public class Solution
{
    private readonly Dictionary<string, int> memo = [];

    public int FindMinStep(string board, string hand)
    {
        return Solve(board, string.Concat(hand.OrderBy(c => c)));
    }

    private int Solve(string board, string hand)
    {
        if (string.IsNullOrEmpty(board)) return 0;
        if (string.IsNullOrEmpty(hand)) return -1;

        string key = board + "#" + hand;
        if (memo.TryGetValue(key, out int value)) return value;

        int best = int.MaxValue;
        for (int i = 0; i < hand.Length; i++)
        {
            if (i > 0 && hand[i] == hand[i - 1]) continue;
            char c = hand[i];
            for (int j = 0; j <= board.Length; j++)
            {
                if (j > 0 && board[j - 1] == c) continue;
                bool extend = j < board.Length && board[j] == c;
                bool split = j > 0 && j < board.Length && board[j - 1] == board[j];
                if (!extend && !split) continue;
                string newBoard = board[..j] + c + board[j..];
                newBoard = Remove(newBoard);
                string newHand = hand.Remove(i, 1);
                int moves = Solve(newBoard, newHand);
                if (moves != -1)
                {
                    best = Math.Min(best, moves + 1);
                }
            }
        }
        int res = best == int.MaxValue ? -1 : best;
        memo[key] = res;
        return res;
    }

    private static string Remove(string board)
    {
        for (int i = 0; i < board.Length;)
        {
            int j = i + 1;
            while (j < board.Length && board[j] == board[i]) j++;
            if (j - i < 3)
            {
                i = j;
            }
            else
            {
                board = board[..i] + board[j..];
                if (i > 0) i--;
                while (i - 1 >= 0 && board[i - 1] == board[i]) i--;
            }
        }
        return board;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        string board = "WRRBBW";
        string hand = "RB";
        Debug.Assert(sol.FindMinStep(board, hand) == -1);

        board = "WWRRBBWW";
        hand = "WRBRW";
        Debug.Assert(sol.FindMinStep(board, hand) == 2);

        board = "G";
        hand = "GGGGG";
        Debug.Assert(sol.FindMinStep(board, hand) == 2);

        board = "RRWWRRBBRR";
        hand = "WB";
        Debug.Assert(sol.FindMinStep(board, hand) == 2);

        board = "WRBWYGRGYGWWBWRW";
        hand = "YWGRB";
        // Console.WriteLine(sol.FindMinStep(board, hand));
        Debug.Assert(sol.FindMinStep(board, hand) == -1);

        Console.WriteLine("passed");
    }
}
