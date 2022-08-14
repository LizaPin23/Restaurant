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
    public TableState TableState { get; private set; }
    private Coroutine _coroutine;

    public void StopCurrentCoroutine()
    {
        StopCoroutine(_coroutine);
    }

    public void StartTableWork()
    {
        TableState = TableState.Empty;
        StartCoroutine();
    }

    private IEnumerator WaitForPlayerTime()
    {

    }


}
