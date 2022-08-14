using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEnvironment : MonoBehaviour
{

    void Start()
    {
        Sample[] samples = new[]
        {
            new Sample(9),
            new Sample(3),
            new Sample(5),
            new Sample(4)
        };

        CollectionsTest collections = new CollectionsTest(samples);
        collections.Show();
    }
}
