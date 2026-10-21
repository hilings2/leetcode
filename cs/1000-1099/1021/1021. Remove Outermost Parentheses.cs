using System.Diagnostics;
using System.Text;

public class Solution {
    public string RemoveOuterParentheses(string s) {
        StringBuilder sb = new(s.Length);
        int depth = 0;
        foreach (char c in s) {
            if (c == '(') {
                if (depth > 0) sb.Append(c);
                depth++;
            } else {
                depth--;
                if (depth > 0) sb.Append(c);
            }
        }
        return sb.ToString();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "(()())(())";
        Debug.Assert(sol.RemoveOuterParentheses(s) == "()()()");

        s = "(()())(())(()(()))";
        Debug.Assert(sol.RemoveOuterParentheses(s) == "()()()()(())");

        s = "()()";
        Debug.Assert(sol.RemoveOuterParentheses(s) == "");

        Console.WriteLine("passed");
    }
}
