using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TinB : Tin
{
    public override void TinIngredients() //Polymorphism
    {
        ingredient1 = "Beef";
        ingredient2 = "Carrot";
    }
}
