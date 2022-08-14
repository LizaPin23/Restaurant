using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string _stateIndexName = "MoveState";

    private Vector3 _up = Vector3.up;

    public void ShowMovement(Vector3 movement)
    {
        float x = movement.x;
        float y = movement.y;

        if (movement.magnitude < 0.1f)
        {
            ShowIdle();
            return;
        }

        if (x > 0)
        {
            MoveRight();
            return;
        }

        if (x < 0)
        {
            MoveLeft();
            return;
        }

        if (y > 0)
        {
            MoveUp();
            return;
        }

        if (y < 0)
        {
            MoveDown();
            return;
        }
    }

    private void ShowIdle()
    {
        _animator.SetInteger(_stateIndexName, 0);
    }

    private void MoveDown()
    {
        _animator.SetInteger(_stateIndexName, 2);
    }

    private void MoveUp()
    {
        _animator.SetInteger(_stateIndexName, 4);
    }

    private void MoveLeft()
    {
        _animator.SetInteger(_stateIndexName, 1);
    }

    private void MoveRight()
    {
        _animator.SetInteger(_stateIndexName, 3);
    }
}
