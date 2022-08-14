using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFoodHandler : MonoBehaviour
{
    private FoodType _food = FoodType.None;

    public void BringFood(FoodType food)
    {
        _food = food;
        Debug.Log(food);
    }

    public Food ServeFood()
    {
        FoodType food = _food;
        _food = FoodType.None;
        return new Food();
    }

}