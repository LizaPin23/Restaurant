using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private PlayerAnimation _animator;

    public void Move(Vector3 movement)
    {
        _animator.ShowMovement(movement);
        transform.Translate(movement * Time.deltaTime * _speed);
    }
}
