using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private int _iceCreamPrice = 200;
    [SerializeField] private int _pizzaPrice = 400;
    [SerializeField] private int _iceCreamCost = 50;
    [SerializeField] private int _pizzaCost = 100;

    public int GetPrice(FoodType type)
    {
        switch (type)
        {
            default:
                return 0;
            case FoodType.IceCream:
                return _iceCreamPrice;
            case FoodType.Pizza:
                return _pizzaPrice;

        }
    }
    public int GetCost(FoodType type)
    {
        switch (type)
        {
            default:
                return 0;
            case FoodType.IceCream:
                return _iceCreamCost;
            case FoodType.Pizza:
                return _pizzaCost;

        }
    }
}
