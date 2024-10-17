using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinA : Tin
{
    public override void TinIngredients() //Polymorphism
    {
        ingredient1 = "Chicken";
        ingredient2 = "Cheese";
    }
}
