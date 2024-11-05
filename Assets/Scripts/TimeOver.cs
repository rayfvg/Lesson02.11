using System;
using UnityEngine;

public class TimeOver : IRules
{
    public event Action Winner;

    private float _timeToWin;
    private float _currentTime = 0;

    public TimeOver(float timeToWin)
    {
        _timeToWin = timeToWin;
    }

    public void Start()
    {
        _currentTime += Time.deltaTime;

        if(_currentTime > _timeToWin)
        {
           Winner?.Invoke();
        }
    }

    public void Disable()
    {
        
    }
}