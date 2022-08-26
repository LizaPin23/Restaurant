using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create game config")]
public class GameConfig : ScriptableObject
{
    [SerializeField] private int _startMoneyAmount = 150;

    public int StartMoneyAmount => _startMoneyAmount;
}