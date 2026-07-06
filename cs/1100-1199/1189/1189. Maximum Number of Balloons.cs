using System.Diagnostics;

public class Solution {
    public int MaxNumberOfBalloons(string text) {
        Dictionary<char, int> count = [];
        foreach (char c in text)
        {
            if (!"balon".Contains(c))   continue;
            count.TryAdd(c, 0);
            count[c]++;
        }
        int res = int.MaxValue;
        foreach (char c in "balon")
        {
            if (!count.ContainsKey(c))  return 0;
            if (c == 'l' || c == 'o')
            {
                count[c] /= 2;
            }
            res = Math.Min(res, count[c]);
        }        
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string text = "nlaebolko";
        Debug.Assert(sol.MaxNumberOfBalloons(text) == 1);

        text = "loonbalxballpoon";
        Debug.Assert(sol.MaxNumberOfBalloons(text) == 2);

        text = "leetcode";
        Debug.Assert(sol.MaxNumberOfBalloons(text) == 0);

        Console.WriteLine("passed");
    }
}
