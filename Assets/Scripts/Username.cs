using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Username : MonoBehaviour
{
    public GameObject inputField;
    public string username;
 

    void Update()
    {
        username = inputField.GetComponent<TMP_InputField>().text;
        Debug.Log("Input text: " + username);
    }
}