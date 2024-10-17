using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Tin : MonoBehaviour
{
    [System.NonSerialized] public string ingredient1;
    [System.NonSerialized] public string ingredient2;

    void Start()
    {
        TinIngredients();

    }
    
    public virtual void TinIngredients() //Polymorphism
    {
        ingredient1 = "Fish";
        ingredient2 = "Egg";
    }

    public void OnMouseDown()  //Inheritance
    {
        MainManager.Instance.selectedTin = this.name;
        MainManager.Instance.SwitchTin();

    }




}
