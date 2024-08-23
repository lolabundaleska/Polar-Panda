using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class StartTheGame : MonoBehaviour
{ 
    public Button startButton;                 //for getting the game started
    public string scenename = "LearningScene";

    public GameObject inputField;   //for the username
    public string username;

    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        PlayerInfo.numberOfTries = 1;
    }

    void TaskOnClick()
    {
        username = inputField.GetComponent<TMP_InputField>().text;   //for username
        PlayerInfo.username = username;
        Debug.Log("Input text: " + username);  

        Debug.Log("You have clicked the button!");     //for new scene
        SceneManager.LoadScene(scenename);
    }
}