using System.Diagnostics;
using System.Text;

public class Solution {
    public string ReverseParentheses(string s) {
        int[] pair = new int[s.Length];
        Stack<int> stack = new();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                stack.Push(i);
            } else if (s[i] == ')') {
                int open = stack.Pop();
                pair[open] = i;
                pair[i] = open;
            }
        }
        StringBuilder sb = new();
        for (int i = 0, d = 1; i < s.Length; i += d) {
            if (s[i] == '(' || s[i] == ')') {
                i = pair[i];
                d = -d;
            } else {
                sb.Append(s[i]);
            }
        }
        return sb.ToString();
    }
    
    public string ReverseParentheses0(string s) {
        Stack<char> stack = new();
        StringBuilder sb = new();
        foreach (char c in s) {
            if (c == '(')  {
                stack.Push(c);
            } else if (c == ')') {
                StringBuilder temp = new();
                while (stack.Count > 0 && stack.Peek() != '(') {
                    temp.Append(stack.Pop());
                }
                if (stack.Count > 0 && stack.Peek() == '(') {
                    stack.Pop();
                }
                if (stack.Count == 0) {
                    sb.Append(temp);
                } else {
                    foreach (char ch in temp.ToString()) {
                        stack.Push(ch);
                    }
                }
            } else if (stack.Count == 0) {
                sb.Append(c);
            } else {
                stack.Push(c);
            }
        }
        return sb.ToString();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "(abcd)";
        Debug.Assert(sol.ReverseParentheses(s) == "dcba");

        s = "(u(love)i)";
        Debug.Assert(sol.ReverseParentheses(s) == "iloveu");

        s = "(ed(et(oc))el)";
        Debug.Assert(sol.ReverseParentheses(s) == "leetcode");

        s = "a(bcdefghijkl(mno)p)q";
        Debug.Assert(sol.ReverseParentheses(s) == "apmnolkjihgfedcbq");

        Console.WriteLine("passed");
    }
}
