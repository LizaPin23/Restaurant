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
        gameObject.SetActive(false);
    }

    public void PauseButton()
    {
        PauseButtonPressed?.Invoke();
    }

    public void ShowPause()
    {
        gameObject.SetActive(true);
    }

    public void HidePause()
    {
        gameObject.SetActive(false);
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
