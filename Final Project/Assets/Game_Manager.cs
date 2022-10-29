using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    //public SpawnPoint playerSpawnPoint;

    public static Game_Manager sharedInstance = null;
    //public RPGCameraManager cameraManager;
    public GameObject Player;

    public GameObject PlayerSpawnPoint;

    public Text DeathCounter;

    public int DeathCount = 0;

    void Awake()
    {
        if (sharedInstance != null && sharedInstance != this)
        {
            // We only ever want one instance to exist, so destroy the other existing object
            Destroy(gameObject);
        }
        else
        {
            // If this is the only instance, then assign the sharedInstance variable to the current object.
            sharedInstance = this;
        }
        //UpdateDeathCount();
    }

    void Start()
    {
        // Consolidate all the logic to setup a scene inside a single method. 
        // This makes it easier to call again in the future, in places other than the Start() method.
        //SetupScene();
    }

    public void SetupScene()
    {
        SpawnPlayer();
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
       // DeathCount++;
        //UpdateDeathCount();
    }

    void UpdateDeathCount()
    {
        DeathCounter.text = "Take " + (DeathCount + 1);
    }

    public void SpawnPlayer()
    {
        GameObject playerInstance = Instantiate(Player, PlayerSpawnPoint.transform);
        playerInstance.GetComponent<Player>().Revive();
    }

}