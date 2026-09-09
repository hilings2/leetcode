using System.Diagnostics;

public class Solution {
    public int MissingMultiple(int[] nums, int k) {
        HashSet<int> numSet = [.. nums];
        for (int m = k; m <= 200; m += k) {
            if (!nums.Contains(m)) {
                return m;
            }
        }
        return 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [8, 2, 3, 4, 6];
        int k = 2;
        Debug.Assert(sol.MissingMultiple(nums, k) == 10);

        nums = [1, 4, 7, 10, 15];
        k = 5;
        Debug.Assert(sol.MissingMultiple(nums, k) == 5);

        Console.WriteLine("passed");
    }
}