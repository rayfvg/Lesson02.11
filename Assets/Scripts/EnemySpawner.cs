using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action<Enemy> EnemyAdded;

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _spawnTimer;

    [SerializeField] private EnemyConteiner _enemyConteiner;

    private Enemy _enemy;
    private CharacterController _characterController;

    private void Awake()
    {
        InitializeEnemy();
        _enemy.gameObject.SetActive(false);

        StartCoroutine(SpawnDelay());
    }

    private void InitializeEnemy()
    {
        GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, _enemyConteiner.transform);
        _enemy = enemy.GetComponent<Enemy>();
        _characterController = enemy.GetComponent<CharacterController>();

        Mover mover = new Mover(_speed, _characterController);
        Rotator rotator = new Rotator(_enemy.transform);
        Health health = new Health(1f, _enemy.gameObject);

        _enemy.Initialize(mover, rotator, health);
    }

    private IEnumerator SpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTimer);

            InitializeEnemy();
            _enemyConteiner.Enemies.Add(_enemy);
            EnemyAdded?.Invoke(_enemy);
        }
    }
}