using UnityEngine;

[CreateAssetMenu(fileName = "TableConfig", menuName = "Create table config")]
public class TableConfig : ScriptableObject
{
    [SerializeField] private int _minEmptyTime = 1;
    [SerializeField] private int _maxEmptyTime = 3;
    [SerializeField] private int _minPrepareTime = 4;
    [SerializeField] private int _maxPrepareTime = 6;
    [SerializeField] private int _waitForPlayerTime = 6;
    [SerializeField] private int _waitForFoodTime = 10;
    [SerializeField] private int _minEatingTime = 3;
    [SerializeField] private int _maxEatingTime = 5;

    [Header("Animation durations")] 
    [SerializeField] private int _visitorComingDuration = 2;
    [SerializeField] private int _visitorLeavingDuration = 2;

    public int GetTimeForState(TableState state)
    {
        switch (state)
        {
            default:
                return GetRandomTime(_minEmptyTime, _maxEmptyTime);
            case TableState.Prepare:
                return GetRandomTime(_minPrepareTime, _maxPrepareTime);
            case TableState.WaitForPlayer:
                return _waitForPlayerTime;
            case TableState.WaitForFood:
                return _waitForFoodTime;
            case TableState.Eating:
                return GetRandomTime(_minEatingTime, _maxEatingTime);
            case TableState.VisitorComing:
                return _visitorComingDuration;
            case TableState.VisitorLeaving:
                return _visitorLeavingDuration;
        }
    }

    private int GetRandomTime(int min, int max)
    {
        return Random.Range(min, max + 1);
    }
}