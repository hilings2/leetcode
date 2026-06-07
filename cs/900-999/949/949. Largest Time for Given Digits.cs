using System.Diagnostics;

public class Solution {
    private static readonly HashSet<string> permutations = new();
    public string LargestTimeFromDigits(int[] arr) {
        permutations.Clear();
        Dfs(arr, new bool[arr.Length], "");
        string res = "";
        foreach (string s in permutations)
        {
            string hh = s[..2], mm = s.Substring(2, 2);
            if (hh.CompareTo("24") >= 0 || mm.CompareTo("60") >= 0) continue;
            string time = $"{hh}:{mm}";
            if (string.Compare(time, res) > 0)
            {
                res = time;
            }
        }
        return res;
    }
    private static void Dfs(int[] arr, bool[] used, string value)
    {
        if (value.Length == 4)
        {
            permutations.Add(value);
            return;
        }
        for (int i = 0; i < arr.Length; i++)
        {
            if (used[i]) continue;
            used[i] = true;
            Dfs(arr, used, value + arr[i]);
            used[i] = false;
        }
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] arr = [1, 2, 3, 4];
        Debug.Assert(sol.LargestTimeFromDigits(arr) == "23:41");

        arr = [5, 5, 5, 5];
        Debug.Assert(sol.LargestTimeFromDigits(arr) == "");

        Console.WriteLine("passed");
    }
}
