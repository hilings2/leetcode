using System.Diagnostics;
using System.Text;

public class Solution {
    public string Evaluate(string s, IList<IList<string>> knowledge) {
        Dictionary<string, string> dict = [];
        foreach (IList<string> pair in knowledge) {
            dict[pair[0]] = pair[1];
        }
        StringBuilder res = new StringBuilder();
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == '(') {
                int j = i + 1;
                while (j < s.Length && s[j] != ')') j++;
                string key = s.Substring(i + 1, j - i - 1);
                res.Append(dict.TryGetValue(key, out string? value) ? value : "?");
                i = j;
            } else {
                res.Append(s[i]);
            }
        }
        return res.ToString();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "(name)is(age)yearsold";
        IList<IList<string>> knowledge = [["name", "bob"], ["age", "two"]];
        Debug.Assert(sol.Evaluate(s, knowledge) == "bobistwoyearsold");

        s = "hi(name)";
        knowledge = [["a", "b"]];
        Debug.Assert(sol.Evaluate(s, knowledge) == "hi?");

        s = "(a)(a)(a)aaa";
        knowledge = [["a", "yes"]];
        Debug.Assert(sol.Evaluate(s, knowledge) == "yesyesyesaaa");

        s = "(a)(b)";
        knowledge = [["a", "b"], ["b", "a"]];
        Debug.Assert(sol.Evaluate(s, knowledge) == "ba");

        Console.WriteLine("passed");
    }
}
