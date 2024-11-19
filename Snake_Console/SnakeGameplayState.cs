namespace Snake_Console;

public class SnakeGameplayState: BaseGameState
{
    private List<Cell> _bodyList = new List<Cell>();
    private SnakeDir _currentDir;
    private float _timeToMove;
    
    public override void Update(float deltaTime)
    {
        _timeToMove -= deltaTime;
        if (_timeToMove <= 0)
        {
            return;
        }
        else
        {
            _timeToMove = 1f / 5f;
        }
        
        Cell head = _bodyList[0];
        Cell nextCell = ShiftTo(head, SnakeDir.Right);
        nextCell = Cell.Zero;
        Console.WriteLine(_bodyList[0].ToString());
    }

    public override void Reset()
    {
        _bodyList.Clear();
        _currentDir = SnakeDir.Right;
        _bodyList.Add(Cell.Zero);
        _timeToMove = 0; 
    }

    private void SetDirection(SnakeDir dir)
    {
        _currentDir = dir;
    }

    private Cell ShiftTo(Cell from, SnakeDir direction)
    {
        switch (direction)
        {
            case SnakeDir.Right:
                return Cell.Right;
            break;
            case SnakeDir.Left:
                return Cell.Left;
            break;
            case SnakeDir.Down:
                return Cell.Down;
            break;
            case SnakeDir.Up:
                return Cell.Up;
            break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
    
    
}