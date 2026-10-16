using System.Diagnostics;

public class Solution {
    public IList<string> GenerateParenthesis(int n) {
        List<string> res = [];
        Backtrack(res, "", 0, 0, n);
        return res;
    }

    private static void Backtrack(List<string> res, string current, int open, int close, int n) {
        if (current.Length == 2 * n) {
            res.Add(current);
            return;
        }
        if (open < n) {
            Backtrack(res, current + "(", open + 1, close, n);
        }
        if (close < open) {
            Backtrack(res, current + ")", open, close + 1, n);
        }
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 3;
        Debug.Assert(sol.GenerateParenthesis(n).SequenceEqual(["((()))", "(()())", "(())()", "()(())", "()()()"]));

        n = 1;
        Debug.Assert(sol.GenerateParenthesis(n).SequenceEqual(["()"]));

        Console.WriteLine("passed");
    }
}
