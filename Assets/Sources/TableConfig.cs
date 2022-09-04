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

    public int GetTimeForState(TableState state)
    {
        switch (state)
        {
            default:
                return GetRandomTime(_minEmptyTime, _maxEmptyTime);
            case TableState.Prepare:
                return GetRandomTime(_minPrepareTime, _maxPrepareTime);
            case TableState.WaitForPlayer:
                return GetRandomTime(_minWaitForPlayerTime, _maxWaitForPlayerTime);
            case TableState.WaitForFood:
                return GetRandomTime(_minWaitForFoodTime, _maxWaitForFoodTime);
            case TableState.Eating:
                return GetRandomTime(_minEatingTime, _maxEatingTime);
        }
    }

    private int GetRandomTime(int min, int max)
    {
        return Random.Range(min, max + 1);
    }
}