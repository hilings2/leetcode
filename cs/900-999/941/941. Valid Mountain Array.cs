using System.Diagnostics;

public class Solution {
    public bool ValidMountainArray(int[] arr) {
        if (arr.Length < 3) return false;
        bool up = true;
        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] == arr[i-1]) return false;
            if (up)
            {
                if (arr[i] < arr[i-1])
                {
                    if (i == 1) return false;
                    up = false;
                }
            }
            else
            {
                if (arr[i] > arr[i-1]) return false;
            }
        }
        return !up;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] arr = [2, 1];
        Debug.Assert(sol.ValidMountainArray(arr) == false);

        arr = [3, 5, 5];
        Debug.Assert(sol.ValidMountainArray(arr) == false);

        arr = [0, 3, 2, 1];
        Debug.Assert(sol.ValidMountainArray(arr) == true);

        Console.WriteLine("passed");
    }
}
