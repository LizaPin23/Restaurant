﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private Table[] _tables;
    [SerializeField] private Menu _menu;

    public void RunTables(TableConfig tableConfig)
    {
        for(int i = 0; i < _tables.Length; i++)
        {
            _tables[i].StartWork(_menu, tableConfig);
        }
    }
}
