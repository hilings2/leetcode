using System.Diagnostics;

public class Solution {
    private readonly int MOD = 1000000007;
    private readonly Dictionary<int, List<int>> moves = new() {
        { 0, new List<int> { 4, 6 } },
        { 1, new List<int> { 6, 8 } },
        { 2, new List<int> { 7, 9 } },
        { 3, new List<int> { 4, 8 } },
        { 4, new List<int> { 0, 3, 9 } },
        { 5, new List<int>() },
        { 6, new List<int> { 0, 1, 7 } },
        { 7, new List<int> { 2, 6 } },
        { 8, new List<int> { 1, 3 } },
        { 9, new List<int> { 2, 4 } }
    };
    public int KnightDialer(int n) {
        Dictionary<int, long> dp = new() {
            { 0, 1 },
            { 1, 1 },
            { 2, 1 },
            { 3, 1 },
            { 4, 1 },
            { 5, 1 },
            { 6, 1 },
            { 7, 1 },
            { 8, 1 },
            { 9, 1 }
        };
        for (int i = 2; i <= n; i++) {
            Dictionary<int, long> newDp = [];
            foreach ((int k, long v) in dp)
            {
                foreach (int next in moves[k])
                {
                    if (!newDp.ContainsKey(next)) {
                        newDp[next] = 0;
                    }
                    newDp[next] = (newDp[next] + v) % MOD;
                }
            }
            dp = newDp;
        }
        long res = dp.Values.Aggregate(0L, (a, b) => (a + b) % MOD) % MOD;
        return (int)res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 1;
        Debug.Assert(sol.KnightDialer(n) == 10);

        n = 2;
        Debug.Assert(sol.KnightDialer(n) == 20);

        n = 3131;
        Debug.Assert(sol.KnightDialer(n) == 136006598);

        Console.WriteLine("passed");
    }
}
