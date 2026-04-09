using System.Diagnostics;

public class Solution {
    public int SmallestRangeI(int[] nums, int k) {
        int min = int.MaxValue, max = int.MinValue;
        foreach (int a in nums)
        {
            min = Math.Min(min, a);
            max = Math.Max(max, a);
        }
        return max-k > min+k ? max-k - (min+k) : 0;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();
        Debug.Assert(sol.SmallestRangeI(new int[] { 1 }, 0) == 0);
        Debug.Assert(sol.SmallestRangeI(new int[] { 0, 10 }, 2) == 6);
        Debug.Assert(sol.SmallestRangeI(new int[] { 1, 3, 6 }, 3) == 0);
    }
}