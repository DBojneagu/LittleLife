using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Coins : MonoBehaviour
{
    public int _countCoins = 0;
    public void AddCoins(int countCoins)
    {
        int earnedCoins = PlayerPrefs.GetInt("EarnedCoins", 0);
        _countCoins += earnedCoins;

        string userPath = Application.dataPath + "/Data/UserData.json";
        string json = File.ReadAllText(userPath);
        UserData user = JsonUtility.FromJson<UserData>(json);

        user.Score += _countCoins;

        json = JsonUtility.ToJson(user, true);
        File.WriteAllText(userPath, json);

        Debug.Log("COINSSSSSSS"+_countCoins);
    }
}
