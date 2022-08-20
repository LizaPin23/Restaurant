using System;
using UnityEngine;

public class Food 
{
    public FoodType Type { get; private set; }
    public Sprite Icon { get; private set; }
    public int KitchenPrice { get; private set; }
    public int TablePrice { get; private set; }

    public Food(FoodConfig config)
    {
        Type = config.TypeOfFood;
        Icon = config.Icon;
        KitchenPrice = config.KitchenPrice;
        TablePrice = config.TablePrice;
    }
}

public enum FoodType
{
    None,
    Pizza,
    IceCream
}
