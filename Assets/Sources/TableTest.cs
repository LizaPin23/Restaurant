using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableTest : MonoBehaviour
{
    [SerializeField] private VisitorController _visitorController;
    [SerializeField] private TableAnimator _tableAnimator;
    [SerializeField] private ParticleSystem _effect;
    void Start()
    {
        _visitorController.SetRandomVisitor();
        _tableAnimator.ShowVisitor();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            _tableAnimator.HideVisitor();
            _effect.Play();
        }
    }


}
