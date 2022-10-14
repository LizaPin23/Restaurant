using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public event Action QuitButtonPressed;
    public event Action ContinueButtonPressed;
    public event Action PauseButtonPressed;

    private void Awake()
    {
        SetVisible(false);
    }

    public void SetVisible(bool value)
    {
        gameObject.SetActive(value);
    }

    public void OnQuitButtonPressed()
    {
        QuitButtonPressed?.Invoke();
    }

    public void OnContinueButtonPressed()
    {
        ContinueButtonPressed?.Invoke();
    }
}
