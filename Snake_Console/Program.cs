namespace Snake_Console;

class Program
{
    static void Main(string[] args)
    {
        SnakeGameLogic gameLogic = new SnakeGameLogic();
        ConsoleInput consoleInput = new ConsoleInput();
        gameLogic.InitializeInput(consoleInput);
        
        DateTime lastFrameTime = DateTime.Now;
        gameLogic.GotoGamePlay(); // сброс в первоначальное состояние

        while (true)
        {
            consoleInput.Update(); // постоянный запуск Update в consoleInput => ждёт нажатие клавиши
            DateTime frameStartTime = DateTime.Now;
            
            float deltaTime = (float)(DateTime.Now - frameStartTime).TotalMilliseconds;
            gameLogic.Update(deltaTime);
            lastFrameTime = frameStartTime;
        }
    }
}
