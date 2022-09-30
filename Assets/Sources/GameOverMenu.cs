using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MonoBehaviour
{
    public event Action QuitButtonPressed;
    public event Action RetryButtonPressed;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnQuitButtonPressed()
    {
        QuitButtonPressed?.Invoke();
    }

    public void OnRetryButtonPressed()
    {
        RetryButtonPressed?.Invoke();
    }
}
