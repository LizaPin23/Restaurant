using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TableBubble : MonoBehaviour
{
    [SerializeField] private Image _foodIcon;
    [SerializeField] private Animator _animator;
    [SerializeField] private string _stateIndexName = "BubbleState";
    public void BubbleEmpty()
    {
        _animator.SetInteger(_stateIndexName, 0);
    }

    public void BubblePrepare()
    {
        _animator.SetInteger(_stateIndexName, 1);
    }

    public void BubbleWaitForPlayer()
    {
        _animator.SetInteger(_stateIndexName, 2);
    }

    public void BubbleWaitForFood(Sprite icon)
    {
        _animator.SetInteger(_stateIndexName, 3);
        _foodIcon.sprite = icon;
    }

    public void BubbleEating()
    {
        _animator.SetInteger(_stateIndexName, 4);
    }
}
