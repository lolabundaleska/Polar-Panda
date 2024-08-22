using UnityEngine;
using System.Collections;


public class LoadQuiz : MonoBehaviour
{
    public GameObject quizObject;
    public float delay = 3.0f;

    void Start()
    {
        StartCoroutine(ActivateAfterDelay());
    }

    IEnumerator ActivateAfterDelay()
    {
        yield return new WaitForSeconds(delay);
        quizObject.SetActive(true);
    }
}
