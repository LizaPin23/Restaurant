using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableAnimator : MonoBehaviour
{
    [SerializeField] private Animator _tableAnimator;

    [SerializeField] private string _boolName = "VisitorBool";
    [SerializeField] private string _boolNameThree = "VisitorBoolThree";
    [SerializeField] private string _boolNameTwo = "TwoBool";
    [SerializeField] private string _boolNameFour = "FourBool";

    public void ShowVisitor()
    {
        _tableAnimator.SetBool(_boolName, true);
        _tableAnimator.SetBool(_boolNameThree, true);
        _tableAnimator.SetBool(_boolNameTwo, true);
        _tableAnimator.SetBool(_boolNameFour, true);
    }

    public void HideVisitor()
    {
        _tableAnimator.SetBool(_boolName, false);
        _tableAnimator.SetBool(_boolNameThree, false);
        _tableAnimator.SetBool(_boolNameTwo, false);
        _tableAnimator.SetBool(_boolNameFour, false);
    }

    public void SitVisitor()
    {

    }
}
