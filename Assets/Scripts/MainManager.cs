using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }

    [System.NonSerialized] public int score;
    [System.NonSerialized] public int playerHealth=3;

    [System.NonSerialized] public string[] ingredients=new string[6];
    [System.NonSerialized] public string catRequest;

    // GUI Elements - assigned in inspector
    public TextMeshProUGUI playerNameText;
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


    public void SwitchTin()
    {
        if (currentTinObj != null)
        {
            currentTinObj.transform.Find("Outline").gameObject.SetActive(false);
        }
        currentTinObj = GameObject.Find(selectedTin);
        currentTinObj.transform.Find("Outline").gameObject.SetActive(true);

        currentTin=currentTinObj.GetComponent<Tin>();

        ReadTinIngredients();
    }

    public void ReadTinIngredients()
    {

        selectedTinText.text = currentTin.ingredient1+$"<br>"+ currentTin.ingredient2;

    }



    public void SetupIngredients()
    {
        ingredients =new string[6] {"Fish", "Chicken", "Beef", "Egg", "Cheese", "Carrot" };

    }

}
