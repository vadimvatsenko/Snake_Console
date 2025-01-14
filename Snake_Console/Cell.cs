namespace Snake_Console;

public struct Cell
{
    public int x;
    public int y;

    public static Cell Zero => new Cell(0, 0);
    public static Cell Up => new Cell(0, -1);
    public static Cell Down => new Cell(0, 1);
    public static Cell Right => new Cell(1, 0);
    public static Cell Left => new Cell(-1, 0);
    
    public Cell(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public static Cell operator +(Cell left, Cell right) => new(left.x + right.x, left.y + right.y);
    public static Cell operator -(Cell left, Cell right) => new(left.x - right.x, left.y - right.y);
    public static Cell operator +(Cell left, int right) => new(left.x * right, left.y * right);
    
    public override bool Equals(object? obj)
    {
        if(obj is not Cell otherCell) return false;
        return x == otherCell.x && y == otherCell.y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(x, y);
    }
}