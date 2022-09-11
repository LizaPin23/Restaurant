using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action TimeIsOff;

    public void Run(float targetTime)
    {
        StartCoroutine(RunInternal(targetTime));
    }

    public void Stop()
    {
        StopAllCoroutines();
    }

    private IEnumerator RunInternal(float targetTime)
    {
        for (float i = 0; i < targetTime; i += Time.deltaTime)
        {
            yield return null;
        }

        TimeIsOff?.Invoke();
    }
}
