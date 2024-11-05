using System;

public class KillCounter : IRules
{
    public event Action Winner;

    private Enemy _enemy;
    private int _amountKills;

    private int _counterDieds;

    public KillCounter(Enemy enemy, int amountKills)
    {
        _enemy = enemy;
        _amountKills = amountKills;
    }

    public void Start()
    {
        _enemy.Health.Dieds += OnDied;
    }

    public void Disable()
    {
        _enemy.Health.Dieds -= OnDied;
    }

    private void OnDied()
    {
        _counterDieds++;
        if (_counterDieds >= _amountKills)
        {
            Winner?.Invoke();
        }
    }


}
