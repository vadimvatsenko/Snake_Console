namespace Snake_Console;

public class ConsoleInput
{
    // уникальная коллекция подписчиков
    private readonly HashSet<IArrowListener> _arrowListeners = new();
    

    // добавление подписчиков в коллекцию
    public void Subscribe(IArrowListener listener)
    {
        _arrowListeners.Add(listener);
    }

    public void Update() // метод который будет считывать ввод с консоли
    {
        while (Console.KeyAvailable) // цикл происходит пока нажата, хоть какая нибудь клавиша
        {
            ConsoleKeyInfo key = Console.ReadKey();

            
            // Перебирает всех подписчиков в _arrowListeners и вызывает соответствующий метод
            switch (key.Key)
            {
                case ConsoleKey.UpArrow or ConsoleKey.W:
                    foreach (var sub in _arrowListeners) sub.OnArrowUp();
                    break;
                case ConsoleKey.DownArrow or ConsoleKey.S:
                    foreach (var sub in _arrowListeners) sub.OnArrowDown();
                    break;
                case ConsoleKey.LeftArrow or ConsoleKey.A:
                    foreach (var sub in _arrowListeners) sub.OnArrowLeft();
                    break;
                case ConsoleKey.RightArrow or ConsoleKey.D:
                    foreach (var sub in _arrowListeners) sub.OnArrowRight();
                    break;
            }
        }
    }
}