using System.Diagnostics;

public class Solution
{
    public int NumSimilarGroups(string[] strs)
    {
        int[] iToG = new int[strs.Length];    // map: index => group id
        for (int i = 0, j; i < strs.Length; i++)
        {
            for (j = 0; j < i; j++)
            {
                if (!IsSimilar(strs[i], strs[j]))
                {
                    continue;
                }
                if (iToG[i] == 0)
                {
                    iToG[i] = iToG[j];
                }
                else if (iToG[j] != iToG[i])
                {
                    int oldGroupId = iToG[j];
                    for (int k = 0; k < i; k++)
                    {
                        if (iToG[k] == oldGroupId)
                        {
                            iToG[k] = iToG[i];
                        }
                    }
                }
            }
            if (iToG[i] == 0)
            {
                iToG[i] = i+1;    // use i+1 as group id
            }
        }

        return iToG.Distinct().Count();
    }

    private static bool IsSimilar(string s1, string s2)
    {
        int diff = 0;
        for (int i = 0; i < s1.Length; i++)
        {
            if (s1[i] != s2[i])
            {
                diff++;
            }
            if (diff > 2)
            {
                return false;
            }
        }
        return true;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        string[] strs = ["tars", "rats", "arts", "star"];
        Debug.Assert(sol.NumSimilarGroups(strs) == 2);

        strs = ["omv", "ovm"];
        Debug.Assert(sol.NumSimilarGroups(strs) == 1);

        strs = ["kccomwcgcs", "socgcmcwkc", "sgckwcmcoc", "coswcmcgkc", "cowkccmsgc", "cosgmccwkc", "sgmkwcccoc", "coswmccgkc", "kowcccmsgc", "kgcomwcccs"];
        Debug.Assert(sol.NumSimilarGroups(strs) == 5);

        Console.WriteLine("passed");
    }
}