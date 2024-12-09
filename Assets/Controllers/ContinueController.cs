using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;


public class ContinueController : MonoBehaviour
{
    public void Continue()
    {
        string userPath = Application.dataPath + "/Data/UserData.json";

        string json = File.ReadAllText(userPath);
        UserData user = JsonUtility.FromJson<UserData>(json);

        SceneManager.LoadScene("SampleScene");
    }
}
