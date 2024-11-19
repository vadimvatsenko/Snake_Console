namespace Snake_Console;

public struct Cell
{
    public int X;
    public int Y;

    public static Cell Zero => new Cell(0, 0);
    public static Cell Up => new Cell(0, -1);
    public static Cell Down => new Cell(0, 1);
    public static Cell Right => new Cell(1, 0);
    public static Cell Left => new Cell(-1, 0);
    
    public Cell(int x, int y)
    {
        X = x;
        Y = y;
    }
}