using System.Diagnostics;

public class Solution
{
    public int NumRescueBoats0(int[] people, int limit)
    {
        Dictionary<int, int> dict = new();
        foreach (int p in people)
        {
            if (dict.ContainsKey(p))
            {
                dict[p]++;
            }
            else
            {
                dict[p] = 1;
            }
        }

        int[] weights = new int[dict.Keys.Count];
        dict.Keys.CopyTo(weights, 0);
        Array.Sort(weights);

        int boats = 0;
        for (int i = 0, j = weights.Length - 1; i <= j;)
        {
            if (i == j)
            {
                boats += weights[i] * 2 <= limit ? (dict[weights[i]] + 1) / 2 : dict[weights[i]];
                break;
            }

            if (weights[i] + weights[j] <= limit)
            {
                int min = Math.Min(dict[weights[i]], dict[weights[j]]);
                boats += min;

                dict[weights[i]] -= min;
                if (dict[weights[i]] == 0)
                {
                    i++;
                }
                dict[weights[j]] -= min;
                if (dict[weights[j]] == 0)
                {
                    j--;
                }
            }
            else
            {
                boats += dict[weights[j]];
                j--;
            }
        }
        return boats;
    }

    public int NumRescueBoats(int[] people, int limit)
    {
        SortedList<int, int> sl = new();
        foreach (int weight in people)
        {
            if (sl.ContainsKey(weight))
            {
                sl[weight]++;
            }
            else
            {
                sl.Add(weight, 1);
            }
        }

        int boats = 0;
        for (int i = 0, j = sl.Keys.Count - 1; i <= j;)
        {
            if (i == j)
            {
                boats += sl.Keys[i] * 2 <= limit ? (sl[sl.Keys[i]] + 1) / 2 : sl[sl.Keys[i]];
                break;
            }

            if (sl.Keys[i] + sl.Keys[j] <= limit)
            {
                int min = Math.Min(sl[sl.Keys[i]], sl[sl.Keys[j]]);
                boats += min;

                sl[sl.Keys[i]] -= min;
                if (sl[sl.Keys[i]] == 0)
                {
                    i++;
                }
                sl[sl.Keys[j]] -= min;
                if (sl[sl.Keys[j]] == 0)
                {
                    j--;
                }
            }
            else
            {
                boats += sl[sl.Keys[j]];
                j--;
            }
        }
        return boats;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[] people = [1, 2];
        int limit = 3;
        Debug.Assert(sol.NumRescueBoats(people, limit) == 1);

        people = [3, 2, 2, 1];
        limit = 3;
        Debug.Assert(sol.NumRescueBoats(people, limit) == 3);

        people = [3, 5, 3, 4];
        limit = 5;
        Debug.Assert(sol.NumRescueBoats(people, limit) == 4);

        people = [2, 2];
        limit = 6;
        Debug.Assert(sol.NumRescueBoats(people, limit) == 1);
    }
}
