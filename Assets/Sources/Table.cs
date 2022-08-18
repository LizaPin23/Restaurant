using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TableStateController _tableState;


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerFoodHandler player = other.GetComponent<PlayerFoodHandler>();

        if(player == null)
        {
            _tableState.LeaveTheTable();
        }

        if(player == true)
        {
            _tableState.StartWaitFoodCoroutine();
        }


    }
}
