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

    private void Awake()
    {
        _inputController.ImputMovement += _movementPlayer.Move;
    }

    private void Start()
    {
        _money.Initialize(_config.StartMoneyAmount);
        //_tableController.RunTables(_config.TableConfig);
    }
}
