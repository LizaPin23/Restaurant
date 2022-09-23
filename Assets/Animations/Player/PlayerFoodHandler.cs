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
        bool hasMoney = _money.Decrease(food.KitchenPrice);

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
        if (expectedFood.Type == CurrentFood.Type)
        {
            Debug.Log("Должны получить деньги");
            _money.Increase(expectedFood.TablePrice);
            CurrentFood = null;
            return true;
        }

        CurrentFood = null;
        return false;
    }

    public bool UnHappyVisitor(TableStateController visitorRunning)
    {
        if ()
    }

}