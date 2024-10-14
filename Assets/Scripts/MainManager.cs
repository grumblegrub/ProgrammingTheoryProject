using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public int score;
    public int playerHealth=3;


    public string[] ingredients=new string[6];
    public string catRequest;

    // GUI Elements - assigned in inspector
    public TextMeshProUGUI playerNameText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI catRequestText;
    public TextMeshProUGUI selectedTin;
    public Button feedTinButton;

    public GameObject gameManager;

    void Start()
    {
        //temp delete later as will load from title
        Instantiate(gameManager);

        SetupIngredients();
        playerNameText.text = GameManager.Instance.playerName;
        NewRound();
    }

    void Update()
    {
        
    }

    void FeedCat()
    {
        UpdateScore();
        NewRound();
    }

    void UpdateScore()
    {

    }
   

    void NewRound()
    {
        NewRequest();
        UpdateMainGUI();
       
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

    void SetupIngredients()
    {
        ingredients =new string[6] {"Fish", "Chicken", "Beef", "Egg", "Cheese", "Carrot" };

    }

}
