using System.Diagnostics;

public class StockSpanner {
    private readonly Stack<(int price, int span)> _stack = new();
    
    public StockSpanner() {
    }
    
    public int Next(int price) {
        int span = 1;
        while (_stack.Count > 0 && _stack.Peek().price <= price)
        {
            span += _stack.Pop().span;
        }
        _stack.Push((price, span));
        return span;
    }
}

/**
 * Your StockSpanner object will be instantiated and called as such:
 * StockSpanner obj = new StockSpanner();
 * int param_1 = obj.Next(price);
 */

 class Program
{
    static void Main()
    {
        Console.WriteLine("LeetCode 901 Online Stock Span, C# ...");

        StockSpanner stockSpanner = new();
        Debug.Assert(stockSpanner.Next(100) == 1);
        Debug.Assert(stockSpanner.Next(80) == 1);
        Debug.Assert(stockSpanner.Next(60) == 1);
        Debug.Assert(stockSpanner.Next(70) == 2);
        Debug.Assert(stockSpanner.Next(60) == 1);
        Debug.Assert(stockSpanner.Next(75) == 4);
        Debug.Assert(stockSpanner.Next(85) == 6);    
    }
}