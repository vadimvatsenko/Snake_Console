namespace Snake_Console;

class Program
{
    static void Main(string[] args)
    {
        SnakeGameLogic gameLogic = new SnakeGameLogic();
        ConsoleInput consoleInput = new ConsoleInput();
        gameLogic.InitializeInput(consoleInput);
        
        var lastFrameTime = DateTime.Now;
        gameLogic.GotoGamePlay();

        while (true)
        {
            consoleInput.Update();
            var frameStartTime = DateTime.Now;
            
            float deltaTime = (float)(DateTime.Now - frameStartTime).TotalMilliseconds;
            gameLogic.Update(deltaTime);
            lastFrameTime = frameStartTime;
            
        }
        
    }
}
