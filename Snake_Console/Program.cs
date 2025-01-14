namespace Snake_Console;

class Program
{
    const float targetFrameTime = 1f / 60f; // фреймтайм 60 кадров в секунду
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        SnakeGameLogic gameLogic = new SnakeGameLogic();
        ConsoleColor[] pallette = gameLogic.CreatePallet(); // палитра
        
        ConsoleRenderer renderer0 = new ConsoleRenderer(pallette); 
        ConsoleRenderer renderer1 = new ConsoleRenderer(pallette); 
        
        ConsoleInput consoleInput = new ConsoleInput();
        gameLogic.InitializeInput(consoleInput);
        
        ConsoleRenderer prevRenderer = renderer0; 
        ConsoleRenderer currentRenderer = renderer1; 
        
        DateTime lastFrameTime = DateTime.Now;
        //gameLogic.GotoGamePlay(); // сброс в первоначальное состояние 

        while (true)
        {
            DateTime frameStartTime = DateTime.Now;
            //consoleInput.Update(); // постоянный запуск Update в consoleInput => ждёт нажатие клавиши

            float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;
            //gameLogic.Update(deltaTime); 
            consoleInput.Update(); 

            gameLogic.DrawNewState(deltaTime, currentRenderer); 
            lastFrameTime = frameStartTime;

            if (!currentRenderer.Equals(prevRenderer)) currentRenderer.Render(); 

            ConsoleRenderer tmp = prevRenderer; 
            prevRenderer = currentRenderer; 
            currentRenderer = tmp; 
            currentRenderer.Clear(); 

            // frameStartTime - исходную точку, от которой будет рассчитываться время следующего кадра
            // TimeSpan.FromSeconds(targetFrameTime) - временной интервал (TimeSpan), который равен количеству секунд, указанному в targetFrameTime
            // frameStartTime + TimeSpan - момент времени, когда следует завершить обработку текущего кадра.
            // nextFrameTime - это расчетное время окончания текущего кадра или начала следующего.
            DateTime nextFrameTime = frameStartTime + TimeSpan.FromSeconds(targetFrameTime); // TimeSpan.FromSeconds(targetFrameTime) = 0.16

            DateTime endFrameTime = DateTime.Now; // Время, когда текущий кадр уже завершил обработку

            // nextFrameTime > endFrameTime - Проверяет, завершилась ли обработка текущего кадра раньше, чем нужно.
            // Thread.Sleep - делает паузу на оставшееся время, что время кадра было плавным
            if (nextFrameTime > endFrameTime) 
            {
                Thread.Sleep((int)(nextFrameTime - endFrameTime).TotalMilliseconds);
            }
        }

    }
}

