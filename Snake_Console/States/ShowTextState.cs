using System.Numerics;

namespace Snake_Console;

public class ShowTextState: BaseGameState
{
    private string _text;
    
    private float _duration;
    private float _timeLeft;

    public string Text
    {
        get => _text;
        set => _text = value;
    }

    public ShowTextState(float duration) : this(string.Empty, duration)
    {
        
    }

    public ShowTextState(string text, float duration)
    {
        Text = text;
        _duration = duration;
        
        Reset();
    }
    
    public override void Draw(ConsoleRenderer consoleRenderer)
    {
        var textHalfLength = Text.Length / 2;
        var textY = consoleRenderer.height / 2;
        var textX = consoleRenderer.width / 2 - textHalfLength;
        consoleRenderer.DrawString(Text, textX, textY, ConsoleColor.DarkRed);
    }
    
    public override void Reset()
    {
        _timeLeft = _duration;
    }
    
    public override void Update(float deltaTime)
    {
        _timeLeft -= deltaTime;
    }
    
    public override bool IsDone()
    {
        return _timeLeft <= 0f;
    }
}