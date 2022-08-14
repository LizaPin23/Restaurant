using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyTextView : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void ShowValue(int value)
    {
        _text.text = value.ToString();
    }
    
}

public class Rectangle
{
    public int ExampleMethod()
    {
        return 0;
    }
}
