using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionsTest
{
    private List<Sample> _samplesList;

    public CollectionsTest(Sample[] sample)
    {
        _samplesList = new List<Sample>(sample);
    }

    public void Sort(List<Sample> list)
    {

    }

    public void Show()
    {
        for (int i = 0; i < _samplesList.Count; i++)
        {
            Debug.Log(_samplesList[i].Number);
        }
    }
}
