namespace Snake_Console;

// слушатели на нажатие на клавиши
public interface IArrowListener
{
    public void OnArrowUp();
    public void OnArrowDown();
    public void OnArrowLeft();
    public void OnArrowRight();
}