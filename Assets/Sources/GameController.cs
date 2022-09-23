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

    public event Action<bool> OnPauseChanged;

    private bool _pause;

    private void Awake()
    {
        _inputController.ImputMovement += _movementPlayer.Move;
        _tableController.VisitorLeft += _money.VisitorDecrease;
        _money.GameOver += OnGameOver;
        _inputController.ButtonEscapePressed += OnEscapePressed;
    }

    private void Start()
    {
        _money.Initialize(_config.StartMoneyAmount, _config.MoneyDecreaseAmount);
        _tableController.RunTables(_config.TableConfig);
    }

    private void OnEscapePressed()
    {
        _pause = !_pause;

       if(_pause)
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
        Debug.Log("Game over");
    }
}
