using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    [Header("UI Objects")]
    public TMP_Text scoreText;
    public GameObject GameOverTextObj;
    public GameObject RestartTextObj;
    private int score = 0;
    private bool gameOver = false;
    private bool restart = false;
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddtoScore(int scoreValuetoAdd)
    {
        score += scoreValuetoAdd;
        Debug.Log("Score" + score);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
