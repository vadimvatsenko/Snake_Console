namespace Snake_Console;

class Program
{
    const float targetFrameTime = 1f / 60f; // 40 - фреймтайм 60 кадров в секунду
    static void Main(string[] args)
    {
        SnakeGameLogic gameLogic = new SnakeGameLogic();
        ConsoleColor[] pallette = gameLogic.CreatePallet(); // 28 - палитра
        
        ConsoleRenderer renderer0 = new ConsoleRenderer(pallette); // 29
        ConsoleRenderer renderer1 = new ConsoleRenderer(pallette); // 30
        
        ConsoleInput consoleInput = new ConsoleInput();
        gameLogic.InitializeInput(consoleInput);
        
        ConsoleRenderer prevRenderer = renderer0; // 31
        ConsoleRenderer currentRenderer = renderer1; // 32
        
        DateTime lastFrameTime = DateTime.Now;
        //gameLogic.GotoGamePlay(); // сброс в первоначальное состояние // 33

        while (true)
        {
            DateTime frameStartTime = DateTime.Now;
            consoleInput.Update(); // постоянный запуск Update в consoleInput => ждёт нажатие клавиши ////
            
            float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;
            //gameLogic.Update(deltaTime); // 34
            consoleInput.Update(); // 35
            
            gameLogic.DrawNewState(deltaTime, currentRenderer); // 36
            lastFrameTime = frameStartTime;
            
            if(!currentRenderer.Equals(prevRenderer)) currentRenderer.Render(); // 37

            ConsoleRenderer tmp = prevRenderer; // 38
            currentRenderer.Clear(); // 39
            
            // frameStartTime - исходную точку, от которой будет рассчитываться время следующего кадра
            // TimeSpan.FromSeconds(targetFrameTime) - временной интервал (TimeSpan), который равен количеству секунд, указанному в targetFrameTime
            // frameStartTime + TimeSpan - момент времени, когда следует завершить обработку текущего кадра.
            // nextFrameTime - это расчетное время окончания текущего кадра или начала следующего.
            DateTime nextFrameTime = frameStartTime + TimeSpan.FromSeconds(targetFrameTime); // 41 - TimeSpan.FromSeconds(targetFrameTime) = 0.16
            
            DateTime endFrameTime = DateTime.Now; // 42 - Время, когда текущий кадр уже завершил обработку
            
            // nextFrameTime > endFrameTime - Проверяет, завершилась ли обработка текущего кадра раньше, чем нужно.
            // Thread.Sleep - делает паузу на оставшееся время, что время кадра было плавным
            if (nextFrameTime > endFrameTime) // 43
            {
                Thread.Sleep((int)(nextFrameTime - endFrameTime).TotalMilliseconds);
            }
        }
    }
}

