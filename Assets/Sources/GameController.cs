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

    public event Action<bool> OnPauseChanged;

    private bool _pause;

    private void Awake()
    {
        _money.Initialize(_config.StartMoneyAmount, _config.MoneyDecreaseAmount);
        _tableController.Initialize(_config.TableConfig);

        _inputController.ImputMovement += _movementPlayer.Move;
        _tableController.VisitorFailed += _money.VisitorDecrease;
        _money.GameOver += OnGameOver;
        _inputController.ButtonEscapePressed += OnEscapePressed;
        _gameOverMenu.QuitButtonPressed += OnQuitButtonPressed;
        _gameOverMenu.RetryButtonPressed += OnRetryButtonPressed;
        _pauseMenu.QuitButtonPressed += OnQuitButtonPressed;
        _pauseMenu.ContinueButtonPressed += OnContinueButtonPressed;
        _pauseMenu.PauseButtonPressed += OnPauseButtonPressed;
    }

    private void Start()
    {
        StartGame();
    }

    private void OnEscapePressed()
    {
        SetPaused(!_pause);
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

    private void OnPauseButtonPressed()
    {
        SetPaused(true);
        _pauseMenu.PauseButton();
    }

    private void OnRetryButtonPressed()
    {
        _gameOverMenu.Hide();
        SetPaused(false);
        StartGame();
    }

    private void OnContinueButtonPressed()
    {
        _pauseMenu.HidePause();
        SetPaused(false);
        StartGame();
    }

    private void StartGame()
    {
        _tableController.RunTables();
        _money.StartWork();
        //появляется кнопка
    }
}
