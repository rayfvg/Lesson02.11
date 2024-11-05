using System;

public class PLayerDie : IRules
{
    public event Action Defeats;

    private Character _character;

    public PLayerDie(Character character)
    {
        _character = character;
    }

    public void Start()
    {
        _character.Health.Dieds += Die;
    }

    public void Disable()
    {
        _character.Health.Dieds -= Die;
    }

    private void Die()
    {
        Defeats?.Invoke();
    }
}
