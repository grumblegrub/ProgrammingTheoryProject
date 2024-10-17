using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }  //Encapsulation


    private string m_CatName = "Garfield";  
    public bool nameOkay=true;

    public string catName  //Encapsulation
    {
        get { return m_CatName; }
        set
        {
            if (value.Length > 10)
            { nameOkay = false; }
            else {  m_CatName = value; nameOkay = true; }
        }
    }


    public bool firstGame = true;
    public bool gameWon = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
