using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private int _startMoneyAmount = 150;
    [SerializeField] private int _decrease = 50;
    [SerializeField] private TableConfig _tableConfig;

    public int StartMoneyAmount => _startMoneyAmount;

    public int TryDecrease => _decrease;

    public TableConfig TableConfig => _tableConfig;
}