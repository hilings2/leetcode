using System.Diagnostics;

public class Solution {
    public int MinOperations(int[] nums) {
        int n = nums.Length;
        int z = Array.IndexOf(nums, 0);
        // Rotations preserve circular order; reversing flips its direction.
        // Sorting is possible only if reading from 0 in either direction gives 0, 1, ..., n - 1.
        bool increasing = true, decreasing = true;
        for (int i = 0; i < n; i++) {
            if (nums[(z + i) % n] != i) {
                increasing = false;
            }
            if (nums[(z - i + n) % n] != i) {
                decreasing = false;
            }
            if (!increasing && !decreasing) {
                return -1;
            }
        }
        // Increasing: z left rotations, or reverse + (n - z) left rotations + reverse.
        // These cost z and n - z + 2, respectively.
        // Decreasing: reverse + (n - 1 - z) left rotations, or (z + 1) left rotations + reverse.
        // These cost n - z and z + 2, respectively.
        return increasing ? Math.Min(z, n - z + 2) : Math.Min(n - z, z + 2);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [0, 2, 1];
        Debug.Assert(sol.MinOperations(nums) == 2);

        nums = [1, 0, 2];
        Debug.Assert(sol.MinOperations(nums) == 2);

        nums = [2, 0, 1, 3];
        Debug.Assert(sol.MinOperations(nums) == -1);

        Console.WriteLine("passed");
    }
}
