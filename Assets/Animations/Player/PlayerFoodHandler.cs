using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodHandler : MonoBehaviour
{
    [SerializeField] private Money _money;

    public Food CurrentFood { get; private set; }
    public bool HasFood => CurrentFood != null;

    public bool TryGetFoodFromKitchen(Food food)
    {
        bool hasMoney = _money.TryDecrease(food.KitchenPrice);

        if (hasMoney)
        {
            CurrentFood = food;
        }
        else
        {
            Debug.Log("Не хватает денег!");
        }

        return hasMoney;
    }

    public bool TryServeFood(Food expectedFood)
    {
        var result = expectedFood.Type == CurrentFood.Type;
        CurrentFood = null;
        return result;
    }
}