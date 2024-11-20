namespace Snake_Console;

public class SnakeGameLogic: BaseGameLogic
{
    private SnakeGameplayState _gameplayState = new SnakeGameplayState();

    // 18 тут удалили _gameplayState.Update(deltaTime) и добавили другую логику
    public override void Update(float deltaTime) 
    {
        if(_currentState != _gameplayState) GotoGamePlay();
    } 
    public override ConsoleColor[] CreatePallet() // 8 - возврат массива цветов
    {
        return new ConsoleColor[] 
            {   
                ConsoleColor.DarkBlue, 
                ConsoleColor.DarkGreen, 
                ConsoleColor.DarkCyan, 
                ConsoleColor.DarkRed 
            };
    }

    public void GotoGamePlay() // 17
    {
        _gameplayState.Reset();
        _gameplayState.FieldHeight = this._screenHeight;
        _gameplayState.FieldWidth = this._screenWidth;
        ChangeState(_gameplayState);

    }
    public override void OnArrowUp() // 9 
    {
        // проверка на если currentState не является gameplayState
        if(_currentState != _gameplayState) return; 
        _gameplayState.SetDirection(SnakeDir.Up);
    }

    public override void OnArrowDown() // 10
    {
        if(_currentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Down);
    }

    public override void OnArrowLeft() // 11
    {
        if(_currentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Left);
    }

    public override void OnArrowRight() // 12
    {
        if(_currentState != _gameplayState) return;
        _gameplayState.SetDirection(SnakeDir.Right);
    }
}