using System.Diagnostics;

public class Solution {
    public string SmallestSubsequence(string s) {
        bool[] visited = new bool[26];
        int[] lastIndex = new int[26];
        List<char> res = [];
        for (int i = 0; i < s.Length; i++)
        {
            lastIndex[s[i] - 'a'] = i;
        }
        for (int i = 0; i < s.Length; i++)
        {
            if (visited[s[i] - 'a']) continue;
            while (res.Count > 0 && s[i] < res[^1] && i < lastIndex[res[^1] - 'a'])
            {
                visited[res[^1] - 'a'] = false;
                res.RemoveAt(res.Count - 1);
            }
            res.Add(s[i]);
            visited[s[i] - 'a'] = true;
        }
        return new string(res.ToArray());
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "bcabc";
        Debug.Assert(sol.SmallestSubsequence(s) == "abc");

        s = "cbacdcbc";
        Debug.Assert(sol.SmallestSubsequence(s) == "acdb");

        Console.WriteLine("passed");
    }
}
