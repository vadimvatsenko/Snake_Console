﻿namespace Snake_Console;

public abstract class BaseGameState
{
    public abstract void Update(float deltaTime);
    public abstract void Reset();
}