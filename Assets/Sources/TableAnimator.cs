using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAnimator : MonoBehaviour
{
    [SerializeField] private Animator _tableAnimator;
    [SerializeField] private string _visibleParam = "Visible";
    [SerializeField] private string _emptyTrigger = "Empty";

    public void ShowVisitor()
    {
        _tableAnimator.SetBool(_visibleParam, true);
    }

    public void HideVisitor()
    {
        _tableAnimator.SetBool(_visibleParam, false);
    }

    public void SetEmpty()
    {
        _tableAnimator.SetTrigger(_emptyTrigger);
    }
}
