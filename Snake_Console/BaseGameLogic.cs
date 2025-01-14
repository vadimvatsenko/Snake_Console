namespace Snake_Console;

public abstract class BaseGameLogic: IArrowListener
{
    protected BaseGameState? CurrentState { get; private set; } // 2
    protected float Time { get; private set; }  // 4 - внутриигровое время
    protected int ScreenWidth { get; private set; }  // 5 - ширина экрана
    protected int ScreenHeight { get; private set; }  // 6 - высота экрана    
       
    public abstract void Update(float deltaTime);
    public abstract void OnArrowUp();
    public abstract void OnArrowDown();
    public abstract void OnArrowLeft();
    public abstract void OnArrowRight();
    public abstract ConsoleColor[] CreatePallet(); // 8 - метод возвращает массив цветов
    
    public void InitializeInput(ConsoleInput input)
    {
        input.Subscribe(this);
    }

    public void ChangeState(BaseGameState state) // 3 - метод будет менять состояние игры
    {
        CurrentState?.Reset(); // делаем сброс - обязательная проверка на null - _currentState?
        CurrentState = state; // затем запись нового состояния
    }

    public void DrawNewState(float deltaTime, ConsoleRenderer renderer) // 7 - рисует новое состояние
    {
        Time += deltaTime;
        ScreenWidth = renderer.width;
        ScreenHeight = renderer.height;
        CurrentState?.Update(deltaTime); // - обязательная проверка на null - _currentState?
        CurrentState?.Draw(renderer); // - обязательная проверка на null - _currentState?
        this.Update(deltaTime);
    }
}