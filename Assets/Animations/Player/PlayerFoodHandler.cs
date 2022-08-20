using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodHandler : MonoBehaviour
{
    [SerializeField] private Money _money;

    public Food CurrentFood { get; private set; }
    public bool HasFood => CurrentFood != null;

    public void GetFoodFromKitchen(Food food)
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
    }

    public bool TryServeFood(Food expectedFood)
    {
        if (expectedFood.Type == CurrentFood.Type)
        {
            _money.Increase(expectedFood.TablePrice);
            CurrentFood = null;
            return true;
        }

        CurrentFood = null;
        return false;
    }

}