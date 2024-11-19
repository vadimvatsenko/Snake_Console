namespace Snake_Console;

public class BaseGameLogic: IArrowListener
{
    public void InitializeInput(ConsoleInput input)
    {
        input.Subscribe(this);
    }

    public void Update(float deltaTime)
    {
        
    }
    public void OnArrowUp()
    {
        throw new NotImplementedException();
    }

    public void OnArrowDown()
    {
        throw new NotImplementedException();
    }

    public void OnArrowLeft()
    {
        throw new NotImplementedException();
    }

    public void OnArrowRight()
    {
        throw new NotImplementedException();
    }
}