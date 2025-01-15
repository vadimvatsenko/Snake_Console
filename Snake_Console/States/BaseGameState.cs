namespace Snake_Console;

public abstract class BaseGameState
{
    public abstract bool IsDone(); 
    public abstract void Update(float deltaTime);
    public abstract void Reset();
    public abstract void Draw(ConsoleRenderer consoleRenderer); 
}