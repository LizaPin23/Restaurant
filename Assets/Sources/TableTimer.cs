using System;
using UnityEngine;

public class TableTimer : MonoBehaviour
{
    public event Action TimerEnded;
    private float _time;
    private float _timer;

    private void Awake()
    {
        enabled = false;
    }

    void Update()
    {
        _time = _time + Time.deltaTime;

        if (_time >= _timer)
        {
            enabled = false;
            TimerEnded?.Invoke();
        }
    }

    public void Set(float duration)
    {
        _time = 0;
        _timer = duration;
        enabled = true;
    }
}
