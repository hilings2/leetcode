using System.Diagnostics;

public class Solution {
    public int Search(int[] nums, int target) {
        int l = 0, r = nums.Length - 1;
        while (l <= r) {
            int m = l + (r - l) / 2;
            if (target == nums[m]) return m;
            if (target < nums[m])
            {
                if (nums[l] <= target || nums[l] > nums[m])
                    r = m - 1;
                else
                    l = m + 1;
            }
            else
            {
                if (target <= nums[r] || nums[m] > nums[r])
                    l = m + 1;
                else
                    r = m - 1;
            }
        }
        return -1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [4, 5, 6, 7, 0, 1, 2];
        Debug.Assert(sol.Search(nums, 0) == 4);

        nums = [4, 5, 6, 7, 0, 1, 2];
        Debug.Assert(sol.Search(nums, 3) == -1);

        nums = [1];
        Debug.Assert(sol.Search(nums, 0) == -1);

        Console.WriteLine("passed");
    }
}
