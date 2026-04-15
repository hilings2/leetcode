using System.Diagnostics;

public class Solution
{
    public string DecodeAtIndex0(string s, int k)
    {
        string buffer = "";
        foreach (char c in s)
        {
            if (Char.IsDigit(c))
            {
                int d = c - '0';
                if (k <= buffer.Length * d)
                {
                    return buffer[(k - 1) % buffer.Length].ToString();
                }

                string tmp = buffer;
                for (int i = 0; i < d-1; i++)
                {
                    buffer += tmp;
                }
            }
            else
            {
                buffer += c;
                if (k == buffer.Length)
                {
                    return c.ToString();
                }
            }
        }
        return buffer[k-1].ToString();
    }

    public string DecodeAtIndex(string s, int k)
    {
        int len = 0;
        for (int i = 0; i < s.Length; i++)
        {
            if (Char.IsDigit(s[i]))
            {
                int n = s[i] - '0';
                if (k <= (long)len * n)
                {
                    return DecodeAtIndex(s.Substring(0, i), (k-1) % len + 1);
                }
                len *= n;
            }
            else
            {
                len++;
                if (k == len)
                {
                    return s[i].ToString();
                }
            }
        }
        return "";
    }

    public string DecodeAtIndex2(string s, int k)
    {
        for (int i = 0, len = 0; i < s.Length; i++)
        {
            if (Char.IsDigit(s[i]))
            {
                int n = s[i] - '0';
                if (k <= (long)len * n)
                {
                    s = s.Substring(0, i);
                    k = (k - 1) % len + 1;
                    i = -1;
                    len = 0;
                    continue;
                }
                len *= n;
            }
            else
            {
                len++;
                if (k == len)
                {
                    return s[i].ToString();
                }
            }
        }
        return "";
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        string s = "leet2code3";
        int k = 10;
        Debug.Assert(sol.DecodeAtIndex(s, k) == "o");

        s = "ha22";
        k = 5;
        Debug.Assert(sol.DecodeAtIndex(s, k) == "h");

        s = "a2345678999999999999999";
        k = 1;
        Debug.Assert(sol.DecodeAtIndex(s, k) == "a");

        s = "y959q969u3hb22odq595";
        k = 222280369;
        Debug.Assert(sol.DecodeAtIndex(s, k) == "y");

        s = "ajx37nyx97niysdrzice4petvcvmcgqn282zicpbx6okybw93vhk782unctdbgmcjmbqn25rorktmu5ig2qn2y4xagtru2nehmsp";
        k = 976159153;
        Debug.Assert(sol.DecodeAtIndex2(s, k) == "a");
    }
}
