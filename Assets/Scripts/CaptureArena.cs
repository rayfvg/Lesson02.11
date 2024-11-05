using System;
using UnityEngine;

public class CaptureArena : IRules
{
    public event Action Defeat;

    private EnemySpawner _enemySpawner;
    private int _spawnEnemyForDefeat;

    private int _countEnemySpawn;

    public CaptureArena(EnemySpawner enemySpawner, int spawnEnemyForDefeat)
    {
        _enemySpawner = enemySpawner;
        _spawnEnemyForDefeat = spawnEnemyForDefeat;
    }

    public void Start()
    {
        _enemySpawner.EnemySpawns += CounterEnemy;
    }

    public void Disable()
    {
        _enemySpawner.EnemySpawns -= CounterEnemy;
    }

    private void CounterEnemy()
    {
       _countEnemySpawn++;

        if(_spawnEnemyForDefeat >= _countEnemySpawn)
        {
            Defeat?.Invoke();
        }
    }
}
