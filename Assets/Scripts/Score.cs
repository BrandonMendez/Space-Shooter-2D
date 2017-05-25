using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Score : MonoBehaviour{
    public int score = 0;
    private Text scoreKeeper;

    public void Start()
    {
        scoreKeeper = GetComponent<Text>();
        ResetScore();
    }

    public void AddToScore(int points)
    {
        score += points;
        scoreKeeper.text = score.ToString();
    }

    public void DoubleScore()
    {
        int points = score * 2;
        score = points;
        scoreKeeper.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0;
        scoreKeeper.text = score.ToString();
    }

}
