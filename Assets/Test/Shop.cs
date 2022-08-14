using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int Toys = 6;
    public int MoneyShop = 10;
    public int Price = 1;

    
    
    public int Buy()
    {
      Toys = Toys - 1;
      MoneyShop = MoneyShop + 1;
       return Toys;
    }
}
