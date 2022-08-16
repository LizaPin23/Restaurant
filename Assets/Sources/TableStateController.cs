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

    private IEnumerator WaitForFoodTime()
    {
        //оно включается с помощью метода СтартВейтФудКорутин
        TableState = TableState.WaitForFood;
        yield return new WaitForSeconds(_waitFoodTime);
        LeaveTheTable();
    }

    private IEnumerator EatingTime()
    {
        //оно включается с помощью метода СтартИтингКорутин
        TableState = TableState.Eating;
        yield return new WaitForSeconds(_eatingTime);
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


}
