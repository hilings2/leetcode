using System.Diagnostics;

public class Solution {
    public IList<string> MaxNumOfSubstrings(string s) {
        int[] first = new int[26], last = new int[26];
        Array.Fill(first, -1);
        for (int i = 0; i < s.Length; i++) { // range for each letter
            int c = s[i] - 'a';
            if (first[c] == -1) first[c] = i;
            last[c] = i;
        }

        List<(int start, int end)> intervals = [];
        for (int c = 0; c < 26; c++) { // check if any letter has a valid interval
            int start = first[c];
            if (start != -1 && TryExpand(s, start, first, last, out int end)) {
                intervals.Add((start, end));
            }
        }
        // interval ending earlier leaves more room for subsequent intervals
        intervals.Sort((a, b) => a.end.CompareTo(b.end));

        List<string> res = [];
        int previousEnd = -1;
        foreach ((int start, int end) in intervals) { // select non-overlapping intervals
            if (start > previousEnd) {
                res.Add(s.Substring(start, end - start + 1));
                previousEnd = end;
            }
        }
        return res;
    }

    private static bool TryExpand(string s, int start, int[] first, int[] last, out int end) {
        end = last[s[start] - 'a'];
        for (int i = start; i <= end; i++) {
            int c = s[i] - 'a';
            if (first[c] < start) return false;
            end = Math.Max(end, last[c]);
        }
        return true;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "adefaddaccc";
        string[] expected = ["ccc", "e", "f"];
        Debug.Assert(sol.MaxNumOfSubstrings(s).Order().SequenceEqual(expected));

        s = "abbaccd";
        expected = ["bb", "cc", "d"];
        Debug.Assert(sol.MaxNumOfSubstrings(s).Order().SequenceEqual(expected));

        Console.WriteLine("passed");
    }
}