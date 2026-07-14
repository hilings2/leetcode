using System.Diagnostics;

public class Solution {
    public IList<int> SequentialDigits(int low, int high) {
        List<int> result = [];
        int lowDigits = NumberOfDigits(low), highDigits = NumberOfDigits(high);
        for (int digits = lowDigits; digits <= highDigits; digits++) {
            for (int start = 1; start <= 10 - digits; start++) {
                int num = 0;
                for (int i = 0; i < digits; i++) {
                    num = num * 10 + (start + i);
                }
                if (num >= low && num <= high) {
                    result.Add(num);
                }
            }
        }
        return result;
    }

    private static int NumberOfDigits(int n) {
        int count = 0;
        while (n > 0) {
            count++;
            n /= 10;
        }
        return count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        int low = 100, high = 300;
        Debug.Assert(sol.SequentialDigits(low, high).SequenceEqual([123, 234]));

        low = 1000; high = 13000;
        Debug.Assert(sol.SequentialDigits(low, high).SequenceEqual([1234, 2345, 3456, 4567, 5678, 6789, 12345]));

        Console.WriteLine("passed");
    }
}
