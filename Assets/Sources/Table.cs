using System;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TableBubble _bubble;
    [SerializeField] private TableAnimator _animator;
    [SerializeField] private Timer _timer;
    [SerializeField] private ParticleSystem _moneyEffect;

    public event Action<Table, bool> IsDone;

    private TableStateController _tableStateController;
    private Menu _menu;
    private Food _currentOrder;
    private TableState _currentState;
    private bool _correctFood;

    public void Initialize(Menu menu, TableConfig tableConfig)
    {
        _menu = menu;
        _tableStateController = new TableStateController(tableConfig, _timer);
        
    }

    public void StartWork()
    {
        _tableStateController.StateChanged += OnTableStateChanged;
        _correctFood = false;
        _tableStateController.StartChain();
    }

    public void Clear()
    {
        _currentState = TableState.Empty;
        _animator.SetEmpty();
        _bubble.SetEmpty();
        _tableStateController.StateChanged -= OnTableStateChanged;
        _tableStateController.StopChain();
    }

    private void OnTableStateChanged(TableState state)
    {
        _bubble.SetTableState(state);

        if (state == TableState.Empty && _currentState == TableState.VisitorLeaving)
        {
            IsDone?.Invoke(this, _correctFood);
        }

        _currentState = state;

        switch (state)
        {
            case TableState.VisitorComing:
                _animator.ShowVisitor();
                break;
            case TableState.VisitorLeaving:
                _animator.HideVisitor();
                break;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerFoodHandler player = other.gameObject.GetComponent<PlayerFoodHandler>();

        if (player == null)
            return;

        switch (_currentState)
        {
            default:
                return;
            case TableState.WaitForPlayer:
                CreateOrder();
                break;
            case TableState.WaitForFood:
                ServeFoodFrom(player);
                break;
        }
    }

    private void CreateOrder()
    {
        _currentOrder = _menu.GetRandomFood();
        _bubble.SetFoodIcon(_currentOrder.Icon);
        _tableStateController.ForceState(TableState.WaitForFood);
    }

    private void ServeFoodFrom(PlayerFoodHandler player)
    {
        if (player.HasFood == false)
            return;

        _correctFood = player.TryServeFood(_currentOrder);

        if (_correctFood)
        {
            _moneyEffect.Play();
            _tableStateController.ForceState(TableState.Eating);
        }
        else
        {
            _tableStateController.ForceState(TableState.VisitorLeaving);
        }
    }
}
