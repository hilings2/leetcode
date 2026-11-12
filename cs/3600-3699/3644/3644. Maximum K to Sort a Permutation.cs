using System.Diagnostics;

public class Solution {
    public int SortPermutation(int[] nums) {
        int k = -1;
        for (int i = 0; i < nums.Length; i++) {
            if (nums[i] != i) {
                k &= nums[i];
            }
            if (k == 0) return 0;
        }
        return k == -1 ? 0 : k;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [0, 3, 2, 1];
        Debug.Assert(sol.SortPermutation(nums) == 1);

        nums = [0, 1, 3, 2];
        Debug.Assert(sol.SortPermutation(nums) == 2);

        nums = [3, 2, 1, 0];
        Debug.Assert(sol.SortPermutation(nums) == 0);

        Console.WriteLine("passed");
    }
}
