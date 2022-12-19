using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int StartingLives;
    public Transform spawnPoint;
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.Lives = StartingLives;
        GameManager.instance.currentLevel = this;
        GameManager.instance.SpawnPlayer(spawnPoint);

        //GameManager.instance.currentLevel.UpdateCheckPoint();
    }

    public void UpdateCheckPoint(Transform spawnPoint)
    {
        GameManager.instance.currentSpawnPoint = spawnPoint;
    }
}
