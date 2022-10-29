using System;
using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TableBubble _bubble;
    [SerializeField] private TableAnimator _animator;
    [SerializeField] private Timer _timer;
    [SerializeField] private ParticleSystem _moneyEffect;
    [SerializeField] private AudioSource _audio;

    public event Action<Table> IsDone;
    public event Action VisitorLeft;
    public event Action<Food> OrderServed;

    private TableStateController _tableStateController;
    private Menu _menu;
    private Food _currentOrder;
    private TableState _currentState;

    public void Initialize(Menu menu, TableConfig tableConfig)
    {
        _menu = menu;
        _tableStateController = new TableStateController(tableConfig, _timer);
    }

    public void StartWork()
    {
        _tableStateController.StartChain();
        _tableStateController.StateChanged += OnTableStateChanged;
        _tableStateController.TableIsDone += OnTableIsDone;
        _tableStateController.ForceLeavingState += OnVisitorLeft;
    }

    private void OnVisitorLeft()
    {
        VisitorLeft?.Invoke();
        _audio.Play();
    }

    private void OnTableIsDone()
    {
        IsDone?.Invoke(this);
        _animator.SetEmpty();
        _bubble.SetEmpty();
    }

    public void Clear()
    {
        _animator.SetEmpty();
        _bubble.SetEmpty();
        _timer.Stop();
    }

    private void OnTableStateChanged(TableState state)
    {
        _bubble.SetTableState(state);
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

        var correctFoodServed = player.TryServeFood(_currentOrder);

        if (correctFoodServed)
        {
            _moneyEffect.Play();
            _tableStateController.ForceState(TableState.Eating);
            OrderServed?.Invoke(_currentOrder);
        }
        else
        {
            _tableStateController.ForceState(TableState.VisitorLeaving);
            OnVisitorLeft();
        }
    }
}
