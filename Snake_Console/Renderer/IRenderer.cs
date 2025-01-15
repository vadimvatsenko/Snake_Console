namespace Snake_Console;

public interface IRenderer
{
    public void SetPixel(int w, int h, char val, byte colorIdx);
    public void Render();
    public void DrawString(string text, int atWidth, int atHeight, ConsoleColor color);
    public void Clear();
}