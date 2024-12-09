using TMPro;
using UnityEngine;

public class SnakeIcon : MonoBehaviour
{
    public Q3 taskCompletion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCompletedTask();
        }
    }
    void PlayerCompletedTask()
    {
        int isCompletedSnake = PlayerPrefs.GetInt("CompletedSnake");
        if (taskCompletion != null && isCompletedSnake == 0)
        {
            Debug.Log("AICIIIIIIIIIIIIIIIIIIIIIIII22222222222222");
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
