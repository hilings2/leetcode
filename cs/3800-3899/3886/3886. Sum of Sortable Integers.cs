using System.Diagnostics;

public class Solution {
    public int SortableIntegers(int[] nums) {
        int n = nums.Length;
        int result = 0;
        for (int k = 1; k <= n; k++) { // check each divisor
            if (n % k == 0 && IsSortable(nums, k))
                result += k;
        }
        return result;
    }

    private static bool IsSortable(int[] nums, int k) {
        int prevMax = int.MinValue;
        for (int i = 0; i < nums.Length; i += k) { // scan each block of length k
            int drops = nums[i] < nums[i + k - 1] ? 1 : 0; // wraparound drop
            int max = nums[i]; // find max of this block
            for (int j = i; j < i + k; j++) {
                if (nums[j] < prevMax) // blocks must be non-decreasing compared to the previous block
                    return false;
                if (nums[j] > max) // update the max of this block
                    max = nums[j];
                if (j > i && nums[j - 1] > nums[j] && ++drops > 1) // count drops
                    return false;
            }
            prevMax = max;
        }
        return true;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [3, 1, 2];
        Debug.Assert(sol.SortableIntegers(nums) == 3);

        nums = [7, 6, 5];
        Debug.Assert(sol.SortableIntegers(nums) == 0);

        nums = [5, 8];
        Debug.Assert(sol.SortableIntegers(nums) == 3);

        Console.WriteLine("passed");
    }
}
