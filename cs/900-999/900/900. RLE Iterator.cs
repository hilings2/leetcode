using System;

public class RLEIterator {
    private readonly int[] _encoding;
    private int _index = 0;

    public RLEIterator(int[] encoding) {
        _encoding = encoding;
        _index = 0;
    }

    public int Next(int n) {
        int exhausted = -1;
        for (; _index < _encoding.Length && n >= _encoding[_index]; _index += 2)
        {
            if (_encoding[_index] == 0)
            {
                continue;
            }
            exhausted = _encoding[_index + 1];
            n -= _encoding[_index];
        }

        if (n == 0)
        {
            return exhausted;
        }
        else if (_index >= _encoding.Length)
        {
            return -1;
        }

        exhausted = _encoding[_index + 1];
        _encoding[_index] -= n;

        return exhausted;
    }
}

/**
 * Your RLEIterator object will be instantiated and called as such:
 * RLEIterator obj = new RLEIterator(encoding);
 * int param_1 = obj.Next(n);
 */

class Program
{
    static void Main()
    {
        Console.WriteLine("LeetCode 900 RLE Iterator, C# ...");

        RLEIterator rLEIterator = new([3, 8, 0, 9, 2, 5]);
        Console.WriteLine(rLEIterator.Next(2)); // return 8
        Console.WriteLine(rLEIterator.Next(1)); // return 8
        Console.WriteLine(rLEIterator.Next(1)); // return 5
        Console.WriteLine(rLEIterator.Next(2)); // return -1

        RLEIterator rLEIterator2 = new([
            923381015,843,
            898173122,924,
            540599925,391,
            705283400,275,
            811628709,850,
            895038968,590,
            949764874,580,
            450563107,660,
            996257840,917,
            793325084,82]);
        Console.WriteLine(rLEIterator2.Next(612783105));
        Console.WriteLine(rLEIterator2.Next(486444202));
        Console.WriteLine(rLEIterator2.Next(630147341));
        Console.WriteLine(rLEIterator2.Next(845077576));
        Console.WriteLine(rLEIterator2.Next(243035623));

        Console.WriteLine(rLEIterator2.Next(731489221));
        Console.WriteLine(rLEIterator2.Next(117134294));
        Console.WriteLine(rLEIterator2.Next(220460537));
        Console.WriteLine(rLEIterator2.Next(794582972));
        Console.WriteLine(rLEIterator2.Next(332536150));

        Console.WriteLine(rLEIterator2.Next(815913097));
        Console.WriteLine(rLEIterator2.Next(100607521));
        Console.WriteLine(rLEIterator2.Next(146358489));
        Console.WriteLine(rLEIterator2.Next(697670641));
        Console.WriteLine(rLEIterator2.Next(45234068));

        Console.WriteLine(rLEIterator2.Next(573866037));
        Console.WriteLine(rLEIterator2.Next(519323635));
        Console.WriteLine(rLEIterator2.Next(27431940));
        Console.WriteLine(rLEIterator2.Next(16279485));
        Console.WriteLine(rLEIterator2.Next(203970));
    }
}
