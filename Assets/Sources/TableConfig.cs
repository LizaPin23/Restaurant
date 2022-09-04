using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TableConfig", menuName = "Create table config")]
public class TableConfig : ScriptableObject
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

    public int GetEmptyTime()
    {
        return Random.Range(_minEmptyTime, _maxEmptyTime + 1);
    }

    public int GetPrepareTime()
    {
        return Random.Range(_minPrepareTime, _maxPrepareTime + 1);
    }

    public int GetWaitPlayerTime()
    {
        return Random.Range(_minWaitForPlayerTime, _maxWaitForPlayerTime + 1);
    }

    public int GetWaitFoodTime()
    {
        return Random.Range(_minWaitForFoodTime, _maxWaitForFoodTime + 1);
    }

    public int GetEatingTime()
    {
        return Random.Range(_minEatingTime, _maxEatingTime + 1);
    }
}