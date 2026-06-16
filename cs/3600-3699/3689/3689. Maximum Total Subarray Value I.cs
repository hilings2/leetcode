using System.Diagnostics;

public class Solution {
    public long MaxTotalValue(int[] nums, int k) {
        int max = int.MinValue, min = int.MaxValue;
        foreach (int num in nums) {
            max = Math.Max(max, num);
            min = Math.Min(min, num);
        }
        long res = (long)(max - min) * k;
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 3, 2];
        Debug.Assert(sol.MaxTotalValue(nums, 2) == 4);

        nums = [4, 2, 5, 1];
        Debug.Assert(sol.MaxTotalValue(nums, 3) == 12);

        nums = [701025805,484014287,486484825,479659005,127752519,497392660,905035207,885813233,36336196,83624455,562558760,504283643,414557507,340461196,75269772,787067318,310705037,994901461,509673195,908722607,69228965,239220571,719440526,986897320];
        Debug.Assert(sol.MaxTotalValue(nums, 78) == 74768090670);

        Console.WriteLine("passed");
    }
}
