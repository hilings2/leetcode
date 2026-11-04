using System.Diagnostics;

public class Solution {
    private const int MOD = 1_000_000_007;
    private long[][] C = [];
    public int NumOfWays(int[] nums) {
        int n = nums.Length;
        C = new long[n][];
        for (int i = 0; i < n; i++) {
            C[i] = new long[i + 1];
            C[i][0] = C[i][i] = 1;
            for (int j = 1; j < i; j++) {
                C[i][j] = (C[i-1][j-1] + C[i-1][j]) % MOD; // Pascal's triangle modulo MOD
            }
        }
        return (int)((Ways([.. nums]) - 1 + MOD) % MOD);
    }

    private long Ways(List<int> nums) {
        if (nums.Count <= 2) return 1;
        int root = nums[0];
        List<int> L = [], R = [];
        for (int i = 1; i < nums.Count; i++) {
            if (nums[i] < root) L.Add(nums[i]);
            else R.Add(nums[i]);
        }
        // Interleave(L+R) * Permutation(L) * Permutation(R)
        return C[nums.Count - 1][L.Count] * Ways(L) % MOD * Ways(R) % MOD;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [2, 1, 3];
        Debug.Assert(sol.NumOfWays(nums) == 1);

        nums = [3, 4, 5, 1, 2];
        Debug.Assert(sol.NumOfWays(nums) == 5);

        nums = [1, 2, 3];
        Debug.Assert(sol.NumOfWays(nums) == 0);

        Console.WriteLine("passed");
    }
}
