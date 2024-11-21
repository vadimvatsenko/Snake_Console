namespace Snake_Console;

public class SnakeGameplayState: BaseGameState
{
    
    private List<Cell> _bodyList = new List<Cell>();
    private SnakeDir _currentDir;
    private float _timeToMove = 0;
    private int _fieldWidth; // 13 - ширина поля
    private int _fieldHeight; // 14 - высота поля
    private const char SnakeSymbol = '■'; // 23 - добавлен символ змейки
    
    //private SnakeGameLogic? _snakeGameLogic ; // 25

    public int FieldWidth // 15 
    {
        get => _fieldWidth;
        set => _fieldWidth = value;
    }

    public int FieldHeight // 16
    {
        get => _fieldHeight;
        set => _fieldHeight = value;
    }
        
    
    public override void Update(float deltaTime)
    {
        // Уменьшение таймера. Переменная _timeToMove отсчитывает время до следующего перемещения змейки.
        // В каждом вызове метода Update значение _timeToMove уменьшается на величину прошедшего времени (deltaTime).
        // Если _timeToMove всё ещё больше 0, метод завершает выполнение, чтобы не двигать змейку слишком часто.
        _timeToMove -= deltaTime;
        if (_timeToMove > 0) return;

        
        // Установка скорости перемещения. 1 клетка в секунду. Например, 1/2 означает 2 клетки в секунду
        _timeToMove = 1f / 1f;

        // Перемещение головы змейки. head — это текущая позиция головы змейки (первый элемент в списке _bodyList).
        Cell head = _bodyList[0];

        // Вычисляем следующие положение змейки
        Cell nextCell = ShiftTo(head, _currentDir);

        // Перемещение тела змейки.
        // Последняя клетка змейки (хвост) удаляется из списка с помощью RemoveAt(_bodyList.Count - 1)
        _bodyList.RemoveAt(_bodyList.Count - 1);
        // На её место вставляется новая клетка (новая позиция головы), чтобы "переместить" змейку.,
        _bodyList.Insert(0, nextCell);

        //Console.WriteLine($"Snake coord X = {_bodyList[0].X}, Y = {_bodyList[0].Y}"); // 25 - коментируем
    }

    public override void Reset() // 19
    {
        _bodyList.Clear();
        int middleX = _fieldWidth / 2; // 20
        int middleY = _fieldHeight / 2; // 21
        
        _currentDir = SnakeDir.Right;
        _bodyList.Add(new Cell(middleX, middleY)); // 22 были нулевые координаты
        _timeToMove = 0; 
    }

    public override void Draw(ConsoleRenderer consoleRenderer) // 18 
    {
        //Random random = new Random(); // 26
        //int randomColorIndex = random.Next(0, _snakeGameLogic.CreatePallet().Length); // 27

        foreach (var cell in _bodyList)
        {
            consoleRenderer.SetPixel(cell.X, cell.Y, SnakeSymbol, 3);
            Console.WriteLine(cell.ToString());
        }
    }

    public void SetDirection(SnakeDir dir) => _currentDir = dir;
    
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