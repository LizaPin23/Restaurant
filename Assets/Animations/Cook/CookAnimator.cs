using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CookAnimator : MonoBehaviour
{

    [SerializeField] private Animator _animatorCook;
    [SerializeField] private string _moveBoolName;

    public void Idle()
    {
        _animatorCook.SetBool(_moveBoolName, false);
    }

    public void Move()
    {
        _animatorCook.SetBool(_moveBoolName, true);
    }

}


