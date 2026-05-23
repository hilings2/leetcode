using System.Diagnostics;

public class Solution
{
    public int SuperpalindromesInRange(string left, string right)
    {
        List<long> superPalindromes = [1, 2, 3, 4, 5, 6, 7, 8, 9];
        for (int i = 1; i < 10000; i++)
        {
            string l = i.ToString();
            string r = Reverse(l);
            superPalindromes.Add(long.Parse(l + r));
            for (int j = 0; j < 10; j++)
            {
                superPalindromes.Add(long.Parse(l + j + r));
            }
        }
        long l_left = long.Parse(left), l_right = long.Parse(right);
        int res = 0;
        foreach (long sp in superPalindromes)
        {
            long sq = sp * sp;
            if (sq < l_left || sq > l_right)
                continue;
            if (IsPalindrome(sq.ToString()))
                res++;
        }
        return res;
    }
    private static string Reverse(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Reverse(arr);
        return new string(arr);
    }
    private static bool IsPalindrome(string s)
    {
        for (int i = 0, j = s.Length - 1; i < j; i++, j--)
        {
            if (s[i] != s[j]) return false;
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        string left = "4", right = "1000";
        Debug.Assert(sol.SuperpalindromesInRange(left, right) == 4);

        left = "1"; right = "2";
        Debug.Assert(sol.SuperpalindromesInRange(left, right) == 1);

        Console.WriteLine("passed");
    }
}
