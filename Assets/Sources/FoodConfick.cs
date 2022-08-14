using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [CreateAssetMenu(fileName = "NewFood", menuName = "CreateFood")]
public class FoodConfick : ScriptableObject 
{
    [SerializeField] private FoodType _typeOfFood;
    [SerializeField] private Sprite _icon;

    public Sprite Icon => _icon;
    public FoodType TypeOfFood => _typeOfFood;

    
}
