using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    private int score;
    private float spawnRate = 1.0f;
    public List<GameObject> targets;
    public bool isGameActive;
    public Button restartButton;
    public GameObject titleScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator SpawnTargets()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = UnityEngine.Random.Range(0, targets.Count);
            Instantiate(targets[index]);

        }
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        if (score < 0)
        {
            scoreText.text = "Score: 0";
            score = 0;
        }
        else
        {
            scoreText.text = "Score: " + score;
        }

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        restartButton.gameObject.SetActive(false);
    }

    public void StartGame(int difficulty)
    {
        titleScreen.gameObject.SetActive(false);
        isGameActive = true;
        spawnRate /= difficulty;

        StartCoroutine(SpawnTargets());
        score = 0;
        UpdateScore(0);

    }
}
