using System.Diagnostics;

public class Solution {
    public int[] DiStringMatch(string s) {
        int left = 0, right = s.Length;
        int[] ans = new int[s.Length + 1];
        for (int i = 0; i < s.Length; i++) {
            if (s[i] == 'I') {
                ans[i] = left++;
            } else {
                ans[i] = right--;
            }
        }
        ans[s.Length] = left;
        return ans;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "IDID";
        Debug.Assert(sol.DiStringMatch(s).SequenceEqual([0, 4, 1, 3, 2]));

        s = "III";
        Debug.Assert(sol.DiStringMatch(s).SequenceEqual([0, 1, 2, 3]));

        s = "DDI";
        Debug.Assert(sol.DiStringMatch(s).SequenceEqual([3, 2, 0, 1]));

        Console.WriteLine("passed");
    }
}
