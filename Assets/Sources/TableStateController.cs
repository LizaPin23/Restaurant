using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStateController : MonoBehaviour
{
    [SerializeField] private TableBubble _bubble;
    [SerializeField] private TableAnimator _tableAnimator;

    public TableState TableState { get; private set; }

    public event Action<TableState> TableStateChanged;

    private TableConfig _tableConfig;

    private IEnumerator _coroutine;

    public void StopCurrentCoroutine()
    {
        StopCoroutine(_coroutine);
    }

    public void SetConfig(TableConfig tableConfig)
    {
        _tableConfig = tableConfig;
    }

    public void StartTableWork()
    {
        _bubble.BubbleEmpty();
        _coroutine = WaitForPlayerTime();
        StartCoroutine(_coroutine);
    }

    private IEnumerator WaitForPlayerTime()
    {
        yield return WaitInState(TableState.Empty);

        _bubble.BubblePrepare();
        _tableAnimator.ShowVisitor();
        yield return WaitInState(TableState.Prepare);

        _bubble.BubbleWaitForPlayer();
        yield return WaitInState(TableState.WaitForPlayer);

        LeaveTheTable();
    }

    private IEnumerator WaitForFoodTime()
    {
        yield return WaitInState(TableState.WaitForFood);
        LeaveTheTable();
    }

    private IEnumerator EatingTime()
    {
        yield return WaitInState(TableState.Eating);
        LeaveTheTable();
    }

    public void LeaveTheTable()
    {
        StopAllCoroutines();
        TableState = TableState.Empty;
        _tableAnimator.HideVisitor();
    }

    public void StartWaitFoodCoroutine()
    {
        _coroutine = WaitForFoodTime();
        StartCoroutine(_coroutine);
    }

    public void StartEatingCoroutine()
    {
        _coroutine = EatingTime();
        StartCoroutine(_coroutine);
    }

    private IEnumerator WaitInState(TableState state)
    {
        TableState = state;
        TableStateChanged?.Invoke(state);
        int time = _tableConfig.GetTimeForState(state);
        yield return new WaitForSeconds(time);
    }

}
