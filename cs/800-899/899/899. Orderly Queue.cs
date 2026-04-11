using System.Diagnostics;

public class Solution {
    public string OrderlyQueue(string s, int k) {
        if (k > 1)
        {
            return sortStr(s);
        }
        return minLexRotation(s);
    }

    private string sortStr(string s)
    {
        char[] arr = s.ToCharArray();
        Array.Sort(arr);
        return new string(arr);
    }

    private string minLexRotation(string s)
    {
        string minRotation = s;
        for (int i = 1; i < s.Length; i++)
        {
            string rotation = s.Substring(i) + s.Substring(0, i);
            if (string.Compare(rotation, minRotation) < 0)
            {
                minRotation = rotation;
            }
        }
        return minRotation;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();
        Debug.Assert(sol.OrderlyQueue("cba", 1) == "acb");
        Debug.Assert(sol.OrderlyQueue("baaca", 3) == "aaabc");
    }
}