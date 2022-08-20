using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private FoodConfig[] _foodConfigs;

    public Food GetRandomFood()
    {
        int index = Random.Range(0, _foodConfigs.Length);
        FoodConfig config = _foodConfigs[index];
        return new Food(config);
    }
}
