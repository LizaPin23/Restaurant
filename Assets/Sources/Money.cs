using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private MoneyTextView _view;
    [SerializeField] private AudioSource _audio;

    public event Action GameOver;

    private int _value;
    private int _visitorDecrease;
    private int _startAmount;

    public void Initialize(int startAmount, int visitorDecrease)
    {
        _startAmount = startAmount;
        _visitorDecrease = visitorDecrease;
    }

    public void StartWork()
    {
        _value = _startAmount;
        _view.ShowValue(_value);
    }

    public void Increase(int value)
    {
        if (value < 0)
        {
            return;
        }

        _value += value;
        _audio.Play();
        _view.ShowValue(_value);
    }

    public bool TryDecrease(int value)
    {
        if (value < 0)
        {
            Debug.LogError("Wrong value");
            return false;
        }

        if (_value < value)
        {
            GameOver?.Invoke();
            return false;
        }

        _value -= value;
        _view.ShowValue(_value);
        return true;
    }

    public void VisitorDecrease()
    {
        TryDecrease(_visitorDecrease);
    }
}
