using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private Table[] _tables;
    [SerializeField] private Menu _menu;
    [SerializeField] private TableStateController _tableStateController;

    void Start()
    {
        _tableStateController.StartTableWork();
    }
}
