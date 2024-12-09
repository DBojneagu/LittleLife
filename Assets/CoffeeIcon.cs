using TMPro;
using UnityEngine;

public class CoffeeIcon : MonoBehaviour
{
    public Q1 taskCompletion;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerCompletedTask();
        }
    }
    void PlayerCompletedTask()
    {
        int isCompletedCafe = PlayerPrefs.GetInt("CompletedCafe");
        if (taskCompletion != null && isCompletedCafe == 0)
        {
            taskCompletion.isCompleted = true;
            PlayerPrefs.SetInt("CompletedCafe", 1);
            PlayerPrefs.Save();

            //taskCompletion.CompleteTask();
        }
        else
        {
            Debug.LogError("TaskCompletion component not assigned.");
        }
        PlayerPrefs.SetInt("Stars", 0);
        PlayerPrefs.Save();
    }

}
