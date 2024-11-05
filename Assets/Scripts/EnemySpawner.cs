using System;
using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public event Action EnemySpawns;

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemyPrefab;

    [SerializeField] private float _spawnTimer;

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
        GameObject enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        _enemy = enemy.GetComponent<Enemy>();
        _characterController = enemy.GetComponent<CharacterController>();

        Mover mover = new Mover(_speed, _characterController);
        Rotator rotator = new Rotator(_enemy.transform);
        Health health = new Health(1f, _enemy.gameObject);

        _enemy.Inivcialize(mover, rotator, health);
    }

    private IEnumerator SpawnDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnTimer);

            InitializeEnemy();

            EnemySpawns?.Invoke();
        }
    }
}