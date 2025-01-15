namespace Snake_Console;

public class SnakeGameLogic: BaseGameLogic
{
    private SnakeGameplayState _gameplayState = new SnakeGameplayState();
    private bool _newGamePending = false; 
    private int _currentLevel = 0; 
    private ShowTextState _showTextState = new ShowTextState(2f); 
    
    public void GotoGamePlay() 
    {
        _gameplayState.Level = _currentLevel;
        _gameplayState.FieldHeight = this.ScreenHeight;
        _gameplayState.FieldWidth = this.ScreenWidth;
        ChangeState(_gameplayState);
        _gameplayState.Reset();
    }
    
    public void GotoGameOver()
    {
        _currentLevel = 0;
        _gameplayState.Score = 0;
        _newGamePending = true;
        _showTextState.Text = "Game Over";
        ChangeState(_showTextState);
    }

    public void GotoNextLevel()
    {
        _currentLevel++;
        _newGamePending = false;
        _showTextState.Text = $"Level {_currentLevel}";
        ChangeState(_showTextState);
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
    
    public override void Update(float deltaTime) 
    {
        if(CurrentState != null && !CurrentState.IsDone()) return;

        if ((CurrentState == null || CurrentState == _gameplayState) && !_gameplayState.gameOver)
        {
            GotoNextLevel();
        }
        else if (CurrentState == _gameplayState && _gameplayState.gameOver)
        {
            GotoGameOver();
        }
        else if (CurrentState != _gameplayState && _newGamePending)
        {
            GotoNextLevel();
        }
        else if(CurrentState != _gameplayState && !_newGamePending)
        {
            GotoGamePlay();
        }
    } 
    
    public override ConsoleColor[] CreatePallet() 
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
    
}