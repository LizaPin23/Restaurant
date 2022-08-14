using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    public void Say(string person, string message)
    {
        Debug.Log($"{person} : {message}");
    }
}
