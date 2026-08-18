using System.Diagnostics;

public class Solution {
    private static readonly (int,int,int,int)[] digitFactors = [
        (0,0,0,0), // 0
        (0,0,0,0), // 1
        (1,0,0,0), // 2
        (0,1,0,0), // 3
        (2,0,0,0), // 4
        (0,0,1,0), // 5
        (1,1,0,0), // 6
        (0,0,0,1), // 7
        (3,0,0,0), // 8
        (0,2,0,0)  // 9
    ];
    private static readonly int[] contributingDigits = [2,3,4,6,8,9];
    private static readonly Dictionary<(int,int), int> memo = [];

    public string SmallestNumber(string num, long t) {
        (int e2, int e3, int e5, int e7) required = FactorBy2357(ref t); // required prime factors of t
        if (t != 1) return "-1"; // t has prime factors other than 2,3,5,7
        
        // requiredWithPrefix[i] = required prime factors after putting num[0..i-1]
        (int e2, int e3, int e5, int e7)[] requiredWithPrefix = new (int e2, int e3, int e5, int e7)[num.Length + 1];
        requiredWithPrefix[0] = required;
        int validPrefixLength = 0;
        for (int i = 0; i < num.Length; i++) {
            int digit = num[i] - '0';
            if (digit == 0) break;
            validPrefixLength++;
            requiredWithPrefix[i + 1] = ConsumeDigit(requiredWithPrefix[i], digit); // requirement after putting digit at i
        }
        if (validPrefixLength == num.Length && requiredWithPrefix[num.Length] == (0,0,0,0)) { // num is already divisible by t
            return num;
        }

        // try replacing digits in num to make it divisible by t
        int startIndex = Math.Min(num.Length - 1, validPrefixLength); // start from first zero or last digit of num
        for (int i = startIndex; i >= 0; i--) {
            int originalDigit = num[i] - '0';
            int slotsAfter = num.Length - 1 - i;
            for (int digit = originalDigit + 1; digit <= 9; digit++) {
                (int e2, int e3, int e5, int e7) remainingRequired = ConsumeDigit(requiredWithPrefix[i], digit); // requirement after putting digit at i
                if (MinimumDigits2357(remainingRequired) <= slotsAfter) {
                    char[] result = num.ToCharArray();
                    result[i] = (char)(digit + '0');
                    return FillSmallest(remainingRequired, result, i + 1);
                }
            }
        }
        
        // build shortest possible number with more digits than num
        int minimumDigits = Math.Max(MinimumDigits2357(required), num.Length + 1);
        char[] longerResult = new char[minimumDigits];
        return FillSmallest(required, longerResult, 0);
    }
    
    private static (int e2, int e3, int e5, int e7) FactorBy2357(ref long t) {
        int e2 = 0, e3 = 0, e5 = 0, e7 = 0;
        while (t % 2 == 0) { t /= 2; e2++; }
        while (t % 3 == 0) { t /= 3; e3++; }
        while (t % 5 == 0) { t /= 5; e5++; }
        while (t % 7 == 0) { t /= 7; e7++; }
        return (e2, e3, e5, e7);
    }

    private static int MinimumDigits23(int e2, int e3) {
        if (e2 == 0 && e3 == 0) return 0;
        if (memo.TryGetValue((e2, e3), out int cached)) return cached;

        int count = int.MaxValue;
        foreach(int digit in contributingDigits) {
            (int de2, int de3, _, _) = digitFactors[digit];
            int nextE2 = Math.Max(0, e2 - de2);
            int nextE3 = Math.Max(0, e3 - de3);
            if (nextE2 == e2 && nextE3 == e3) {
                continue;
            }
            count = Math.Min(count, 1 + MinimumDigits23(nextE2, nextE3));
        }
        memo[(e2, e3)] = count;
        return count;
    }

    private static int MinimumDigits2357((int e2, int e3, int e5, int e7) required) {
        return MinimumDigits23(required.e2, required.e3) + required.e5 + required.e7;
    }

    private static (int e2, int e3, int e5, int e7) ConsumeDigit(
        (int e2, int e3, int e5, int e7) required,
        int digit
    ) {
        (int de2, int de3, int de5, int de7) = digitFactors[digit];
        return (
            Math.Max(0, required.e2 - de2),
            Math.Max(0, required.e3 - de3),
            Math.Max(0, required.e5 - de5),
            Math.Max(0, required.e7 - de7));
    }

    private static string FillSmallest(
        (int e2, int e3, int e5, int e7) required,
        char[] result,
        int startIndex
    ) {
        for (int i = startIndex; i < result.Length; i++) {
            if (required == (0,0,0,0)) {
                Array.Fill(result, '1', i, result.Length - i);
                break;
            }
            int slotsAfter = result.Length - 1 - i;
            for (int digit = 1; digit <= 9; digit++) {
                (int e2, int e3, int e5, int e7) nextRequired = ConsumeDigit(required, digit);
                if (MinimumDigits2357(nextRequired) <= slotsAfter) {
                    result[i] = (char)(digit + '0');
                    required = nextRequired;
                    break;
                }
            }
        }
        return new string(result);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string num = "1234";
        long t = 256;
        Debug.Assert(sol.SmallestNumber(num, t) == "1488");

        num = "12355";
        t = 50;
        Debug.Assert(sol.SmallestNumber(num, t) == "12355");

        num = "11111";
        t = 26;
        Debug.Assert(sol.SmallestNumber(num, t) == "-1");

        Console.WriteLine("passed");
    }
}