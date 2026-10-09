using System.Diagnostics;

public class Solution {
    public IList<string> BraceExpansionII(string expression) {
        int index = 0;
        HashSet<string> expanded = Parse(expression, ref index);
        return expanded.Order().ToList();
    }

    private HashSet<string> Parse(string expression, ref int index) {
        HashSet<string> result = [];
        HashSet<string> term = [""];

        while (index < expression.Length && expression[index] != '}') {
            if (expression[index] == ',') {
                result.UnionWith(term);
                term = [""];
                index++;
                continue;
            }

            if (expression[index] == '{') {
                index++;
                HashSet<string> factor = Parse(expression, ref index);
                if (index < expression.Length && expression[index] == '}') {
                    index++;
                }
                term = term
                    .SelectMany(left => factor.Select(right => left + right))
                    .ToHashSet();
                continue;
            }

            string letter = expression[index].ToString();
            index++;
            term = term.Select(value => value + letter).ToHashSet();
        }

        result.UnionWith(term);
        return result;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string expression = "{a,b}{c,{d,e}}";
        Debug.Assert(sol.BraceExpansionII(expression).SequenceEqual(["ac", "ad", "ae", "bc", "bd", "be"]));

        expression = "{{a,z},a{b,c},{ab,z}}";
        Debug.Assert(sol.BraceExpansionII(expression).SequenceEqual(["a", "ab", "ac", "z"]));

        Console.WriteLine("passed");
    }
}
