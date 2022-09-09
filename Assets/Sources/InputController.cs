using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    public event Action<Vector3> ImputMovement;
    public event Action ButtonEscapePressed; 

    private void Update()
    {
        GetMovementVector();
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ButtonEscapePressed?.Invoke();
        }
    }

    private void GetMovementVector()
    {
        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(inputX, inputY);
        ImputMovement?.Invoke(movement);
    }
}
