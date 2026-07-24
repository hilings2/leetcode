using System.Diagnostics;

public class Solution {
    public IList<int> PowerfulIntegers(int x, int y, int bound) {
        int smaller = 101;
        if (x != 1 && x < smaller) smaller = x;
        if (y != 1 && y < smaller) smaller = y;

        int n = 0;
        while (Pow(smaller, n) <= bound)
        {
            n++;
        }

        List<int> res = [];
        for (int i = 0; i <= n; i++)
        {
            long px = Pow(x, i);
            if (px > bound) break;
            for (int j = 0; j <= n; j++)
            {
                long sum = px + Pow(y, j);
                if (sum <= bound)
                {
                    res.Add((int)sum);
                }
                else
                {
                    break;
                }
            }
        }
        return res.Distinct().ToList();
    }

    private static long Pow(int a, int e)
    {
        long res = 1;
        for (int i = 0; i < e; i++)
        {
            res *= a;
        }
        return res;        
    }
}

class Program {
    static bool SameSet(IList<int> actual, int[] expected) {
        return new HashSet<int>(actual).SetEquals(expected);
    }

    static void Main(string[] args) {
        Solution sol = new();

        int x = 2, y = 3, bound = 10;
        Debug.Assert(SameSet(sol.PowerfulIntegers(x, y, bound), [2, 3, 4, 5, 7, 9, 10]));

        x = 3; y = 5; bound = 15;
        Debug.Assert(SameSet(sol.PowerfulIntegers(x, y, bound), [2, 4, 6, 8, 10, 14]));

        Console.WriteLine("passed");
    }
}
