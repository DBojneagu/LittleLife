﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load
    public PlayerPositionHandler playerPositionHandler; // Reference to the PlayerPositionHandler script

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cafea"))
        {
            Debug.Log("Collision with Cafea detected!");
            PlayerPrefs.SetInt("CompletedCafe", 1);
            PlayerPrefs.Save();
            // Save the player's position before transitioning to another scene
            playerPositionHandler.SavePlayerPosition();

            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
