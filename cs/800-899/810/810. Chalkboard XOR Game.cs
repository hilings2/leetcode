using System.Diagnostics;

public class Solution {
    public bool XorGame(int[] nums) {
        int xor = 0;
        foreach (int num in nums)
        {
            xor ^= num;
        }
        return xor == 0 || nums.Length % 2 == 0;
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("LeetCode 810 Chalkboard XOR Game, C# ...");

        Solution sol = new();

        Debug.Assert(sol.XorGame(new int[] {1,1,2}) == false);
        Debug.Assert(sol.XorGame(new int[] {0,1}) == true);
        Debug.Assert(sol.XorGame(new int[] {1,2,3}) == true);
    }
}