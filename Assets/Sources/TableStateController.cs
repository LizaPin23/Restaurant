using System;
using System.Collections.Generic;

public class TableStateController
{
    public event Action<TableState> StateChanged;
    
    private readonly List<TableState> _stateChain = new List<TableState>(
        new [] {TableState.Empty, TableState.VisitorComing, TableState.Prepare, TableState.WaitForPlayer,
        TableState.WaitForFood, TableState.Eating, TableState.VisitorLeaving});

    private TableConfig _tableConfig;
    private Timer _timer;
    private int _currentStateIndex;

    public TableStateController(TableConfig tableConfig, Timer timer)
    {
        _tableConfig = tableConfig;
        _timer = timer;
        _timer.TimeIsOff += OnTimeIsOff;
    }

    public void StartChain()
    {
        _currentStateIndex = 0;
        SetStateAndWait(_stateChain[_currentStateIndex]);
    }

    public void ForceState(TableState state)
    {
        _currentStateIndex = _stateChain.IndexOf(state);
        _timer.Stop();
        TableState nextState = _stateChain[_currentStateIndex];
        SetStateAndWait(nextState);
    }

    private void OnTimeIsOff()
    {
        TableState currentState = _stateChain[_currentStateIndex];

        if (currentState == TableState.WaitForFood || currentState == TableState.WaitForPlayer)
        {
            ForceState(TableState.VisitorLeaving);
            return;
        }

        TableState nextState = GetNextState();
        SetStateAndWait(nextState);
    }

    private void SetStateAndWait(TableState state)
    {
        StateChanged?.Invoke(state);
        var time = _tableConfig.GetTimeForState(state);
        _timer.Run(time);
    }

    private TableState GetNextState()
    {
        _currentStateIndex++;

        if (_currentStateIndex >= _stateChain.Count)
            _currentStateIndex = 0;

        return _stateChain[_currentStateIndex];
    }
}
