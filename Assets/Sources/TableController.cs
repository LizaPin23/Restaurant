using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableController : MonoBehaviour
{
    [SerializeField] private Table[] _tables;
    [SerializeField] private Menu _menu;
    [SerializeField] private int _activeTables = 2;

    private List<Table> _emptyTables;

    public void RunTables(TableConfig tableConfig)
    {
        _emptyTables = new List<Table>(_tables);

        for(int i = 0; i < _tables.Length; i++)
        {
            Table table = _tables[i];
            table.Initialize(_menu, tableConfig);
            table.IsDone += OnTableIsDone;
        }

        for (int i = 0; i < _activeTables; i++)
        {
            RunRandomTable();
        }
    }

    private void RunRandomTable()
    {
        int index = Random.Range(0, _emptyTables.Count);
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
