using UnityEngine;

public class Table : MonoBehaviour
{
    [SerializeField] private TableBubble _bubble;
    [SerializeField] private TableStateController _tableStateController;

    private Menu _menu;
    private Food _currentOrder;

    private void Awake()
    {
        _tableStateController.TableStateChanged += OnTableStateChanged;
    }

    private void OnTableStateChanged(TableState state)
    {
        Debug.Log(gameObject.name + " " + state);

        if (state == TableState.Empty)
        {
            _tableStateController.StartTableWork();
        }
    }

    public void StartWork(Menu menu, TableConfig tableConfig)
    {
        _tableStateController.SetConfig(tableConfig);
        _tableStateController.StartTableWork();
        _menu = menu;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        PlayerFoodHandler player = other.gameObject.GetComponent<PlayerFoodHandler>();

        if (player == null)
            return;

        switch (_tableStateController.TableState)
        {
            default:
                return;
            case TableState.WaitForPlayer:
                OnWaitForPlayer();
                break;
            case TableState.WaitForFood:
                OnWaitForFood(player);
                break;

        }
    }

    private void OnWaitForPlayer()
    {
        _tableStateController.StopCurrentCoroutine();

        _currentOrder = _menu.GetRandomFood();

        _tableStateController.StartWaitFoodCoroutine();
        _bubble.BubbleWaitForFood(_currentOrder.Icon);
    }

    private void OnWaitForFood(PlayerFoodHandler player)
    {
        if (player.HasFood == false)
            return;

        _tableStateController.StopCurrentCoroutine();
        
        bool isFoodCorrect = player.TryServeFood(_currentOrder);

        if (isFoodCorrect)
        {
            Debug.Log("Правильная еда");
            _tableStateController.StartEatingCoroutine();
        }
        else
        {
            Debug.Log("Неправильная еда");

            _tableStateController.LeaveTheTable();
        }
    }
}
