using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    public GameObject catNameInput;
    public Text subTitleText;


    public Button startButton;
    public Text warningText;
    public bool nameCheck = true;

    public void Start()
    {
        GamePrompt();
    }

    public void Update()
    {
        NameCheck();


    }


    public void EnterCatName()
    {
        GameManager.Instance.catName= catNameInput.GetComponent<InputField>().text;

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    private void GamePrompt()
    {
        if (GameManager.Instance.firstGame)
        { subTitleText.text = "OOP Theory Project"; }
        else
        {
            if (GameManager.Instance.gameWon)
            { subTitleText.text = GameManager.Instance.catName + " is full. You Win!"; }
            else { subTitleText.text = GameManager.Instance.catName + " is mad. You Lose!"; }
        }
    }

    private void NameCheck()
    {
        warningText.enabled = !GameManager.Instance.nameOkay;
        startButton.interactable = GameManager.Instance.nameOkay;
    }
}
