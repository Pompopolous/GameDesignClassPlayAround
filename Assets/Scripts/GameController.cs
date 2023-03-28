using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Variables that controller spawn waves
    [Header("Wave Setting")]
    // What are we spawning?
    public GameObject hazard;
    // Where are we spawning?
    public Vector2 spawnValues;
    // How many hazards are we spawning?
    public int hazardCount;

    [Header("Wave Timing Setting")]
    // How long until the first wave starts?
    public float startWait;
    // How long between each hazard in a wave?
    public float spawnWait;
    // How long between each wave of hazard?
    public float waveWait;


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
        StartCoroutine(SpawnWaves());
        UpdateScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // Restart the Game by pressing R
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene("Level1");
            }
        }
    }

    // add a coroutine
    IEnumerator SpawnWaves()
    {
        // initial delay before the first wave
        yield return new WaitForSeconds(startWait);
        // start spawning the waves
        while (true)
        {
            // start spawn
            for (int i = 0; i < hazardCount; i++)
            {
                // spawn a single hazard
                Vector2 spawnPosition = new Vector2(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y));
                Instantiate(hazard, spawnPosition, Quaternion.identity);
                // wait. then spawn the next one.
                yield return new WaitForSeconds(spawnWait);
            }
            // wait. spawn the next wave.
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                restart = true;
                RestartTextObj.SetActive(true);
                break;
            }
        }
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
    // Game Over
    public void GameOver()
    {
        gameOver = true;
        GameOverTextObj.SetActive(true);
    }
}
