using System;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Transform ShotPosition;

    private Vector3 _input;

    private Mover _mover;
    private Rotator _rotator;
    private Shoter _shoter;

    private IRules _rulesDefeats;
    private IRules _relesVictories;

    public Health Health {  get; private set; }

    public void Initialize(Mover mover, Rotator rotator, Health health, Shoter shoter)
    {
        _mover = mover;
        _rotator = rotator;
        Health = health;
        _shoter = shoter;
    }

    public void InitializeRules(IRules rulesDefeats, IRules relesVictories)
    {
        _rulesDefeats = rulesDefeats;
        _relesVictories = relesVictories;

        //Я в душе не ебу, что это такое, но просто из интерфеса я не смог подписаться
        if (_relesVictories is TimeOver timeOver)   
        {
            timeOver.Winner += OnWin;
        }

        if (_rulesDefeats is PLayerDie playerDie)
        {
            playerDie.Defeats += OnDefeat;
        }
    }

    private void Start()
    {
        _rulesDefeats.Start();
        _relesVictories.Start();
    }

    private void OnDestroy()
    {
        _rulesDefeats.Disable();
        _relesVictories.Disable();

        if (_relesVictories is TimeOver timeOver)
        {
            timeOver.Winner -= OnWin;
        }

        if (_rulesDefeats is PLayerDie playerDie)
        {
            playerDie.Defeats -= OnDefeat;
        }
    }

    private void OnDefeat()
    {
        Debug.Log("DEFEAT");
    }

    private void OnWin()
    {
        Debug.Log("VICTORY");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.GetComponent<Enemy>())
        {
            Debug.Log("урон герою");
            Health.TakeDamage(10);
        }
    }

    private void Update()
    {
        _input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (Input.GetMouseButtonDown(0))
        {
            _shoter.Shot();
        }
    }

    private void FixedUpdate()
    {
        if (_input.magnitude > 0.1f)
        {
            _mover.MoverTo(_input);
            _rotator.ForseRotateTo(_input);
        }
    }
}