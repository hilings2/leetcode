using System.Diagnostics;

public class Solution {
    public bool Check(int[] nums) {
        bool rotated = false;
        for (int i = 1; i < nums.Length; i++) {
            if (nums[i] >= nums[i-1]) continue;
            if (rotated) return false;
            rotated = true;
        }
        return rotated == false || nums[0] >= nums[^1];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [3, 4, 5, 1, 2];
        Debug.Assert(sol.Check(nums) == true);

        nums = [2, 1, 3, 4];
        Debug.Assert(sol.Check(nums) == false);

        nums = [1, 2, 3];
        Debug.Assert(sol.Check(nums) == true);

        Console.WriteLine("passed");
    }
}
