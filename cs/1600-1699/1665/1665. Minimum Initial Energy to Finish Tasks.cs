using System.Diagnostics;

public class Solution
{
    public int MinimumEffort(int[][] tasks)
    {
        Array.Sort(tasks, (a, b) => b[1] - b[0] - (a[1] - a[0]));
        int res = 0;
        int energy = 0;
        foreach (int[] task in tasks)
        {
            if (energy < task[1])
            {
                res += task[1] - energy;
                energy = task[1];
            }
            energy -= task[0];
        }
        return res;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[][] tasks = [[1, 2], [2, 4], [4, 8]];
        Debug.Assert(sol.MinimumEffort(tasks) == 8);

        tasks = [[1, 3], [2, 4], [10, 11], [10, 12], [8, 9]];
        Debug.Assert(sol.MinimumEffort(tasks) == 32);

        tasks = [[1, 7], [2, 8], [3, 9], [4, 10], [5, 11], [6, 12]];
        Debug.Assert(sol.MinimumEffort(tasks) == 27);

        tasks = [[1, 1], [1, 3]];
        Debug.Assert(sol.MinimumEffort(tasks) == 3);

        tasks = [[1, 1], [1, 4], [1, 4]];
        Debug.Assert(sol.MinimumEffort(tasks) == 5);

        Console.WriteLine("passed");
    }
}
