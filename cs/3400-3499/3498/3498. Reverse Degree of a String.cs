using System.Diagnostics;

public class Solution {
    public int ReverseDegree(string s) {
        int res = 0;
        for (int i = 0; i < s.Length; i++) {
            res += (26 - (s[i] - 'a')) * (i + 1);
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "abc";
        Debug.Assert(sol.ReverseDegree(s) == 148);

        s = "zaza";
        Debug.Assert(sol.ReverseDegree(s) == 160);

        Console.WriteLine("passed");
    }
}
