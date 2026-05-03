using System.Diagnostics;

public class Solution
{
    public int NumSubarraysWithSum0(int[] nums, int goal)
    {
        int sum = 0;
        List<int> count = new() { 1 };
        foreach (int num in nums)
        {
            int prefixSum = count.Count - 1 + num; ;
            if (prefixSum >= goal)
            {
                sum += count[prefixSum - goal];
            }
            if (prefixSum == count.Count - 1)
            {
                count[prefixSum]++;
            }
            else
            {
                count.Add(1);
            }
        }
        return sum;
    }

    public int NumSubarraysWithSum(int[] nums, int goal)
    {
        int prefixSum = 0;
        int sum = 0;
        Dictionary<int, int> count = new() { [0] = 1 };
        foreach (int num in nums)
        {
            prefixSum += num;
            sum += count.GetValueOrDefault(prefixSum - goal, 0);
            count[prefixSum] = count.GetValueOrDefault(prefixSum, 0) + 1;
        }
        return sum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] nums = [1, 0, 1, 0, 1];
        int goal = 2;
        Debug.Assert(sol.NumSubarraysWithSum(nums, goal) == 4);

        nums = [0, 0, 0, 0, 0];
        goal = 0;
        Debug.Assert(sol.NumSubarraysWithSum(nums, goal) == 15);

        Console.WriteLine("passed");
    }
}