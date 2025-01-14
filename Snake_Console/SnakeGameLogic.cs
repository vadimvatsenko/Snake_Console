namespace Snake_Console;

public class SnakeGameLogic: BaseGameLogic
{
    private SnakeGameplayState _gameplayState = new SnakeGameplayState();

    // тут удалили _gameplayState.Update(deltaTime) и добавили другую логику
    public override void Update(float deltaTime) 
    {
        if(CurrentState != _gameplayState) GotoGamePlay();
    } 
    public override ConsoleColor[] CreatePallet() // возврат массива цветов
    {
        return new ConsoleColor[] 
            {   
                ConsoleColor.DarkBlue, 
                ConsoleColor.DarkGreen, 
                ConsoleColor.DarkCyan, 
                ConsoleColor.DarkRed,
                ConsoleColor.DarkYellow,
                ConsoleColor.DarkMagenta,
                ConsoleColor.Magenta,
            };
    }

    public void GotoGamePlay() // 17
    {
        _gameplayState.FieldHeight = this.ScreenHeight;
        _gameplayState.FieldWidth = this.ScreenWidth;
        ChangeState(_gameplayState);
        _gameplayState.Reset();

    }
    public override void OnArrowUp()  
    {
        // проверка на если currentState не является gameplayState
        if(CurrentState != _gameplayState) return; 
        _gameplayState.SetDirection(SnakeDir.Up);
    }

    public override void OnArrowDown() 
    {
        if(CurrentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Down);
    }

    public override void OnArrowLeft() 
    {
        if(CurrentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Left);
    }

    public override void OnArrowRight() 
    {
        if(CurrentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Right);
    }
}