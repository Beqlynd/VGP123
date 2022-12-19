using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[DefaultExecutionOrder(-1)]
public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    public static GameManager instance
    {
        get => _instance;
        set { _instance = value; }
    }
    public int maxLives = 5;
    private int _lives = 3;

    [HideInInspector] public Level currentLevel = null;

    public int maxScore = 5;
    private int _score = 0;

    public int maxWeapons = 1;
    private int _weapon = 0;

    public PlayerController playerPrefab;
    [HideInInspector] public PlayerController playerInstance = null;
    [HideInInspector] public Transform currentSpawnPoint;


    public int Lives
    {
        get { return _lives; }
        set
        {
            //lost life = respawn

            if (_lives > value)
                Respawn();

            _lives = value;

            if (_lives > maxLives)
                _lives = maxLives;

            if (_lives < 0)
                GameOver();

            Debug.Log("Lives have been set to " + _lives.ToString());
        }
    }

    public int Score
    {
        get { return _score; }
        set
        {
            _score = value;

            Debug.Log("Score has been set to " + _score.ToString());
        }
    }

    public int Weapon
    {
        get { return _weapon; }
        set
        {
            _weapon = value;

            if (_weapon > maxWeapons)
                _weapon = maxWeapons;

        }
    }

    void Awake()
    {
        if (_instance)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (SceneManager.GetActiveScene().name == "Level")
            {
                SceneManager.LoadScene(0);
                playerInstance = null;
            }
            else
            {
                SceneManager.LoadScene(1);
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
            Lives--;
    }

    public void SpawnPlayer(Transform spawnPoint)
    {
        playerInstance = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        currentSpawnPoint = spawnPoint;
    }

    void Respawn()
    {
        if (playerInstance)
        {
            playerInstance.transform.position = currentSpawnPoint.position;
        }
    }

    void GameOver()
    {
        //go to gameover screen
    }
}
