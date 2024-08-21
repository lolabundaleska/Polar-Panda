using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeepScore : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score;
    }

    void ScoreUpdate()
    {
       
        score++
    }
}

  