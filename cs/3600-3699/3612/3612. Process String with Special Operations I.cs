using System.Diagnostics;

public class Solution {
    public string ProcessStr(string s) {
        List<char> result = [];
        foreach (char c in s)
        {
            switch (c)
            {
                case '*':
                    if (result.Count > 0) result.RemoveAt(result.Count - 1);
                    break;
                case '#':
                    result.AddRange(result);
                    break;
                case '%':
                    result.Reverse();
                    break;                
                default:
                    result.Add(c);
                    break;
            }
        }
        return new string(result.ToArray());  
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "a#b%*";
        Debug.Assert(sol.ProcessStr(s) == "ba");

        s = "z*#";
        Debug.Assert(sol.ProcessStr(s) == "");

        Console.WriteLine("passed");
    }
}
