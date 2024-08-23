using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class QuizManager : MonoBehaviour
{
    public List<QuestionsAndAnswers> QnA;
    public GameObject[] options;
    public int currentQuestion;

    public GameObject Quizpanel;
    public GameObject GOPanel;
    public GameObject LQPanel;

    public TextMeshProUGUI QuestionTxt;
    public TextMeshProUGUI ScoreTxt;

    public TextMeshProUGUI TriesText;

    public TextMeshProUGUI CurrentScore;




    string username = PlayerInfo.username; //for displaying score

    int totalQuestions = 0;
    public int score;


    //sounds
    [SerializeField] AudioSource backgroundMusic;
    [SerializeField] AudioSource correctSound;
    [SerializeField] AudioSource wrongSound;
    [SerializeField] AudioSource gameoverSound;


    private void Start()
    {
        totalQuestions = QnA.Count;
        GOPanel.SetActive(false);
        LQPanel.SetActive(false);
        generateQuestion();

        TriesText.text = "Number of tries: " + PlayerInfo.numberOfTries;

    }

    public void retry()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerInfo.numberOfTries++;
        SceneManager.LoadScene("LearningScene"); //when you fail it loads a LearningScene instead of starting the quiz again
    }

    public void lastQ()
    {
        GameOver();
    }

    void GameOver()
    {
        backgroundMusic.Pause();
        gameoverSound.Play();
        Quizpanel.SetActive(false);
        GOPanel.SetActive(true);
        LQPanel.SetActive(false);

        ScoreTxt.text =  username + " scored " + score + " points"; // + "/" + totalQuestions;
    }

    void LastQuestion()
    {
        Quizpanel.SetActive(false);
        GOPanel.SetActive(false);
        LQPanel.SetActive(true);
    }
    public void correct()
    {
        //when you are right
        score += 1;
        correctSound.Play();
        //add sound
        QnA.RemoveAt(currentQuestion);
        generateQuestion();
    }

    public void wrong()
    {
        //when you answer wrong
        wrongSound.Play();


        QnA.RemoveAt(currentQuestion);
        GameOver();
    }


    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];

            if(QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void generateQuestion()
    {
        if (score < 60 && QnA.Count > 0)
        {
            CurrentScore.text = "Correctly answered: " + score
                ;


            currentQuestion = Random.Range(0, QnA.Count);

            QuestionTxt.text = QnA[currentQuestion].Question;
            SetAnswers();
        }
        else 
        {
            Debug.Log("you reached 60 points");
            LastQuestion();
        }
    
            

    }
}
