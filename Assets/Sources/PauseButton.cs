using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public event Action Pressed;

    public void SetVisible(bool value)
    {
        gameObject.SetActive(value);
    }

    public void OnPress()
    {
        Pressed?.Invoke();
    }
}
