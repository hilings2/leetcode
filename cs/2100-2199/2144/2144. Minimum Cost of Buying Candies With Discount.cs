using System.Diagnostics;

public class Solution {
    public int MinimumCost(int[] cost) {
        Array.Sort(cost);
        int sum = 0;
        for (int i = cost.Length - 1; i >= 0; i -= 3)
        {
            sum += cost[i];
            if (i - 1 >= 0 )
            {
                sum += cost[i-1];
            }
        }
        return sum;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] cost = [1, 2, 3];
        Debug.Assert(sol.MinimumCost(cost) == 5);

        cost = [6, 5, 7, 9, 2, 2];
        Debug.Assert(sol.MinimumCost(cost) == 23);

        cost = [5, 5];
        Debug.Assert(sol.MinimumCost(cost) == 10);

        Console.WriteLine("passed");
    }
}
