using System.Diagnostics;

public class Solution {
    private string s = "";
    private int pos = 0;
    private readonly Dictionary<string, int> evalMap = [];

    private static Dictionary<string, int> Add(Dictionary<string, int> a, Dictionary<string, int> b) {
        Dictionary<string, int> res = new(a);
        foreach ((string k, int v) in b) {
            if (!res.ContainsKey(k)) res[k] = 0;
            res[k] += v;
            if (res[k] == 0) res.Remove(k);
        }
        return res;
    }

    private static Dictionary<string, int> Subtract(Dictionary<string, int> a, Dictionary<string, int> b) {
        Dictionary<string, int> res = new(a);
        foreach ((string k, int v) in b) {
            if (!res.ContainsKey(k)) res[k] = 0;
            res[k] -= v;
            if (res[k] == 0) res.Remove(k);
        }
        return res;
    }

    private static Dictionary<string, int> Multiply(Dictionary<string, int> a, Dictionary<string, int> b) {
        Dictionary<string, int> res = [];
        foreach ((string k1, int v1) in a) {
            foreach ((string k2, int v2) in b) {
                string[] keys = (k1 + "*" + k2).Split('*', StringSplitOptions.RemoveEmptyEntries)
                    .OrderBy(x => x, StringComparer.Ordinal).ToArray();
                string key = string.Join("*", keys);
                
                if (!res.ContainsKey(key)) res[key] = 0;
                res[key] += v1 * v2;
                if (res[key] == 0) res.Remove(key);
            }
        }
        return res;
    }

    private static Dictionary<string, int> Constant(int n) {
        if (n == 0) return [];
        return new Dictionary<string, int> { [""] = n };
    }

    private Dictionary<string, int> Variable(string name) {
        if (evalMap.TryGetValue(name, out int value)) {
            return Constant(value);
        }
        return new Dictionary<string, int> { [name] = 1 };
    }

    private Dictionary<string, int> ParseFactor() {
        if (s[pos] == '(')
        {
            pos++; // consume '('
            Dictionary<string, int> res = ParseExpression();
            pos++; // consume ')'
            return res;
        }
        if (char.IsDigit(s[pos]))
        {
            int start = pos;
            while (pos < s.Length && char.IsDigit(s[pos])) pos++;
            int value = int.Parse(s[start..pos]);
            return Constant(value);
        }
        int startVar = pos;
        while (pos < s.Length && char.IsLetter(s[pos])) pos++;
        string name = s[startVar..pos];
        return Variable(name);
    }

    private Dictionary<string, int> ParseTerm() {
        Dictionary<string, int> res = ParseFactor();
        while (pos < s.Length && s[pos] == '*') {
            pos++; // consume '*'
            Dictionary<string, int> nextFactor = ParseFactor();
            res = Multiply(res, nextFactor);
        }
        return res;
    }

    private Dictionary<string, int> ParseExpression() {
        Dictionary<string, int> res = ParseTerm();
        while (pos < s.Length && (s[pos] == '+' || s[pos] == '-')) {
            char op = s[pos];
            pos++; // consume operator
            Dictionary<string, int> nextTerm = ParseTerm();
            if (op == '+') {
                res = Add(res, nextTerm);
            } else {
                res = Subtract(res, nextTerm);
            }
        }
        return res;
    }

    private static int Degree(string key) {
        return key.Split('*', StringSplitOptions.RemoveEmptyEntries).Length;
    }

    public IList<string> BasicCalculatorIV(string expression, string[] evalvars, int[] evalints) {
        s = expression.Replace(" ", "");
        pos = 0;
        evalMap.Clear();
        for (int i = 0; i < evalvars.Length; i++) {
            evalMap[evalvars[i]] = evalints[i];
        }
        Dictionary<string, int> result = ParseExpression();
        return result.OrderByDescending(kv => Degree(kv.Key))
              .ThenBy(kv => kv.Key, StringComparer.Ordinal)
              .Select(kv => kv.Value + (kv.Key == "" ? "" : "*" + kv.Key))
              .ToList();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string expression = "e + 8 - a + 5";
        string[] evalvars = ["e"];
        int[] evalints = [1];
        Debug.Assert(sol.BasicCalculatorIV(expression, evalvars, evalints).SequenceEqual(["-1*a", "14"]));

        expression = "e - 8 + temperature - pressure";
        evalvars = ["e", "temperature"];
        evalints = [1, 12];
        Debug.Assert(sol.BasicCalculatorIV(expression, evalvars, evalints).SequenceEqual(["-1*pressure", "5"]));

        expression = "(e + 8) * (e - 8)";
        evalvars = [];
        evalints = [];
        Debug.Assert(sol.BasicCalculatorIV(expression, evalvars, evalints).SequenceEqual(["1*e*e", "-64"]));

        Console.WriteLine("passed");
    }
}