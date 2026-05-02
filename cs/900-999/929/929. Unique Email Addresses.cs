using System.Diagnostics;

public class Solution {
    public int NumUniqueEmails(string[] emails) {
        HashSet<string> uniqueEmails = [];
        foreach (string email in emails)
        {
            string[] parts = email.Split('@');
            (string local, string domain) = (parts[0], parts[1]);
            int plusIndex = local.IndexOf('+');
            if (plusIndex != -1)
            {
                local = local.Substring(0, plusIndex);                
            }
            local = local.Replace(".", "");
            uniqueEmails.Add($"{local}@{domain}");
        }
        return uniqueEmails.Count;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] emails = ["test.email+alex@leetcode.com", "test.e.mail+bob.cathy@leetcode.com", "testemail+david@lee.tcode.com"];
        Debug.Assert(sol.NumUniqueEmails(emails) == 2);

        emails = ["a@leetcode.com", "b@leetcode.com", "c@leetcode.com"];
        Debug.Assert(sol.NumUniqueEmails(emails) == 3);

        Console.WriteLine("passed");
    }
}
