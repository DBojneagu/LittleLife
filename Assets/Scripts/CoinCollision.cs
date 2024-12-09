using System;
using System.Collections;
using System.IO;
using TMPro;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
public class CoinCollision : MonoBehaviour
{
    private Rigidbody _rigidbody;
    public float _respawnTime = 5.0f;
    public TextMeshProUGUI score;

    private void Awake() =>
        _rigidbody = GetComponent<Rigidbody>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            string userPath = Application.dataPath + "/Data/UserData.json";
            string json = File.ReadAllText(userPath);
            UserData user = JsonUtility.FromJson<UserData>(json);
            user.Score++;
            Debug.Log("user score on trigger: " + user.Score);
            json = JsonUtility.ToJson(user, true);
            File.WriteAllText(userPath, json);

            // Increment coin count
            int nrcoins= PlayerPrefs.GetInt("EarnedCoins");
            nrcoins++;
            PlayerPrefs.SetInt("EarnedCoins", nrcoins);
            PlayerPrefs.Save();

            // Disable the coin
            other.gameObject.SetActive(false);

            // Start a coroutine to wait for 3 seconds and then enable the coin
            StartCoroutine(EnableCoinAfterDelay(_respawnTime, other));
        }
    }

    private IEnumerator EnableCoinAfterDelay(float delay, Collider other)
    {
        // Wait for the specified time
        yield return new WaitForSeconds(delay);

        // Enable the coin and make it visible
        other.gameObject.SetActive(true);
    }

    private void Update()
    {
        string userPath = Application.dataPath + "/Data/UserData.json";
        string json = File.ReadAllText(userPath);
        UserData user = JsonUtility.FromJson<UserData>(json);

        int nrcoins = PlayerPrefs.GetInt("EarnedCoins");
        score.text = user.Score.ToString();
    }

}

