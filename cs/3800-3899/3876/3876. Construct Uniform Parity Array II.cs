using System.Diagnostics;

public class Solution {
    public bool UniformArray(int[] nums1) {
        bool allEven = true;
        int min = int.MaxValue;
        foreach (int num in nums1) {
            if (num % 2 != 0) allEven = false;
            min = Math.Min(min, num);
        }
        return allEven || min % 2 == 1;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums1 = [1, 4, 7];
        Debug.Assert(sol.UniformArray(nums1) == true);

        nums1 = [2, 3];
        Debug.Assert(sol.UniformArray(nums1) == false);

        nums1 = [4, 6];
        Debug.Assert(sol.UniformArray(nums1) == true);

        Console.WriteLine("passed");
    }
}
