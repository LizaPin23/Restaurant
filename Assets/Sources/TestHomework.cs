using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHomework : MonoBehaviour
{
    [SerializeField] private int _scaleIncrease = 0;
    [SerializeField] private float _second = 1f;

    private void Start()
    {
        StartCoroutine(nameof(Scale));
    }
    private IEnumerator Scale()
    {
        while(_scaleIncrease < 5)
        {
           yield return new WaitForSeconds(_second);
           _scaleIncrease = _scaleIncrease + 1;
           Debug.Log(_scaleIncrease);
            transform.localScale = new Vector3(_scaleIncrease, _scaleIncrease , _scaleIncrease );
        }
        
    }
}
