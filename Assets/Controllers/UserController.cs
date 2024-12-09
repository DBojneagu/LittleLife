using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour
{
    public UserData GetUsers()
    {
        string json = File.ReadAllText(Application.dataPath + "/Data/UsersData.json");
        UserData data = JsonUtility.FromJson<UserData>(json);
        return data;
    }
}
