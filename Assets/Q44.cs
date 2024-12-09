using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Q44 : MonoBehaviour
{
    public List<string> taskTexts4; // List of task texts
    public TextMeshProUGUI taskText;
    public string questName;
    public string questDescription;
    public bool isSelected;
    public bool isCompleted;
    //public bool isCompletedClaim=0;
    public Button myButton;

    private const string LastTaskChangeKey = "LastTaskChangeTime";
    //private const float MinutesToWait = 3f; // 24 hours // Change this to 1 for one minute

    private void Awake()
    {
        if (taskText == null)
        {
            Debug.Log("TextMeshProUGUI component not assigned to TaskCompletion script.");
        }
        //PlayerPrefs.SetInt("CompletedCafe", 0);
        //PlayerPrefs.Save();
        //PlayerPrefs.SetInt("CompletedClaim", 0);
        //PlayerPrefs.Save();
        taskTexts4 = new List<string>
        {
            "Race Time!\r\nPlay the race game at the police station!",
            "Are you fast enough?\r\nGo to the police station and score at least 350 !",
            "Details matter!\r\nCollect at least 10 cones at the police station !",
        };


        int isCompletedRace = PlayerPrefs.GetInt("CompletedRace");
        Debug.Log(isCompletedRace);
        if (isCompletedRace == 1)
        {
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int isCompletedClaim = PlayerPrefs.GetInt("CompletedClaimRace");
            if (isCompletedClaim == 0)
            {
                BlurTask();
            }
            else
            {

                //textColor.a = 1f;
                //taskText.color = textColor;
                myButton.GetComponent<ButtonActivation4>().DezActivateButton();
            }
            //PlayerPrefs.SetInt("CompletedClaim", 0);
            //PlayerPrefs.Save();
        }
        //SelectTask();
    }


    public void SelectTask()
    {
        isCompleted = false;
        PlayerPrefs.SetInt("CompletedRace", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("CompletedClaimRace", 0);
        PlayerPrefs.Save();
        Color textColor = taskText.color;
        textColor.a = 1f;
        taskText.color = textColor;
        // Pick a random index from the list
        int randomIndex = UnityEngine.Random.Range(0, taskTexts4.Count);

        // Set the task text based on the random index
        taskText.text = taskTexts4[randomIndex];

    }
    private void Start()
    {
        if (taskText == null)
        {
            Debug.Log("TextMeshProUGUI component not assigned to TaskCompletion script.");
        }
        //PlayerPrefs.SetInt("CompletedCafe", 0);
        //PlayerPrefs.Save();
        //PlayerPrefs.SetInt("CompletedClaim", 0);
        //PlayerPrefs.Save();
        taskTexts4 = new List<string>
        {
            "Race Time!\r\nPlay the race game at the police station!",
            "Are you fast enough?\r\nGo to the police station and score at least 350 !",
            "Details matter!\r\nCollect at least 10 cones at the police station !",
        };


        int isCompletedRace = PlayerPrefs.GetInt("CompletedRace");
        Debug.Log(isCompletedRace);
        if (isCompletedRace == 1)
        {
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int isCompletedClaim = PlayerPrefs.GetInt("CompletedClaimRace");
            if (isCompletedClaim == 0)
            {
                BlurTask();
            }
            else
            {

                //textColor.a = 1f;
                //taskText.color = textColor;
                myButton.GetComponent<ButtonActivation4>().DezActivateButton();
            }
            //PlayerPrefs.SetInt("CompletedClaim", 0);
            //PlayerPrefs.Save();
        }
    }
    private DateTime GetLastTaskChangeTime()
    {
        string lastTaskChangeTimeString = PlayerPrefs.GetString(LastTaskChangeKey, string.Empty);

        if (DateTime.TryParse(lastTaskChangeTimeString, out DateTime lastTaskChangeTime))
        {
            return lastTaskChangeTime;
        }

        return DateTime.MinValue;
    }

    private void SaveLastTaskChangeTime(DateTime time)
    {
        PlayerPrefs.SetString(LastTaskChangeKey, time.ToString());
        PlayerPrefs.Save();
    }

    public void BlurTask()
    {
        int isCompletedRace = PlayerPrefs.GetInt("CompletedRace");
        Debug.Log(isCompletedRace);
        Debug.Log(taskText.text);
        if (taskText != null && isCompletedRace == 1)
        {
            // Set the alpha (transparency) of the text to 0
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int pointsSnake = PlayerPrefs.GetInt("PointsRace");
            int cones = PlayerPrefs.GetInt("Cones");

            if (taskText.text.StartsWith("R"))
            {
                Debug.Log("first");
                myButton.GetComponent<ButtonActivation4>().ActivateButton();
            }
            if (taskText.text.StartsWith("A"))
            {
                if (pointsSnake >= 350)
                {
                    Debug.LogError("second");
                    myButton.GetComponent<ButtonActivation4>().ActivateButton();
                }
                else
                {
                    Debug.Log(pointsSnake);
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation4>().DezActivateButton();
                    Debug.Log("second");
                    PlayerPrefs.SetInt("CompletedRace", 0);
                    PlayerPrefs.Save();
                }
            }
            if (taskText.text.StartsWith("D"))
            {
                if (cones >= 10)
                {
                    Debug.Log("third");
                    myButton.GetComponent<ButtonActivation4>().ActivateButton();

                }
                else
                {
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation4>().DezActivateButton();
                    Debug.Log("third");
                    PlayerPrefs.SetInt("CompletedRace", 0);
                    PlayerPrefs.Save();
                }
            }

        }
        else
        {
            if (isCompletedRace == 0 || isCompletedRace == null)
            {
                Debug.Log("all good");
            }
            else
            {
                Debug.Log("TextMeshProUGUI component not assigned to TaskCompletion script.");
            }
        }
    }
}
