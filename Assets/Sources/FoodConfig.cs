using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "NewFood", menuName = "CreateFood")]
public class FoodConfig : ScriptableObject 
{
    [SerializeField] private FoodType _typeOfFood;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _kitchenPrice;
    [SerializeField] private int _tablePrice;

    public Sprite Icon => _icon;
    public FoodType TypeOfFood => _typeOfFood;
    public int KitchenPrice => _kitchenPrice;
    public int TablePrice => _tablePrice;
}
