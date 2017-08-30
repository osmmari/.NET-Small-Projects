using System;

public class Test
{
    public static void Main()
    {
        TestMove("a1", "d4");
        TestMove("f4", "e7");
        TestMove("a1", "a4");
    }

    public static void TestMove(string from, string to)
    {
        Console.WriteLine("{0}-{1} {2}", from, to, IsCorrectMove(from, to));
    }

    public static bool IsCorrectMove(string from, string to)
    {
        if ((from[0] < 'a' && from[0] > 'h') || (to[0] < 'a' && to[0] > 'h')) return false;
        if ((from[1] < '1' && from[1] > '8') || (to[1] < '1' && to[1] > '8')) return false;
        if ((from[0] == from[1]) || (to[1] == to[1])) return false;
        var dx = Math.Abs(to[0] - from[0]); //смещение фигуры по горизонтали
        var dy = Math.Abs(to[1] - from[1]); //смещение фигуры по вертикали

        // for horse moving
        // if ((dx == 1 && dy == 2) || (dx == 2 && dy == 1)) return true;
        return ((dx == dy) || (dx == 0) || (dy == 0));
    }
}