using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TableConfig", menuName = "Create table config")]
public class TableConfig : MonoBehaviour
{
    [SerializeField] private int _minEmptyTime = 1;
    [SerializeField] private int _maxEmptyTime = 3;
    [SerializeField] private int _minPrepareTime = 4;
    [SerializeField] private int _maxPrepareTime = 6;
    [SerializeField] private int _minWaitForPlayerTime = 6;
    [SerializeField] private int _maxWaitForPlayerTime = 10;
    [SerializeField] private int _minWaitForFoodTime = 10;
    [SerializeField] private int _maxWaitForFoodTime = 16;
    [SerializeField] private int _minEatingTime = 3;
    [SerializeField] private int _maxEatingTime = 5;

    public int MinEmptyTime => _minEmptyTime;
    public int MaxEmptyTime => _maxEmptyTime;
    public int MinPrepareTime => _minPrepareTime;
    public int MaxPrepareTime => _maxPrepareTime;
    public int MinWaitForPlayerTime => _minWaitForPlayerTime;
    public int MaxWaitForPlayerTime => _maxWaitForPlayerTime;
    public int MinWaitForFoodTime => _minWaitForFoodTime;
    public int MaxWaitForFoodTime => _maxWaitForFoodTime;
    public int MinEatingTime => _minEatingTime;
    public int MaxEatingTime => _maxEatingTime;
}