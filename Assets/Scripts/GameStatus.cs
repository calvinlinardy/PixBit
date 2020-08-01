using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    // config params
    [Range(0.1f, 10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 50;
    [SerializeField] TextMeshProUGUI scoreText = null;
    public bool isAutoPlayEnabled = default;

    //cached ref
    SceneLoader sceneLoader;

    //state
    [SerializeField] int currentScore = 0;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }


    public void ResetGame()
    {
        Destroy(gameObject);
    }

    private void Start()
    {
        scoreText.text = currentScore.ToString();
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!SceneLoader.GameIsPaused)
        {
            Time.timeScale = gameSpeed;
        }
        else
        {
            Time.timeScale = 0f;
        }
    }

    public void AddToScore()
    {
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }

    public void ResetOnlyScore()
    {
        currentScore = 0;
        scoreText.text = currentScore.ToString();
    }
    
    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;
    }

    public void PlayEasy()
    {
        gameSpeed = 0.5f;
        sceneLoader.LoadNextScene();
    }

    public void PlayNormal()
    {
        gameSpeed = 0.7f;
        sceneLoader.LoadNextScene();
    }

    public void PlayHard()
    {
        gameSpeed = 1.4f;
        sceneLoader.LoadNextScene();
    }

    public void PlayImpossible()
    {
        gameSpeed = 2f;
        sceneLoader.LoadNextScene();
    }
}
