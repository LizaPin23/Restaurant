using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameConfig _config;
    [SerializeField] private Money _money;
    [SerializeField] private TableController _tableController;
    [SerializeField] private InputController _inputController;
    [SerializeField] private PlayerMovement _movementPlayer;

    [Header("Menus")] 
    [SerializeField] private GameOverMenu _gameOverMenu;
    [SerializeField] private PauseMenu _pauseMenu;
    [SerializeField] private PauseButton _pauseButton;

    public event Action<bool> OnPauseChanged;

    private bool _pause;

    private void Awake()
    {
        _money.Initialize(_config.StartMoneyAmount, _config.MoneyDecreaseAmount);
        _tableController.Initialize(_config.TableConfig);

        _inputController.ImputMovement += _movementPlayer.Move;
        _tableController.VisitorFailed += _money.VisitorDecrease;
        _money.GameOver += OnGameOver;

        _gameOverMenu.QuitButtonPressed += OnQuitButtonPressed;
        _gameOverMenu.RetryButtonPressed += OnRetryButtonPressed;

        _pauseMenu.QuitButtonPressed += OnQuitButtonPressed;
        _pauseMenu.ContinueButtonPressed += OnContinueButtonPressed;
        _pauseMenu.PauseButtonPressed += OnPausePressed;

        _inputController.ButtonEscapePressed += OnPausePressed;
        _pauseButton.Pressed += OnPausePressed;
    }

    private void Start()
    {
        DoPause(false);
        StartGame();
    }

    private void OnPausePressed()
    {
        DoPause(!_pause);
    }

    private void DoPause(bool value)
    {
        SetPaused(value);
        _pauseButton.SetVisible(!_pause);
        _pauseMenu.SetVisible(_pause);
    }

    private void SetPaused(bool value)
    {
        _pause = value;

        if (_pause)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }

        OnPauseChanged?.Invoke(_pause);
    }

    private void OnGameOver()
    {
        SetPaused(true);
        _gameOverMenu.Show();
    }

    private void OnQuitButtonPressed()
    {
        Application.Quit();
    }

    private void OnRetryButtonPressed()
    {
        _gameOverMenu.Hide();
        SetPaused(false);
        StartGame();
    }

    private void OnContinueButtonPressed()
    {
        DoPause(false);
    }

    private void StartGame()
    {
        _tableController.RunTables();
        _money.StartWork();
        //появляется кнопка
    }
}
