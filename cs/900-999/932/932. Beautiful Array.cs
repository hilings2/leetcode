using System.Diagnostics;

public class Solution
{
    public int[] BeautifulArray(int n)
    {
        List<int> res = [1];
        while (res.Count < n)
        {
            List<int> tmp = [];
            tmp.AddRange(res.Select(x => 2 * x - 1).Where(x => x <= n));
            tmp.AddRange(res.Select(x => 2 * x).Where(x => x <= n));
            res = tmp;
        }
        // Console.WriteLine(string.Join(", ", res));
        return res.ToArray();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] result = sol.BeautifulArray(4);
        Debug.Assert(result.Length == 4);

        result = sol.BeautifulArray(5);
        Debug.Assert(result.Length == 5);

        Console.WriteLine("passed");
    }
}
