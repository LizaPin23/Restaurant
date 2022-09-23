using System;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TableBubble _bubble;
    [SerializeField] private TableAnimator _animator;
    [SerializeField] private Timer _timer;

    public event Action<Table> IsDone;
    public event Action VisitorLeft;

    private TableStateController _tableStateController;
    private Menu _menu;
    private Food _currentOrder;
    private TableState _currentState;

    public void Initialize(Menu menu, TableConfig tableConfig)
    {
        _menu = menu;
        _tableStateController = new TableStateController(tableConfig, _timer);
        _tableStateController.StateChanged += OnTableStateChanged;
    }

    public void StartWork()
    {
        _tableStateController.StartChain();
    }

    private void OnTableStateChanged(TableState state)
    {
        _bubble.SetTableState(state);

        if (state == TableState.Empty && _currentState == TableState.VisitorLeaving)
        {
            IsDone?.Invoke(this);

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

        bool isFoodCorrect = player.TryServeFood(_currentOrder);

        if (isFoodCorrect)
        {
            Debug.Log("Правильная еда");
            _tableStateController.ForceState(TableState.Eating);
        }
        else
        {
            Debug.Log("Неправильная еда");

            _tableStateController.ForceState(TableState.VisitorLeaving);
            VisitorLeft?.Invoke();
        }
    }
}
