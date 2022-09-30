using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAnimator : MonoBehaviour
{
    [SerializeField] private Animator _tableAnimator;
    [SerializeField] private string _visibleParam = "Visible";

    public void ShowVisitor()
    {
        _tableAnimator.SetBool(_visibleParam, true);
    }

    public void HideVisitor()
    {
        _tableAnimator.SetBool(_visibleParam, false);
    }
}
