using System;
using System.Collections;
using UnityEngine;

public class TimeOver : IRules
{
    public event Action Done;

    private MonoBehaviour _context;

    private float _timeToWin;
    private float _currentTime = 0;

    private bool _working = true;

    public TimeOver(float timeToWin, MonoBehaviour context)
    {
        _timeToWin = timeToWin;
        _context = context;
    }

    public void Start()
    {
        _context.StartCoroutine(Timer());
    }

    public void Disable()
    {

    }

    private IEnumerator Timer()
    {
        while (_working)
        {
            yield return new WaitForSeconds(1);
            _currentTime += 1;
            Debug.Log(_currentTime + "+ секунда");

            if (_currentTime > _timeToWin)
            {
                Done?.Invoke();
                Debug.Log("поведение победы отсчитало 5 секунд");
                _working = false;
            }
        }
    }
}