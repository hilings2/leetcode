using System.Diagnostics;

public class Solution {
    public int TotalFruit(int[] fruits) {
        Dictionary<int, int> fruitStats = new();
        int res = 0;
        for (int i = 0, j = 0; j < fruits.Length; j++)
        {
            fruitStats[fruits[j]] = fruitStats.GetValueOrDefault(fruits[j], 0) + 1;
            while (fruitStats.Count > 2)
            {
                fruitStats[fruits[i]]--;
                if (fruitStats[fruits[i]] == 0)
                {
                    fruitStats.Remove(fruits[i]);
                }
                i++;
            }
            res = Math.Max(res, j - i + 1);
        }
        return res;
    }
}

 class Program
{
    static void Main()
    {
        Console.WriteLine("LeetCode 904 Fruit Into Baskets, C# ...");

        Solution solution = new();

        Debug.Assert(solution.TotalFruit(new int[] {1,2,1}) == 3);
        Debug.Assert(solution.TotalFruit(new int[] {0,1,2,2}) == 3);
        Debug.Assert(solution.TotalFruit(new int[] {1,2,3,2,2}) == 4);
    }
}