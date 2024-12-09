using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WelcomeController : MonoBehaviour
{
    public Button sceneChangeButton;

    public string sceneToLoad;

    void Start()
    {
        Debug.Log("starttttt");
        sceneChangeButton.onClick.AddListener(ChangeScene);
    }

    void ChangeScene()
    {
        Debug.Log("xxxxxxx");
        string userPath = Application.dataPath + "/Data/UserData.json";

        UserData user = new UserData();
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(userPath, json);
        PlayerPrefs.SetFloat("PlayerX", 16f);
        PlayerPrefs.SetFloat("PlayerY", 0f);
        PlayerPrefs.SetFloat("PlayerZ", -9f);
        PlayerPrefs.Save();
        SceneManager.LoadScene(sceneToLoad);
    }
/*    public void NewGame()
    {
        string userPath = Application.dataPath + "/Data/UserData.json";

        UserData user = new UserData();
        string json = JsonUtility.ToJson(user, true);
        File.WriteAllText(userPath, json);
        PlayerPrefs.SetFloat("PlayerX", 16f);
        PlayerPrefs.SetFloat("PlayerY", 0f);
        PlayerPrefs.SetFloat("PlayerZ",-9f);
        PlayerPrefs.Save();
        // SceneManager.LoadScene("SampleScene");
    }*/
}
