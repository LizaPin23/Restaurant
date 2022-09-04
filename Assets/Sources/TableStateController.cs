using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableStateController : MonoBehaviour
{
    [SerializeField] private TableBubble _bubble;
    [SerializeField] private TableAnimator _tableAnimator;

    public TableState TableState { get; private set; }

    private TableConfig _tableConfig;

    private IEnumerator _coroutine;

    public void StopCurrentCoroutine()
    {
        StopCoroutine(_coroutine);
    }

    public void StartTableWork(TableConfig tableConfig)
    {
        TableState = TableState.Empty;
        _tableConfig = tableConfig;
        _bubble.BubbleEmpty();
        _coroutine = WaitForPlayerTime();
        StartCoroutine(_coroutine);
    }

    private IEnumerator WaitForPlayerTime()
    {
        yield return new WaitForSeconds(_tableConfig.GetEmptyTime());
        _bubble.BubblePrepare();
        _tableAnimator.ShowVisitor();
        TableState = TableState.Prepare;
        yield return new WaitForSeconds(_tableConfig.GetPrepareTime());
        _bubble.BubbleWaitForPlayer();
        TableState = TableState.WaitForPlayer;
        yield return new WaitForSeconds(_tableConfig.GetWaitPlayerTime());
        LeaveTheTable();
    }

    private IEnumerator WaitForFoodTime()
    {
        //оно включается с помощью метода СтартВейтФудКорутин
        TableState = TableState.WaitForFood;
        yield return new WaitForSeconds(_tableConfig.GetWaitFoodTime());
        LeaveTheTable();
    }

    private IEnumerator EatingTime()
    {
        //оно включается с помощью метода СтартИтингКорутин
        TableState = TableState.Eating;
        yield return new WaitForSeconds(_tableConfig.GetEatingTime());
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
