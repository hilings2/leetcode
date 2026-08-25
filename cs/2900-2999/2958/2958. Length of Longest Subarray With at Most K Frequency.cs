using System.Diagnostics;

public class Solution {
    public int MaxSubarrayLength(int[] nums, int k) {
        Dictionary<int, int> freq = [];
        int res = 0;
        for (int i = 0, j = 0; j < nums.Length; j++) {
            int cur = nums[j];
            if (!freq.ContainsKey(cur)) freq[cur] = 0;
            freq[cur]++;
            for (; freq[cur] > k; i++) {
                freq[nums[i]]--;
            }
            res = Math.Max(res, j - i + 1);
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 3, 1, 2, 3, 1, 2];
        int k = 2;
        Debug.Assert(sol.MaxSubarrayLength(nums, k) == 6);

        nums = [1, 2, 1, 2, 1, 2, 1, 2];
        k = 1;
        Debug.Assert(sol.MaxSubarrayLength(nums, k) == 2);

        nums = [5, 5, 5, 5, 5, 5, 5];
        k = 4;
        Debug.Assert(sol.MaxSubarrayLength(nums, k) == 4);

        Console.WriteLine("passed");
    }
}