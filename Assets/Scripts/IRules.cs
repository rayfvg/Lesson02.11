using System;

public interface IRules
{
    event Action Done;

    void Start();

    void Disable();
}