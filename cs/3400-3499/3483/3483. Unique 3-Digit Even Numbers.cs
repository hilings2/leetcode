using System.Diagnostics;

public class Solution {
    public int TotalNumbers(int[] digits) {
        int[] count = new int[10];
        foreach (int digit in digits) count[digit]++;
        int res = 0;
        for (int i = 1; i <= 9; i++) {
            if (count[i] == 0) continue;
            count[i]--;
            for (int j = 0; j <= 9; j++) {
                if (count[j] == 0) continue;
                count[j]--;
                for (int k = 0; k <= 8; k += 2) {
                    if (count[k] == 0) continue;
                    res++;
                }
                count[j]++;
            }
            count[i]++;
        }
        return res;
    }

    public int TotalNumbers0(int[] digits) {
        HashSet<int> set = [];
        for (int i = 0; i < digits.Length; i++) {
            for (int j = 0; j < digits.Length; j++) {
                if (j == i) continue;
                for (int k = 0; k < digits.Length; k++) {
                    if (k == i || k == j) continue;
                    if (digits[i] == 0 || digits[k] % 2 != 0) continue;
                    set.Add(digits[i] * 100 + digits[j] * 10 + digits[k]);
                }
            }
        }
        return set.Count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int[] digits = [1, 2, 3, 4];
        Debug.Assert(sol.TotalNumbers(digits) == 12);

        digits = [0, 2, 2];
        Debug.Assert(sol.TotalNumbers(digits) == 2);

        digits = [6, 6, 6];
        Debug.Assert(sol.TotalNumbers(digits) == 1);

        digits = [1, 3, 5];
        Debug.Assert(sol.TotalNumbers(digits) == 0);

        Console.WriteLine("passed");
    }
}