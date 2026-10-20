using System.Diagnostics;

public class Solution {
    public IList<string> RemoveInvalidParentheses(string s) {
        HashSet<string> res = [];
        int leftRem = 0, rightRem = 0; // Count unmatched parentheses to remove.
        foreach (char c in s) {
            if (c == '(') {
                leftRem++;
            } else if (c == ')') {
                if (leftRem > 0) {
                    leftRem--;
                } else {
                    rightRem++;
                }
            }
        }
        Backtrack(s, 0, leftRem, rightRem, 0, "", res); // DFS with backtracking
        return [.. res];
    }

    private static void Backtrack(string s, int index, int leftRem, int rightRem, int balance, string current, HashSet<string> res) {
        if (index == s.Length) { // Reached the end of the input.
            if (leftRem == 0 && rightRem == 0 && balance == 0) { // Save a valid result.
                res.Add(current);
            }
            return;
        }
        if (leftRem + rightRem > s.Length - index) { // Prune the search if not enough characters left to remove.
            return;
        }
        char c = s[index];
        if (c != '(' && c != ')') { // Always keep non-parenthesis characters.
            Backtrack(s, index + 1, leftRem, rightRem, balance, current + c, res);
            return;
        }
        if (c == '(' && leftRem > 0) { // Remove this opening parenthesis.
            Backtrack(s, index + 1, leftRem - 1, rightRem, balance, current, res);
        }
        if (c == ')' && rightRem > 0) { // Remove this closing parenthesis.
            Backtrack(s, index + 1, leftRem, rightRem - 1, balance, current, res);
        }
        if (c == '(') { // Keep this opening parenthesis.
            Backtrack(s, index + 1, leftRem, rightRem, balance + 1, current + c, res);
        }
        if (c == ')' && balance > 0) { // Keep only a matched closing parenthesis.
            Backtrack(s, index + 1, leftRem, rightRem, balance - 1, current + c, res);
        }
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "()())()";
        Debug.Assert(new HashSet<string>(sol.RemoveInvalidParentheses(s)).SetEquals(["(())()", "()()()"]));

        s = "(a)())()";
        Debug.Assert(new HashSet<string>(sol.RemoveInvalidParentheses(s)).SetEquals(["(a())()", "(a)()()"]));

        s = ")(";
        Debug.Assert(new HashSet<string>(sol.RemoveInvalidParentheses(s)).SetEquals([""]));

        Console.WriteLine("passed");
    }
}
