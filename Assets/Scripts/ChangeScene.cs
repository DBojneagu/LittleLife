using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scene : MonoBehaviour
{
    public Button sceneChangeButton;

    // The name of the scene you want to load
    public string sceneToLoad;

    private void Start()
    {
        // Register a listener for the button click event
        sceneChangeButton.onClick.AddListener(ChangeScene);
    }

    // Method to be called when the button is clicked
    void ChangeScene()
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneToLoad);
    }
}
