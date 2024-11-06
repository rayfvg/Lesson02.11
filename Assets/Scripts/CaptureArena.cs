using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureArena : IRules
{
    public event Action Done;

    private List<Enemy> _enemies;
    private MonoBehaviour _context;

    private int _spawnEnemyForDefeat;

    private int _currentCountEnemy;

    public CaptureArena(List<Enemy> enemies, MonoBehaviour context, int spawnEnemyForDefeat)
    {
        _enemies = enemies;
        _context = context;
        _spawnEnemyForDefeat = spawnEnemyForDefeat;
    }

    public void Start()
    {
        _context.StartCoroutine(Update());
    }

    public void Disable()
    {
       
    }

    private IEnumerator Update()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            _currentCountEnemy = _enemies.Count;

            Debug.Log("Врагов на сцене" + _currentCountEnemy);

            if (_currentCountEnemy >= _spawnEnemyForDefeat)
            {
                Done?.Invoke();
            }
        }
    }
}