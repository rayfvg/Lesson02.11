using System;

public class PLayerDie : IRules
{
    public event Action Done;

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
        Done?.Invoke();
    }
}
