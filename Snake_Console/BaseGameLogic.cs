namespace Snake_Console;

public abstract class BaseGameLogic: IArrowListener
{
    protected BaseGameState? CurrentState { get; private set; } 
    protected float Time { get; private set; }  // внутриигровое время
    protected int ScreenWidth { get; private set; }  // ширина экрана
    protected int ScreenHeight { get; private set; }  // высота экрана    
       
    public abstract void Update(float deltaTime);
    public abstract void OnArrowUp();
    public abstract void OnArrowDown();
    public abstract void OnArrowLeft();
    public abstract void OnArrowRight();
    public abstract ConsoleColor[] CreatePallet(); // метод возвращает массив цветов
    
    public void InitializeInput(ConsoleInput input)
    {
        input.Subscribe(this);
    }

    public void ChangeState(BaseGameState state) // метод будет менять состояние игры
    {
        CurrentState?.Reset(); // делаем сброс - обязательная проверка на null - _currentState?
        CurrentState = state; // затем запись нового состояния
    }

    public void DrawNewState(float deltaTime, ConsoleRenderer renderer) // рисует новое состояние
    {
        Time += deltaTime;
        ScreenWidth = renderer.width;
        ScreenHeight = renderer.height;
        CurrentState?.Update(deltaTime); // - обязательная проверка на null - _currentState?
        CurrentState?.Draw(renderer); // - обязательная проверка на null - _currentState?
        this.Update(deltaTime);
    }
}