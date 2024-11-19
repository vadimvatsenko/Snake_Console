namespace Snake_Console;

public class SnakeGameplayState: BaseGameState
{
    private List<Cell> _bodyList = new List<Cell>();
    private SnakeDir _currentDir;
    private float _timeToMove;
    
    public override void Update(float deltaTime)
    {
        _timeToMove -= deltaTime;
        if (_timeToMove > 0) return;

        // Скорость змейки: одна клетка каждую секунду
        _timeToMove = 1f / 1f;

        // Перемещение головы змейки
        Cell head = _bodyList[0];
        Cell nextCell = ShiftTo(head, _currentDir);

        // Перемещение тела змейки
        _bodyList.RemoveAt(_bodyList.Count - 1);
        _bodyList.Insert(0, nextCell);

        Console.WriteLine($"Snake coord X = {_bodyList[0].X}, Y = {_bodyList[0].Y}");
    }

    public override void Reset()
    {
        _bodyList.Clear();
        _currentDir = SnakeDir.Right;
        _bodyList.Add(Cell.Zero);
        _timeToMove = 0; 
    }

    public void SetDirection(SnakeDir dir)
    {
        _currentDir = dir;
    }

    private Cell ShiftTo(Cell from, SnakeDir direction)
    {
        switch (direction)
        {
            case SnakeDir.Right:
                return from + Cell.Right;
            break;
            case SnakeDir.Left:
                return from + Cell.Left;
            break;
            case SnakeDir.Down:
                return from + Cell.Down;
            break;
            case SnakeDir.Up:
                return from + Cell.Up;
            break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}