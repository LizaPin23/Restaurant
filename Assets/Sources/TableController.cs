using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private Table[] _tables;
    [SerializeField] private Menu _menu;
    [SerializeField] private int _activeTables = 2;

    public event Action VisitorLeft;

    private List<Table> _emptyTables;

    private void OnVisitorLeft()
    {
        VisitorLeft?.Invoke();
    }

    public void RunTables(TableConfig tableConfig)
    {
        _emptyTables = new List<Table>(_tables);

        for(int i = 0; i < _tables.Length; i++)
        {
            Table table = _tables[i];
            table.Initialize(_menu, tableConfig);
            table.IsDone += OnTableIsDone;
            table.VisitorLeft += OnVisitorLeft;
        }

        for (int i = 0; i < _activeTables; i++)
        {
            RunRandomTable();
        }
    }

    private void RunRandomTable()
    {
        int index = UnityEngine.Random.Range(0, _emptyTables.Count);
        Table table = _emptyTables[index];
        _emptyTables.RemoveAt(index);
        table.StartWork();
    }

    private void OnTableIsDone(Table table)
    {
        _emptyTables.Add(table);
        RunRandomTable();
    }
}
