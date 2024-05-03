using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameManager : MonoBehaviour
{
    int score;
    public int lives;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public static GameManager Instance { get; private set; }
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
        {
            Instance = this;

        }

    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
    }
    private void Update()
    {
        UpdateLives();
    }
    public void UpdateTheScore(int scorePointsToAdd)
    {
        score += scorePointsToAdd;
        scoreText.text = score.ToString();
    }
    public void UpdateLives()
    {
        //lives--;
        livesText.text = $"Lives : {lives}";
    }
}
