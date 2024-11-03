using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemyPrefab;

    private Enemy _enemy;
    private CharacterController _characterController;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            InitEnemy();
        }
    }

    public void InitEnemy()
    {
        GameObject enemy = Instantiate(_enemyPrefab);
        _enemy = enemy.GetComponent<Enemy>();
        _characterController = enemy.GetComponent<CharacterController>();

        Mover mover = new Mover(_speed, _characterController);
        Rotator rotator = new Rotator(_enemy.transform);

        _enemy.Inivcialize(mover, rotator);
    }
}
