using System.Diagnostics;

public class Solution {
    public int TotalWaviness(int num1, int num2) {
        int res = 0;
        for (int i = Math.Max(101, num1); i <= num2; i++) {
            res += Waviness(i);
        }
        return res;
    }
    private static int Waviness(int num) {
        List<int> digits = IntToDigitArray(num);
        int waviness = 0;
        for (int i = 1; i < digits.Count - 1; i++) {
            if ((digits[i] > digits[i - 1] && digits[i] > digits[i + 1]) ||
                (digits[i] < digits[i - 1] && digits[i] < digits[i + 1])) {
                waviness++;
            }
        }
        return waviness;
    }
    private static List<int> IntToDigitArray(int num) {
        List<int> digits = new();
        while (num > 0) {
            digits.Add(num % 10);
            num /= 10;
        }
        // digits.Reverse();
        return digits;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        Debug.Assert(sol.TotalWaviness(120, 130) == 3);

        Debug.Assert(sol.TotalWaviness(198, 202) == 3);

        Debug.Assert(sol.TotalWaviness(4848, 4848) == 2);

        Console.WriteLine("passed");
    }
}
