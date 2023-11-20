using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Player player;
    public ScoreManager scoreManager;
    public AudioSource backgroundSound;
    public AudioSource deathSound;
    public GroundGenerator groundGenerator;
    public GameObject largeGround;
    public GameObject mediumGround;
    public GameObject gameOverScreen;

    private Vector3 playerStartingPoint;
    private Vector3 groundGeneratorStartingPoint;

    void Start()
    {
        playerStartingPoint = player.transform.position;
        groundGeneratorStartingPoint = groundGenerator.transform.position;
        gameOverScreen.SetActive(false); 
    }
 
    public void GameOVer() {
        player.gameObject.SetActive(false);
        gameOverScreen.SetActive(true); 
        scoreManager.isScoreIncreasing = false;
        backgroundSound.Stop();
        deathSound.Play();
    }

    public void Quit() {
        Application.Quit();
    }

    public void Restart() {
        GroundDestroyer[] destroyer = FindObjectsOfType<GroundDestroyer>();
        for (int i = 0; i<destroyer.Length; i++) {
                destroyer[i].gameObject.SetActive(false); 
        }
        largeGround.SetActive(true);
        mediumGround.SetActive(true);
        player.transform.position = playerStartingPoint;
        groundGenerator.transform.position = groundGeneratorStartingPoint;
        gameOverScreen.SetActive(false); 
        player.gameObject.SetActive(true);
        scoreManager.isScoreIncreasing = true;
        scoreManager.score = 0;
        backgroundSound.Play();
    }
}

