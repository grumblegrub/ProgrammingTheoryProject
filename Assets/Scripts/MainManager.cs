using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    [System.NonSerialized] public int score;
    [System.NonSerialized] public int playerHealth=3;

    [System.NonSerialized] public string[] ingredients=new string[6];
    [System.NonSerialized] public string catRequest;

    // GUI Elements - assigned in inspector
    public TextMeshProUGUI catNameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI catRequestText;

    public TextMeshProUGUI selectedTinText;
    public Button feedTinButton;

    public GameObject gameManager;

    //selected tin
    [System.NonSerialized] public string selectedTin = null;
    private GameObject currentTinObj =null;
    private Tin currentTin;


    private void Awake()
    {
        Instance = this;
    }


    void Start()
    {
        SetupIngredients();
        catNameText.text = GameManager.Instance.catName+" is hungry!";


        NewRound(); //Abstraction
    }

    public void FeedCat() //Abstraction
    {
        UpdateScore();  
        DeselectTin();
        NewRound();
    }

    void UpdateScore()
    {
        if(catRequest==currentTin.ingredient1|| catRequest == currentTin.ingredient2)
        {
            score += 100;
            if (score == 1000) { GameOver(true); }
        }
        else { playerHealth--; if (playerHealth==0) { GameOver(false); } }

    }
   
    void GameOver(bool win)
    {
        GameManager.Instance.firstGame = false;
        GameManager.Instance.gameWon = win;

        SceneManager.LoadScene(0);
    }

    void NewRound() //Abstraction
    {
        NewRequest(); 
        UpdateMainGUI();
        ReadTinIngredients();
    }


    void NewRequest()
    {
        int n = Random.Range(0, ingredients.Length);
        catRequest = ingredients[n];
    }
    void UpdateMainGUI()
    {
        scoreText.text = "Score : " + score.ToString("000");
        healthText.text = "Health : " + playerHealth+"/3";
        catRequestText.text = catRequest;
    }


    public void SwitchTin()
    {
        DeselectTin();

        currentTinObj = GameObject.Find(selectedTin);
        currentTinObj.transform.Find("Outline").gameObject.SetActive(true);
        currentTin=currentTinObj.GetComponent<Tin>();

        ReadTinIngredients();
    }


    private void DeselectTin()
    {
        if (currentTin != null)
        {
            currentTinObj.transform.Find("Outline").gameObject.SetActive(false);
            currentTinObj = null;
            currentTin = null;
        }
    }

    public void ReadTinIngredients()
    {
        if (currentTin != null)
        {
            selectedTinText.text = currentTin.ingredient1 + $"<br>" + currentTin.ingredient2;
            feedTinButton.interactable = true;
        }
        else { selectedTinText.text = "Select Tin";
            feedTinButton.interactable = false;
        }
    }



    public void SetupIngredients()
    {
        ingredients =new string[6] {"Fish", "Chicken", "Beef", "Egg", "Cheese", "Carrot" };

    }

}
