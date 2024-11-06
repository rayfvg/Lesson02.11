using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Mover _mover;
    private Rotator _rotator;

    private Vector3 _direction = Vector3.forward;
    private EnemyConteiner _enemyConteiner;
    public Health Health { get; private set; }

    public void Initialize(Mover mover, Rotator rotator, Health health)
    {
        _mover = mover;
        _rotator = rotator;
        Health = health;
    }

    private void Start()
    {
        StartCoroutine(ChangeDirection());
        _enemyConteiner = FindObjectOfType<EnemyConteiner>();
    }

    private void FixedUpdate()
    {
        _mover.MoverTo(_direction);
        _rotator.ForseRotateTo(_direction);

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Bullet>())
        {
            Health.TakeDamage(1f);
        }
    }

    private void OnDestroy()
    {
        if (_enemyConteiner != null)
            _enemyConteiner.Enemies.Remove(this);
    }

    private IEnumerator ChangeDirection()
    {
        while (true)
        {
            _direction = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
            yield return new WaitForSeconds(3f);
        }
    }
}