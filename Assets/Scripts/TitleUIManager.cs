using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleUIManager : MonoBehaviour
{
    public GameObject playerNameInput;

    public void EnterPlayerName()
    {
        GameManager.Instance.playerName= playerNameInput.GetComponent<InputField>().text;

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }
}
