using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;
    private int score = 0;

    [SerializeField] TMP_Text scoreText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreUI();
    }

    // Update is called once per frame
    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
