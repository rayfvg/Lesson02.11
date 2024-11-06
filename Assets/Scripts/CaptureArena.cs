using System;

public class CaptureArena : IRules
{
    public event Action Done;

    private EnemySpawner[] _enemySpawners;

    private int _spawnEnemyForDefeat;

    private int _countEnemySpawn;

    public CaptureArena(EnemySpawner[] enemySpawners, int spawnEnemyForDefeat)
    {
        _enemySpawners = enemySpawners;
        _spawnEnemyForDefeat = spawnEnemyForDefeat;
    }

    public void Start()
    {
        foreach(EnemySpawner spawers in _enemySpawners)
        {
            spawers.EnemySpawns += CounterEnemy;
        }
    }

    public void Disable()
    {
        foreach (EnemySpawner spawers in _enemySpawners)
        {
            spawers.EnemySpawns -= CounterEnemy;
        }
    }

    private void CounterEnemy()
    {
       _countEnemySpawn++;

        if(_spawnEnemyForDefeat == _countEnemySpawn)
        {
            Done?.Invoke();
        }
    }
}
