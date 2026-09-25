---
name: leetcode-cs-setup
description: Set up a C# source file and executable test harness from a LeetCode problem URL. Use when the user asks to scaffold or set up a LeetCode problem in this repository.
argument-hint: "<LeetCode problem URL>"
user-invocable: true
disable-model-invocation: true
---

# Set Up a LeetCode C# Problem

When the user provides a LeetCode problem URL:

1. Fetch the problem page and extract:
   - Problem number, for example `839`
   - Problem title, for example `Similar String Groups`
   - Method signature and parameter types
   - Test cases with expected outputs

2. Create the folder and source file:
   - Use the path `cs/<range>/<number>/<number>. <Title>.cs`.
   - Use the 100-problem range folder for `<range>`, for example `800-899` for problem 839.
   - For example: `cs/800-899/839/839. Similar String Groups.cs`.

3. Follow these C# style conventions:
   - Add `using System.Diagnostics;` at the top.
   - Create a `Solution` class with the method stub returning a default value, such as `return 0;`.
   - Create a `Program` class with `static void Main(string[] args)`.
   - Use explicit types with target-typed `new()`, such as `Solution sol = new();`.
   - Use collection expressions for arrays, such as `["tars", "rats", "arts", "star"]`.
   - Define named variables for solution arguments that match the parameter names, such as `string[] strs = [...]`.
   - Reuse each variable for subsequent test cases, such as `strs = [...]`.
   - Use `Debug.Assert(sol.MethodName(args) == expected);` for assertions.
   - Add an empty line between test case blocks.
   - Add an empty line before the final `Console.WriteLine("passed");`.

4. Use this output structure:

```csharp
using System.Diagnostics;

public class Solution {
    public int NumSimilarGroups(string[] strs) {
        return 0;
    }
}

class Program {
    static void Main(string[] args) {
        Solution sol = new();

        string[] strs = ["tars", "rats", "arts", "star"];
        Debug.Assert(sol.NumSimilarGroups(strs) == 2);

        strs = ["omv", "ovm"];
        Debug.Assert(sol.NumSimilarGroups(strs) == 1);

        Console.WriteLine("passed");
    }
}
```
