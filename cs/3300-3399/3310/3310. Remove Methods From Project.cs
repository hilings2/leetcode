using System.Diagnostics;

public class Solution {
    public IList<int> RemainingMethods(int n, int k, int[][] invocations) {
        Dictionary<int, List<int>> callerToCallees = [];
        foreach (int[] invocation in invocations) {
            (int caller, int callee) = (invocation[0], invocation[1]);
            if (!callerToCallees.TryGetValue(caller, out List<int>? callees)) {
                callees = [];
                callerToCallees[caller] = callees;
            }
            callees.Add(callee);
        }
        bool[] suspicious = new bool[n];
        suspicious[k] = true;
        Queue<int> queue = new();
        queue.Enqueue(k);
        while (queue.Count > 0) {
            int current = queue.Dequeue();
            if (callerToCallees.TryGetValue(current, out List<int>? callees)) {
                foreach (int callee in callees) {
                    if (suspicious[callee]) {
                        continue;
                    }
                    suspicious[callee] = true;
                    queue.Enqueue(callee);
                }
            }
        }
        foreach (int[] invocation in invocations) {
            (int caller, int callee) = (invocation[0], invocation[1]);
            if (!suspicious[caller] && suspicious[callee]) {
                return Enumerable.Range(0, n).ToArray();
            }            
        }
        return Enumerable.Range(0, n).Where(i => !suspicious[i]).ToArray();
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int n = 4;
        int k = 1;
        int[][] invocations = [[1, 2], [0, 1], [3, 2]];
        Debug.Assert(sol.RemainingMethods(n, k, invocations).Order().SequenceEqual([0, 1, 2, 3]));

        n = 5;
        k = 0;
        invocations = [[1, 2], [0, 2], [0, 1], [3, 4]];
        Debug.Assert(sol.RemainingMethods(n, k, invocations).Order().SequenceEqual([3, 4]));

        n = 3;
        k = 2;
        invocations = [[1, 2], [0, 1], [2, 0]];
        Debug.Assert(sol.RemainingMethods(n, k, invocations).SequenceEqual([]));

        Console.WriteLine("passed");
    }
}