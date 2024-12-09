using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovieCollider : MonoBehaviour
{
    [Header("Cinema Game Scene")]
    //public SceneAsset cinemaGameSceneAsset; // Reference to the Cinema Game scene
    public Q2 taskCompletion;
    public string sceneToLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            LoadCinemaGameScene();
            PlayerCompletedTask();
        }
    }

    private void LoadCinemaGameScene()
    {
        if (sceneToLoad != null)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogError("Cinema Game Scene Asset is not assigned.");
        }
    }
    void PlayerCompletedTask()
    {
        int isCompletedMovie = PlayerPrefs.GetInt("CompletedMovie");
        if (taskCompletion != null && isCompletedMovie == 0)
        {
            Debug.Log("AICIIIIIIIIIIIIIIIIIIIIIIII");
            taskCompletion.isCompleted = true;
            PlayerPrefs.SetInt("CompletedMovie", 1);
            PlayerPrefs.Save();

            //taskCompletion.CompleteTask();
        }
        else
        {
            Debug.Log("TaskCompletion component not assigned.");
        }
        PlayerPrefs.SetInt("Points", 0);
        PlayerPrefs.Save();
    }
}
