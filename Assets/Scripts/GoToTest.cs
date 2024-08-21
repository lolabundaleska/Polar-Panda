using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class GoToTest : MonoBehaviour
{
    public Button doorButton;
    public string scenename = "QuizScene";


    void Start()
    {
        Button btn = doorButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Debug.Log("You have opened the door!");
        SceneManager.LoadScene(scenename);
    }
}
