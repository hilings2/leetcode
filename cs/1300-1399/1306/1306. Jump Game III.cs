using System.Diagnostics;

public class Solution {
    public bool CanReach(int[] arr, int start) {
        Queue<int> q = new([start]);
        Dictionary<int, bool> visited = new() { { start, true } };
        while (q.Count > 0)
        {
            int cur = q.Dequeue();
            if (arr[cur] == 0)
                return true;
            foreach (int next in new int[] { cur + arr[cur], cur - arr[cur] })
            {
                if (next >= 0 && next < arr.Length && !visited.ContainsKey(next))
                {
                    q.Enqueue(next);
                    visited[next] = true;
                }
            }
        }
        return false;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] arr = [4, 2, 3, 0, 3, 1, 2];
        Debug.Assert(sol.CanReach(arr, 5) == true);

        arr = [4, 2, 3, 0, 3, 1, 2];
        Debug.Assert(sol.CanReach(arr, 0) == true);

        arr = [3, 0, 2, 1, 2];
        Debug.Assert(sol.CanReach(arr, 2) == false);

        Console.WriteLine("passed");
    }
}
