using System.Diagnostics;

public class Solution {
    public string ReverseOnlyLetters(string s) {
        char[] arr = s.ToCharArray();
        for (int i = 0, j = arr.Length-1; i < j; i++, j--)
        {
            while (i < j && !char.IsLetter(arr[i]))
            {
                i++;
            }
            while (i < j && !char.IsLetter(arr[j]))
            {
                j--;
            }
            (arr[i], arr[j]) = (arr[j], arr[i]);
        }
        return new string(arr);
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string s = "ab-cd";
        Debug.Assert(sol.ReverseOnlyLetters(s) == "dc-ba");

        s = "a-bC-dEf-ghIj";
        Debug.Assert(sol.ReverseOnlyLetters(s) == "j-Ih-gfE-dCba");

        s = "Test1ng-Leet=code-Q!";
        Debug.Assert(sol.ReverseOnlyLetters(s) == "Qedo1ct-eeLg=ntse-T!");

        Console.WriteLine("passed");
    }
}
