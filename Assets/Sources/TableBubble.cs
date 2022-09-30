using UnityEngine;
using UnityEngine.UI;

public class TableBubble : MonoBehaviour
{
    [SerializeField] private Image _foodImage;
    [SerializeField] private Image _stateImage;
    [SerializeField] private Animator _visibleAnimator;
    [SerializeField] private string _animatorBoolName = "Visible";
    [SerializeField] private string _emptyTrigger = "Empty";

    [Header("Icons")] 
    [SerializeField] private Sprite _prepareIcon;
    [SerializeField] private Sprite _waitForPlayerIcon;
    [SerializeField] private Sprite _waitForFoodIcon;
    [SerializeField] private Sprite _eatingIcon;

    public void SetFoodIcon(Sprite icon)
    {
        _foodImage.sprite = icon;
    }

    public void SetTableState(TableState state)
    {
        switch (state)
        {
            case TableState.VisitorLeaving:
                _visibleAnimator.SetBool(_animatorBoolName, false);
                return;
            case TableState.VisitorComing:
                _stateImage.sprite = _prepareIcon;
                _foodImage.sprite = null;
                _visibleAnimator.SetBool(_animatorBoolName, true);
                return;
            case TableState.Prepare:
                _stateImage.sprite = _prepareIcon;
                return;
            case TableState.WaitForPlayer:
                _stateImage.sprite = _waitForPlayerIcon;
                return;
            case TableState.WaitForFood:
                _stateImage.sprite = _waitForFoodIcon;
                return;
            case TableState.Eating:
                _stateImage.sprite = _eatingIcon;
                return;
        }
    }

    public void SetEmpty()
    {
        _visibleAnimator.SetTrigger(_emptyTrigger);
    }
}
