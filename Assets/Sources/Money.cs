﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    [SerializeField] private MoneyTextView _view;

    private int _value;

    public void Increase(int value)
    {
        if (value < 0)
        {
            return;
        }

        _value += value;
    }

    public bool TryDecrease(int value)
    {
        if (value < 0) return false;
        if (_value < value) return false;

        _value -= value;
        _view.ShowValue(_value);
        return true;
    }
}
