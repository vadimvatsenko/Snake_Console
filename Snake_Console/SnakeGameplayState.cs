using System.Drawing;

namespace Snake_Console;

public class SnakeGameplayState: BaseGameState
{
    
    private const char SnakeSymbol = '\u25a0'; // добавлен символ змейки
    private const char AppleSymbol = '\u25c9'; // 1
    private int _fieldWidth; // ширина поля
    private int _fieldHeight; // высота поля

    private List<Cell> _bodyList = new List<Cell>();
    private Cell _apple = new Cell(); // 2
    private SnakeDir _currentDir = SnakeDir.Right;
    private float _timeToMove = 0;
    
    private Random _random = new Random(); // 4
    private int _score = 0; // 7 - количество яблок
    
    //private SnakeGameLogic? _snakeGameLogic ; 

    public int FieldWidth 
    {
        get => _fieldWidth;
        set => _fieldWidth = value;
    }

    public int FieldHeight 
    {
        get => _fieldHeight;
        set => _fieldHeight = value;
    }

    public void SetDirection(SnakeDir dir) => _currentDir = dir;
    
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

        if (nextCell.Equals(_apple)) // 6 - реализация роста змейки
        {
            _bodyList.Insert(0, _apple);
            _score++;
            GenerateApple();
            return;
        }

        // Перемещение тела змейки.
        // Последняя клетка змейки (хвост) удаляется из списка с помощью RemoveAt(_bodyList.Count - 1)
        _bodyList.RemoveAt(_bodyList.Count - 1);
        // На её место вставляется новая клетка (новая позиция головы), чтобы "переместить" змейку.,
        _bodyList.Insert(0, nextCell);

        //Console.WriteLine($"Snake coord X = {_bodyList[0].X}, Y = {_bodyList[0].Y}"); // коментируем
    }

    

    public override void Draw(ConsoleRenderer consoleRenderer)  
    {
        //Random random = new Random(); 
        //int randomColorIndex = random.Next(0, _snakeGameLogic.CreatePallet().Length); 
        
        consoleRenderer.SetPixel(_apple.x, _apple.y, AppleSymbol, 1); // 3
        
        foreach (var cell in _bodyList)
        {
            consoleRenderer.SetPixel(cell.x, cell.y, SnakeSymbol, 6);
           
        }
        
        consoleRenderer.DrawString($"Score: {_score.ToString()}", FieldWidth / 2, 0, ConsoleColor.DarkBlue);
    }
    
    public override void Reset() 
    {
        _bodyList.Clear();
        int middleX = FieldWidth / 2; 
        int middleY = FieldHeight / 2; 

        _currentDir = SnakeDir.Right;
        _bodyList.Add(new Cell(middleX, middleY)); // были нулевые координаты
        _timeToMove = 0;
        _apple = new Cell(middleX + 3, middleY + 3);
    }

    private void GenerateApple() // 5 
    {
        Cell cell = new Cell(_random.Next(FieldWidth), _random.Next(FieldHeight));

        if (_bodyList[0].Equals(cell))
        {
            if (cell.y > FieldHeight)
            {
                cell.y -= 1;
            }
            else
            {
                cell.y += 1;
            }
        }
        _apple = cell;
    }
   
    private Cell ShiftTo(Cell from, SnakeDir direction)
    {
        switch (direction)
        {
            case SnakeDir.Right:
                return from + Cell.Right;
            case SnakeDir.Left:
                return from + Cell.Left;
            case SnakeDir.Down:
                return from + Cell.Down;
            case SnakeDir.Up:
                return from + Cell.Up;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }
}