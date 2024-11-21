namespace Snake_Console;

public abstract class BaseGameLogic: IArrowListener
{
    protected BaseGameState? _currentState { get; private set; } // 2
    protected float _time { get; private set; }  // 4 - внутриигровое время
    protected int _screenWidth { get; private set; }  // 5 - ширина экрана
    protected int _screenHeight { get; private set; }  // 6 - высота экрана
    public abstract ConsoleColor[] CreatePallet(); // 8 - метод возвращает массив цветов
    
    public void InitializeInput(ConsoleInput input)
    {
        input.Subscribe(this);
    }
    
    public abstract void Update(float deltaTime);
    public abstract void OnArrowUp();
    public abstract void OnArrowDown();
    public abstract void OnArrowLeft();
    public abstract void OnArrowRight();

    public void ChangeState(BaseGameState state) // 3 - метод будет менять состояние игры
    {
        _currentState?.Reset(); // делаем сброс - обязательная проверка на null - _currentState?
        _currentState = state; // затем запись нового состояния
    }

    public void DrawNewState(float deltaTime, ConsoleRenderer renderer) // 7 - рисует новое состояние
    {
        _time += deltaTime;
        _screenWidth = renderer.width;
        _screenHeight = renderer.height;
        _currentState?.Update(deltaTime); // - обязательная проверка на null - _currentState?
        _currentState?.Draw(renderer); // - обязательная проверка на null - _currentState?
        this.Update(deltaTime);
    }
}