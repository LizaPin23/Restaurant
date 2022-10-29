using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private Table[] _tables;
    [SerializeField] private Menu _menu;
    [SerializeField] private int _activeTables = 2;

    public event Action VisitorFailed;
    public event Action<int> MoneyAdded;


    private List<Table> _emptyTables;

    public void Initialize(TableConfig tableConfig)
    {
        for (int i = 0; i < _tables.Length; i++)
        {
            Table table = _tables[i];
            table.Initialize(_menu, tableConfig);
            table.VisitorLeft += TableOnVisitorLeft;
            table.OrderServed += TableOnOrderServed;
        }
    }

    private void TableOnOrderServed(Food food)
    {
        MoneyAdded?.Invoke(food.TablePrice);
    }

    private void TableOnVisitorLeft()
    {
        VisitorFailed?.Invoke();
    }

    public void RunTables()
    {
        ClearTables();
        _emptyTables = new List<Table>(_tables);

        for (int i = 0; i < _activeTables; i++)
        {
            RunRandomTable();
        }
    }

    private void ClearTables()
    {
        for (int i = 0; i < _tables.Length; i++)
        {
            Table table = _tables[i];
            table.Clear();
        }
    }

    private void RunRandomTable()
    {
        if (_emptyTables.Count == 0)
            return;

        int index = UnityEngine.Random.Range(0, _emptyTables.Count);
        Table table = _emptyTables[index];
        _emptyTables.RemoveAt(index);
        table.StartWork();
        table.IsDone += OnTableIsDone;
    }

    private void OnTableIsDone(Table table)
    {
        table.IsDone -= OnTableIsDone;
        _emptyTables.Add(table);
        RunRandomTable();
    }
}
