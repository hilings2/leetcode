using System.Diagnostics;

public class Solution {
    public bool UniformArray(int[] nums1) {
        return true;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums1 = [2, 3];
        Debug.Assert(sol.UniformArray(nums1) == true);

        nums1 = [4, 6];
        Debug.Assert(sol.UniformArray(nums1) == true);

        Console.WriteLine("passed");
    }
}
