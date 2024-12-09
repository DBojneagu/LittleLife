using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakeCollision : MonoBehaviour
{
    public string sceneToLoad; // The name of the scene to load
    public PlayerPositionHandler playerPositionHandler; // Reference to the PlayerPositionHandler script
    public Q3 taskCompletion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Snake"))
        {
            Debug.Log("Collision with Snake detected!");
            // Save the player's position before transitioning to another scene
            playerPositionHandler.SavePlayerPosition();
            PlayerCompletedTask();
            // Load the specified scene
            SceneManager.LoadScene(sceneToLoad);
        }
    }
    void PlayerCompletedTask()
    {
        int isCompletedSnake = PlayerPrefs.GetInt("CompletedSnake");
        if (taskCompletion != null && isCompletedSnake == 0)
        {
            taskCompletion.isCompleted = true;
            PlayerPrefs.SetInt("CompletedSnake", 1);
            PlayerPrefs.Save();

            //taskCompletion.CompleteTask();
        }
        else
        {
            Debug.LogError("TaskCompletion component not assigned.");
        }
        PlayerPrefs.SetInt("PointsSnake", 0);
        PlayerPrefs.Save();
    }
}
