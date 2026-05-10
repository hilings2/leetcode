using System.Diagnostics;

public class Solution {
    public string[] ReorderLogFiles(string[] logs) {
        List<(string id, string content)> letterLogs = new();
        List<string> digitLogs = new();
        foreach (string log in logs)
        {
            string[] parts = log.Split(' ', 2);
            string id = parts[0], content = parts[1];
            if (char.IsDigit(content[0]))
            {
                digitLogs.Add(log);
            }
            else
            {
                letterLogs.Add((id, content));
            }
        }
        letterLogs.Sort((a, b) => {
            int cmp = string.CompareOrdinal(a.content, b.content);
            return cmp != 0 ? cmp : string.CompareOrdinal(a.id, b.id);            
        });
        return [.. letterLogs.Select(x => $"{x.id} {x.content}"), .. digitLogs];
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] logs = ["dig1 8 1 5 1", "let1 art can", "dig2 3 6", "let2 own kit dig", "let3 art zero"];
        Debug.Assert(sol.ReorderLogFiles(logs).SequenceEqual(["let1 art can", "let3 art zero", "let2 own kit dig", "dig1 8 1 5 1", "dig2 3 6"]));

        logs = ["a1 9 2 3 1", "g1 act car", "zo4 4 7", "ab1 off key dog", "a8 act zoo"];
        Debug.Assert(sol.ReorderLogFiles(logs).SequenceEqual(["g1 act car", "a8 act zoo", "ab1 off key dog", "a1 9 2 3 1", "zo4 4 7"]));

        Console.WriteLine("passed");
    }
}
