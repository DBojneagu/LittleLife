using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class RaceScore : MonoBehaviour
{
    private int score = 500;

    private int finalScore;

    private int finalCones;

    [SerializeField]
    private TextMeshProUGUI scoreUI;

    [SerializeField]
    private TextMeshProUGUI finalScoreUI;

    private int coneCount = 0;

    [SerializeField]
    private TextMeshProUGUI coneCountUI;

    [SerializeField]
    private TextMeshProUGUI finalConeCountUI;

    public GameObject panel;

    public string sceneToLoad;

    public Button sceneChangeButton;

    public AudioClip collectSound;

    public GameObject collectEffect;

    void Start()
    {
        sceneChangeButton.onClick.AddListener(ChangeScene);
    }

    private void Update()
    {
        scoreUI.text = "Score: " + score.ToString();
        coneCountUI.text = "Cones: " + coneCount.ToString();
    }
    void ChangeScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Rail")
        {
            score -= 20;
            scoreUI.text = "Score: " + score.ToString();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cone")
        {
            coneCount++;
            coneCountUI.text = "Cones: " + coneCount.ToString();
            Collect();
            other.gameObject.SetActive(false);

        }

        if (other.gameObject.tag == "Finish")
        {
            panel.SetActive(true);
            finalScore = score;
            finalScoreUI.text = "Score: " + finalScore.ToString();

            string userPath = Application.dataPath + "/Data/UserData.json";
            string json = File.ReadAllText(userPath);
            UserData user = JsonUtility.FromJson<UserData>(json);

            user.Score += finalScore;

            json = JsonUtility.ToJson(user, true);
            File.WriteAllText(userPath, json);

            finalCones = coneCount;
            finalConeCountUI.text = "Cones Collected: " + finalCones.ToString();
            PlayerPrefs.SetInt("PointsRace", finalScore);
            PlayerPrefs.SetInt("Cones", finalCones);
        }
    }

    public void Collect()
    {
        //Debug.Log("in cone effect");
        if (collectSound)
            AudioSource.PlayClipAtPoint(collectSound, transform.position);
        if (collectEffect)
            Instantiate(collectEffect, transform.position, Quaternion.identity);
    }
}
