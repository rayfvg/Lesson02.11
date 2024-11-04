using System;
using UnityEngine;

public class CaptureArena : IRules
{
    public event Action Defeat;

    private EnemySpawner _enemySpawner;
    private int _spawnEnemyForDefeat;

    private int _countEnemySpawn;

    public void Start()
    {
        _enemySpawner.EnemySpawns += CounterEnemy;
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
