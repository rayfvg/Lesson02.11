using System;
using UnityEngine;

public class Health
{
    public event Action Dieds;

    private float _health;
    private GameObject _gameObject;

    private bool _isAlive = true;

    public Health(float health, GameObject gameObject)
    {
        _health = health;
        _gameObject = gameObject;
    }

    public void TakeDamage(float value)
    {

        if (value < 0)
        {
            Debug.LogError("invalid value");
            return;
        }

        if (_isAlive)
        {
            _health -= value;

            if (_health <= 0)
            {
                _health = 0;
                Dieds?.Invoke();
                UnityEngine.Object.Destroy(_gameObject);
                _isAlive = false;
            }
        }
    }
}