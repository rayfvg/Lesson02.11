using System;

public class PLayerDie : IRules
{
    public event Action Defeats;

    private Character _character;

    public void Start()
    {
        _character.Health.Dieds += Die;
    }

    private void Die()
    {
        Defeats?.Invoke();
    }
}
