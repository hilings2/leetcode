using System.Diagnostics;

public class Solution {
    public int LongestValidParentheses(string s) {
        Stack<int> stack = new();
        stack.Push(-1);
        int res = 0;
        // treat unmatched () as boundaries for valid substrings
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                stack.Push(i);
            } else if (stack.Peek() >= 0 && s[stack.Peek()] == '(') {
                stack.Pop();
                res = Math.Max(res, i - stack.Peek()); // update length of valid substring since last boundary
            } else {
                stack.Push(i);
            }
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "(()";
        Debug.Assert(sol.LongestValidParentheses(s) == 2);

        s = ")()())";
        Debug.Assert(sol.LongestValidParentheses(s) == 4);

        s = "";
        Debug.Assert(sol.LongestValidParentheses(s) == 0);

        Console.WriteLine("passed");
    }
}
