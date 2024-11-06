using System;
using System.Collections.Generic;
using UnityEngine;

public class KillCounter : IRules
{
    public event Action Done;

    private EnemySpawner[] _spawner;

    private int _amountKills;

    private int _counterDieds;

    public KillCounter(EnemySpawner[] enemySpawners, int amountKills)
    {
        _spawner = enemySpawners;
        _amountKills = amountKills;

        foreach (EnemySpawner enemySpawner in _spawner)
            enemySpawner.EnemyAdded += OnAddEnemy;
    }

    private void OnAddEnemy(Enemy enemy)
    {
        enemy.Health.Dieds += OnDied;
    }

    public void Start()
    {
        
    }

    public void Disable()
    {
        
    }

    private void OnDied()
    {
        _counterDieds++;
        Debug.Log("умер враг" + _counterDieds);

        if (_counterDieds >= _amountKills)
        {
            Done?.Invoke();
        }
    }
}