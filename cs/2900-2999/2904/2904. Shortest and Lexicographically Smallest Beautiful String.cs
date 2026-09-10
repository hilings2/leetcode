using System.Diagnostics;

public class Solution {
    public string ShortestBeautifulSubstring(string s, int k) {
        string res = "";
        for (int i = 0, j = 0, count1 = 0; j < s.Length; j++) {
            if (s[j] == '1') count1++;
            while (i <= j && s[i] == '0') i++;
            if (count1 < k) continue;

            string candidate = s.Substring(i, j - i + 1);
            if (res == "" || candidate.Length < res.Length
                || (candidate.Length == res.Length && string.Compare(candidate, res) < 0)) {
                res = candidate;
            }
            count1--;
            i++;
        }
        return res;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "100011001";
        int k = 3;
        Debug.Assert(sol.ShortestBeautifulSubstring(s, k) == "11001");

        s = "1011";
        k = 2;
        Debug.Assert(sol.ShortestBeautifulSubstring(s, k) == "11");

        s = "000";
        k = 1;
        Debug.Assert(sol.ShortestBeautifulSubstring(s, k) == "");

        Console.WriteLine("passed");
    }
}