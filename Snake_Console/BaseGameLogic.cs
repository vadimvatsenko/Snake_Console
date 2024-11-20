namespace Snake_Console;

public abstract class BaseGameLogic: IArrowListener
{
    private BaseGameState _currentState; // 2
    private float _time; // 4 - внутриигровое время
    private int _screenWidth; // 5 - ширина экрана
    private int _screenHeight; // 6 - высота экрана
    public void InitializeInput(ConsoleInput input)
    {
        input.Subscribe(this);
    }
    public abstract void Update(float deltaTime);
    public abstract ConsoleColor[] CreatePallet(); // 8 - метод возвращает массив цветов
    public abstract void OnArrowUp();
    public abstract void OnArrowDown();
    public abstract void OnArrowLeft();
    public abstract void OnArrowRight();

    public void ChangeState(BaseGameState state) // 3 - метод будет менять состояние игры
    {
        _currentState.Reset(); // делаем сброс
        _currentState = state; // затем запись нового состояния
    }

    public void DrawNewState(float deltaTime, ConsoleRenderer renderer) // 7 - рисует новое состояние
    {
        _time += deltaTime;
        _screenWidth = renderer.width;
        _screenHeight = renderer.height;
        _currentState.Update(deltaTime);
        _currentState.Draw(renderer);
        this.Update(deltaTime);
    }
}