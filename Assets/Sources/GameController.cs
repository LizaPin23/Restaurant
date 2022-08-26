using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameConfig _config;
    [SerializeField] private Money _money;
    [SerializeField] private TableController _tableController;

    private void Start()
    {
        _money.Initialize(_config.StartMoneyAmount);
        _tableController.RunTables();
    }
}
