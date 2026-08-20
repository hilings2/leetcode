using System.Diagnostics;

public class Solution {
    public int StoneGameII(int[] piles) {
        int[] remains = new int[piles.Length + 1]; // remaining stones in piles[i:]
        for (int i = piles.Length - 1; i >= 0; i--) {
            remains[i] = remains[i + 1] + piles[i];
        }
        Dictionary<(int, int), int> memo = [];
        return DFS(piles, 0, 1, remains, memo);
    }

    private static int DFS(int[] piles, int i, int M, int[] remains, Dictionary<(int, int), int> memo) {
        if (memo.TryGetValue((i, M), out int value)) {
            return value;
        }
        if (2 * M >= piles.Length - i) {
            return remains[i];
        }
        int current = 0;
        for (int X = 1; X <= 2 * M; X++) {
            int opponent = DFS(piles, i + X, Math.Max(M, X), remains, memo); 
            current = Math.Max(current, remains[i] - opponent);
        }
        memo[(i, M)] = current;
        return current;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] piles = [2, 7, 9, 4, 4];
        Debug.Assert(sol.StoneGameII(piles) == 10);

        piles = [1, 2, 3, 4, 5, 100];
        Debug.Assert(sol.StoneGameII(piles) == 104);

        Console.WriteLine("passed");
    }
}