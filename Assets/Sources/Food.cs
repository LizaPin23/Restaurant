using System;
using UnityEngine;

public class Food 
{
    public FoodType Type { get; private set; }
    public Sprite Icon { get; private set; }

    public Food(FoodConfick confick)
    {
        Type = confick.TypeOfFood;
        Icon = confick.Icon;
        
    }


}

public enum FoodType
{
    None,
    Pizza,
    IceCream
}
