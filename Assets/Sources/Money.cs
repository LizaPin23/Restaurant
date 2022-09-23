using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private MoneyTextView _view;

    private int _value;

    public void Initialize(int startAmount)
    {
        _value = startAmount;
        _view.ShowValue(_value);
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
        //тут надо
        if (value < 0) return false;
        if (_value < value) return false;

        _value -= value;
        _view.ShowValue(_value);
        return true;
    }

    public bool Decrease(int value)
    {
        if (value < 0)
        {
            return false;
        }

        _value -= value;
        _view.ShowValue(_value);
        return true;
    }
}
