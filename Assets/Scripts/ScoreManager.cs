using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public float pointsPerSecond;
    public Text scoreText;
    public Text hiScoreText;
    public bool isScoreIncreasing;

    public float score;
    private float hiScore;


    void Start()
    {
        isScoreIncreasing = true; 
        if (PlayerPrefs.HasKey("HiScore"))   
            hiScore = PlayerPrefs.GetFloat("HiScore");
    }

    void Update()
    {
        if (isScoreIncreasing)
            score += pointsPerSecond * Time.deltaTime;

         if (score > hiScore) {
            hiScore = score;
            PlayerPrefs.SetFloat("HiScore", hiScore);
         }

         hiScoreText.text = Mathf.Round(hiScore).ToString();
         scoreText.text = Mathf.Round(score).ToString();
    }
}
