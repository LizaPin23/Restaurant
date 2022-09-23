using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private MoneyTextView _view;

    public event Action GameOver;

    private int _value;
    private int _visitorDecrease;

    public void Initialize(int startAmount, int visitorDecrease)
    {
        _value = startAmount;
        _view.ShowValue(_value);
        _visitorDecrease = visitorDecrease;
    }

    public void Increase(int value)
    {
        if (value < 0)
        {
            return;
        }

        _value += value;
        _view.ShowValue(_value);
    }

    public bool TryDecrease(int value)
    {
        if (value < 0) return false;
        if (_value < value) return false;

        _value -= value;
        _view.ShowValue(_value);
        return true;
    }

    public void VisitorDecrease()
    {
        bool enoughMoney = TryDecrease(_visitorDecrease);
        if(enoughMoney == false)
        {
            GameOver?.Invoke();
        }
    }
}
