using System.Diagnostics;

public class Solution {
    public IList<int> PancakeSort(int[] arr) {
        int[] copy = (int[])arr.Clone();
        List<int> res = [];
        for (int i = arr.Length; i > 1; i--)
        {
            int k = FindMaxIndex(copy, i) + 1;
            if (k == i) continue;
            if (k > 1)  res.Add(k);
            Array.Reverse(copy, 0, k);
            res.Add(i);
            Array.Reverse(copy, 0, i);
        }
        return res;
    }

    private static int FindMaxIndex(int[] arr, int n) {
        int k = 0;
        for (int i = 1; i < n; i++) {
            if (arr[i] > arr[k])    k = i;
        }
        return k;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] arr = [3, 2, 4, 1];
        Debug.Assert(IsSorted(Apply(arr, sol.PancakeSort(arr))));

        arr = [1, 2, 3];
        Debug.Assert(IsSorted(Apply(arr, sol.PancakeSort(arr))));

        Console.WriteLine("passed");
    }

    static int[] Apply(int[] arr, IList<int> flips) {
        int[] a = (int[])arr.Clone();
        foreach (int k in flips) {
            for (int i = 0, j = k - 1; i < j; i++, j--) {
                (a[i], a[j]) = (a[j], a[i]);
            }
        }
        return a;
    }

    static bool IsSorted(int[] arr) {
        for (int i = 1; i < arr.Length; i++) {
            if (arr[i - 1] > arr[i]) return false;
        }
        return true;
    }
}
