using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HomeScene : MonoBehaviour
{
    public Button sceneChangeButton;
    public int coinsPerStar = 100;
    // The name of the scene you want to load
    public string sceneToLoad;

    private void Start()
    {
        // Register a listener for the button click event
        Time.timeScale = 1f;
        sceneChangeButton.onClick.AddListener(ChangeScene);
    }

    // Method to be called when the button is clicked
    void ChangeScene()
    {

        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
