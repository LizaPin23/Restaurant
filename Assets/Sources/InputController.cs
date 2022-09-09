using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] private float _speed = 5f;
    [SerializeField] private PlayerAnimation _animator;
    private PlayerMovement _movement { get; private set;}

    public event Action<Vector3 movement> ImputMovement;

    public void ImputControllerMovement(PlayerMovement _movement)
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX, inputY);
        ImputMovement?.Invoke(movement);
    }
}
