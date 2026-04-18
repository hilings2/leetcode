# Setup LeetCode C# Problem

When the user provides a LeetCode problem URL:

1. **Fetch the problem page** to extract:
   - Problem number (e.g. `839`)
   - Problem title (e.g. `Similar String Groups`)
   - Method signature and parameter types
   - Test cases with expected outputs

2. **Create folder and file**:
   - Path: `cs/<range>/<number>/<number>. <Title>.cs`
   - `<range>` is the 100-problem range folder, e.g. `800-899` for problem 839
   - Example: `cs/800-899/839/839. Similar String Groups.cs`

3. **File template** — use the following style conventions:
   - `using System.Diagnostics;` at the top
   - A `Solution` class with the stub method returning a default value (e.g. `return 0;`)
   - A `Program` class with `static void Main(string[] args)`
   - Use **explicit types** with **target-typed `new()`**: `Solution sol = new();`
   - Use **collection expression syntax** for arrays: `["tars", "rats", "arts", "star"]`
   - Define **named variables** for solution arguments matching the parameter name: `string[] strs = [...]`
   - Reuse the variable for subsequent test cases: `strs = [...]`
   - Use `Debug.Assert(sol.MethodName(args) == expected);` for assertions
   - Add an **empty line** between each test case block
   - Add an **empty line** before the final `Console.WriteLine("passed");`

4. **Example output**:

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
