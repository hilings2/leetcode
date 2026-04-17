---
name: refactor-cs
description: 'Refactor a C# LeetCode solution file to modern style. Use when: removing namespace wrappers, extracting Main into class Program, replacing Console.WriteLine with Debug.Assert, adding using System.Diagnostics, converting array/collection initializers to collection expressions, deleting .csproj or App.config files, or renaming a problem folder to its number only.'
argument-hint: 'Path to the .cs file to refactor (e.g. cs/800-899/883.cs)'
---

# Refactor C# LeetCode Solution

Refactor a C# solution file to modern, minimal top-level style. Apply all rules below in a single edit pass.

## Rules

### 1. Remove the namespace wrapper
Remove `namespace Xxx { ... }` and un-indent all enclosed content by one level.

Before:
```csharp
namespace _883.Projection_Area_of_3D_Shapes
{
    public class Solution { ... }
}
```
After:
```csharp
public class Solution { ... }
```

---

### 2. Extract `static void Main` into a separate `class Program`
Move `static void Main(string[] args)` out of `Solution` and into a new top-level `class Program`. The method must not remain inside `Solution`.

Before:
```csharp
public class Solution
{
    public int Foo() { ... }

    static void Main(string[] args)
    {
        Solution sol = new Solution();
        ...
    }
}
```
After:
```csharp
public class Solution
{
    public int Foo() { ... }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();
        ...
    }
}
```

---

### 3. Replace usings with `using System.Diagnostics;`
Remove all `using` directives that are implicit global usings in modern .NET SDK projects (`System`, `System.Collections.Generic`, `System.Linq`, `System.Text`, `System.Threading.Tasks`, etc.).
Add `using System.Diagnostics;` at the top if it is not already present.
Keep any `using` that is genuinely required by the solution logic and is NOT a global using.

---

### 4. Replace `Console.WriteLine` with `Debug.Assert` in `Main` only
Replace verification calls **in the `Main` method** with `Debug.Assert` that compares the return value against the expected value shown in the comment.
**Keep all `Console.WriteLine` calls inside `Solution` methods** — they are useful for debugging and must not be removed.

Before:
```csharp
int r = sol.ReachableNodes(edges, maxMoves, n);    // 13
Console.WriteLine(r);
Console.WriteLine();
```
After:
```csharp
Debug.Assert(sol.ReachableNodes(edges, maxMoves, n) == 13);
```

- Read the expected value from the trailing comment (e.g. `// 13`).
- For array results use `.SequenceEqual(...)`:
  ```csharp
  Debug.Assert(sol.UncommonFromSentences(s1, s2).SequenceEqual(new[] { "sweet", "sour" }));
  ```
- Remove bare `Console.WriteLine()` blank-line separators in `Main`.
- Do **not** touch `Console.WriteLine` inside `Solution` class methods.

---

### 5. Use collection expressions for data initialization
Replace verbose array/collection initialization with C# 12 collection expression syntax.

Before:
```csharp
int[] people = new int[] { 1, 2 };

int[][] edges = new int[][]
{
    new int[] { 0, 1, 10 },
    new int[] { 0, 2, 1 }
};

List<int> list = new List<int> { 1, 2, 3 };
```
After:
```csharp
int[] people = [1, 2];

int[][] edges =
[
    [0, 1, 10],
    [0, 2, 1]
];

List<int> list = [1, 2, 3];
```

Also replace `new Solution()` → `new()` and other explicit constructor calls where the type can be inferred from the variable declaration.

---

### 6. Delete `.csproj` and `App.config` files
Delete any `.csproj` and `App.config` files found inside the problem folder. These are not needed for the single-file `dotnet run` workflow used in this repo.

Use the terminal to remove them (substitute the actual folder name at runtime):
```powershell
Remove-Item '.\<folder>\*.csproj'
Remove-Item '.\<folder>\App.config' -ErrorAction SilentlyContinue
```

---

### 7. Rename the problem folder to the problem number only
Rename the folder from `"<number>. <Title>"` to just `"<number>"`. Leave the `.cs` file inside unchanged — do **not** rename it.

Examples:
```
882. Reachable Nodes In Subdivided Graph/  →  882/
883. Projection Area of 3D Shapes/         →  883/
```

Use `Rename-Item` in the terminal (substitute the actual folder name and number at runtime):
```powershell
Rename-Item '.\<number>. <Title>' '<number>'
```

> After renaming, verify `dotnet run` still works from the new folder path.

---

## Complete Example

**Before:**
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _883.Projection_Area_of_3D_Shapes
{
    public class Solution
    {
        public int ProjectionArea(int[][] grid)
        {
            int n = grid.Length;
            int xy = 0, xz = 0, yz = 0;
            for (int i = 0; i < n; i++)
            {
                int maxZperX = 0, maxZperY = 0;
                for (int j = 0; j < n; j++)
                {
                    if (grid[i][j] > 0) xy++;
                    maxZperX = Math.Max(maxZperX, grid[i][j]);
                    maxZperY = Math.Max(maxZperY, grid[j][i]);
                }
                xz += maxZperX;
                yz += maxZperY;
            }
            return xy + xz + yz;
        }

        static void Main(string[] args)
        {
            Solution sol = new Solution();
            int[][] grid = new int[][]
            {
                new int[] { 1, 2 },
                new int[] { 3, 4 }
            };
            Console.WriteLine(sol.ProjectionArea(grid));   // 17
            Console.WriteLine();

            grid = new int[][]
            {
                new int[] { 2 }
            };
            Console.WriteLine(sol.ProjectionArea(grid));   // 5
            Console.WriteLine();

            grid = new int[][]
            {
                new int[] { 1, 0 },
                new int[] { 0, 2 }
            };
            Console.WriteLine(sol.ProjectionArea(grid));   // 8
            Console.WriteLine();
        }
    }
}
```

**After:**
```csharp
using System.Diagnostics;

public class Solution
{
    public int ProjectionArea(int[][] grid)
    {
        int n = grid.Length;
        int xy = 0, xz = 0, yz = 0;
        for (int i = 0; i < n; i++)
        {
            int maxZperX = 0, maxZperY = 0;
            for (int j = 0; j < n; j++)
            {
                if (grid[i][j] > 0) xy++;
                maxZperX = Math.Max(maxZperX, grid[i][j]);
                maxZperY = Math.Max(maxZperY, grid[j][i]);
            }
            xz += maxZperX;
            yz += maxZperY;
        }
        return xy + xz + yz;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new();

        int[][] grid =
        [
            [1, 2],
            [3, 4]
        ];
        Debug.Assert(sol.ProjectionArea(grid) == 17);

        grid = [[2]];
        Debug.Assert(sol.ProjectionArea(grid) == 5);

        grid =
        [
            [1, 0],
            [0, 2]
        ];
        Debug.Assert(sol.ProjectionArea(grid) == 8);
    }
}
```
