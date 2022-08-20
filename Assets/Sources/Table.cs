using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TableState _tableState;
    [SerializeField] private TableStateController _tableStateController;


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerFoodHandler player = other.GetComponent<PlayerFoodHandler>();


        switch(_tableState)
        {
            default:
                return;
            case TableState.WaitForPlayer:
                _tableStateController.StartWaitFoodCoroutine();
            case TableState.WaitForFood:
                _tableStateController.StartEatingCoroutine();

        }
    }
}
