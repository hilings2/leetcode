using System.Collections.Generic;
using System.Diagnostics;

public class Solution {
    public int SumCounts(IList<int> nums) {
        int result = 0;
        for (int i = 0; i < nums.Count; i++) {
            HashSet<int> distinct = [];
            for (int j = i; j < nums.Count; j++) {
                distinct.Add(nums[j]);
                result += distinct.Count * distinct.Count;
            }
        }
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 2, 1];
        Debug.Assert(sol.SumCounts(nums) == 15);

        nums = [1, 1];
        Debug.Assert(sol.SumCounts(nums) == 3);

        Console.WriteLine("passed");
    }
}
