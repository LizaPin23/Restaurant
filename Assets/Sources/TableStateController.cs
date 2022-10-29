using System;
using System.Collections.Generic;

public class TableStateController
{
    public event Action<TableState> StateChanged;
    public event Action TableIsDone;
    public event Action ForceLeavingState;

    private readonly List<TableState> _stateChain = new List<TableState>(
        new [] {TableState.Empty, TableState.VisitorComing, TableState.Prepare, TableState.WaitForPlayer,
        TableState.WaitForFood, TableState.Eating, TableState.VisitorLeaving});

    private TableConfig _tableConfig;
    private Timer _timer;
    private int _currentStateIndex;
    private TableState currentState => _stateChain[_currentStateIndex];

    public TableStateController(TableConfig tableConfig, Timer timer)
    {
        _tableConfig = tableConfig;
        _timer = timer;
    }

    public void StartChain()
    {
        _currentStateIndex = 0;
        SetState(_stateChain[_currentStateIndex]);
    }

    public void ForceState(TableState state)
    {
        _currentStateIndex = _stateChain.IndexOf(state);
        _timer.Stop();

        StateChanged?.Invoke(state);
        SetState(state);
    }

    private void OnTimeIsOff()
    {
        _timer.TimeIsOff -= OnTimeIsOff;

        if (currentState == TableState.WaitForFood || currentState == TableState.WaitForPlayer)
        {
            ForceLeavingState?.Invoke();
            ForceState(TableState.VisitorLeaving);
            return;
        }

        TableState nextState = GetNextState();

        if (nextState == TableState.Empty)
        {
            TableIsDone?.Invoke();
            return;
        }

        StateChanged?.Invoke(nextState);
        SetState(nextState);
    }

    private void SetState(TableState state)
    {
        var time = _tableConfig.GetTimeForState(state);
        _timer.Run(time);

        _timer.TimeIsOff += OnTimeIsOff;
    }

    private TableState GetNextState()
    {
        _currentStateIndex++;

        if (_currentStateIndex >= _stateChain.Count)
            _currentStateIndex = 0;

        return _stateChain[_currentStateIndex];
    }
}
