using System.Diagnostics;

public class Solution {
    public int UniqueXorTriplets(int[] nums) {
        HashSet<int> uniqueXorPairs = [];
        int n = nums.Length;
        for (int i = 0; i < n; i++) {
            for (int j = i; j < n; j++) {
                uniqueXorPairs.Add(nums[i] ^ nums[j]);
            }
        }
        HashSet<int> uniqueXorTriplets = [];
        for (int i = 0; i < n; i++) {
            foreach (int xorValue in uniqueXorPairs) {
                uniqueXorTriplets.Add(nums[i] ^ xorValue);
            }
        }
        return uniqueXorTriplets.Count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] nums = [1, 3];
        Debug.Assert(sol.UniqueXorTriplets(nums) == 2);

        nums = [6, 7, 8, 9];
        Debug.Assert(sol.UniqueXorTriplets(nums) == 4);

        Console.WriteLine("passed");
    }
}
