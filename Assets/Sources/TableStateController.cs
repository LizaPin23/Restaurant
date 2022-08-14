using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStateController : MonoBehaviour
{
    [SerializeField] private TableBubble _bubble;
    [SerializeField] private float _waitFoodTime;
    [SerializeField] private float _prepareTime;
    [SerializeField] private float _waitPlayerTime;
    [SerializeField] private float _emptyTime;
    [SerializeField] private float _eatingTime;
    [SerializeField] private TableAnimator _tableAnimator;

    public TableState TableState { get; private set; }

    private IEnumerator _coroutine;

    public void StopCurrentCoroutine()
    {
        StopCoroutine(_coroutine);
    }

    public void StartTableWork()
    {
        TableState = TableState.Empty;
        _coroutine = WaitForPlayerTime();
        StartCoroutine(_coroutine);
    }

    private IEnumerator WaitForPlayerTime()
    {
        yield return new WaitForSeconds(_emptyTime);
        _tableAnimator.ShowVisitor();
        TableState = TableState.Prepare;
        yield return new WaitForSeconds(_prepareTime);
        TableState = TableState.WaitForPlayer;
        yield return new WaitForSeconds(_waitPlayerTime);
        LeaveTheTable();
    }

    public void LeaveTheTable()
    {
        StopAllCoroutines();
        TableState = TableState.Empty;
        _tableAnimator.HideVisitor();
    }


}
