using System;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public struct RangeFloat
{
    [SerializeField] private float _min;
    [SerializeField] private float _max;

    public float Max => _max;
    public float Min => _min;

    public float GetRandom()
    {
        return Random.Range(_min, _max);
    }
}
