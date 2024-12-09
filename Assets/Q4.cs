using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Q4 : MonoBehaviour
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
            "race1!\r\nScore at least 100 !",
            "race2!\r\nScore at least 100 !",
            "race3!\r\nScore at least 100 !",
        };


        int isCompletedRace = PlayerPrefs.GetInt("CompletedRace");
        Debug.LogError(isCompletedRace);
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
            "race1!\r\nScore at least 100 !",
            "2race!\r\nScore at least 100 !",
            "3race1\r\nScore at least 100 !",
        };


        int isCompletedRace = PlayerPrefs.GetInt("CompletedRace");
        Debug.LogError(isCompletedRace);
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
        Debug.LogError(isCompletedRace);
        Debug.LogError(taskText.text);
        if (taskText != null && isCompletedRace == 1)
        {
            // Set the alpha (transparency) of the text to 0
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int pointsSnake = PlayerPrefs.GetInt("PointsRace");

            if (taskText.text.StartsWith("r"))
            {
                Debug.LogError("first");
                myButton.GetComponent<ButtonActivation4>().ActivateButton();
            }
            if (taskText.text.StartsWith("T"))
            {
                if (pointsSnake >= 100)
                {
                    Debug.LogError("second");
                    myButton.GetComponent<ButtonActivation4>().ActivateButton();
                }
                else
                {
                    Debug.LogError(pointsSnake);
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation4>().DezActivateButton();
                    Debug.LogError("second");
                    PlayerPrefs.SetInt("CompletedRace", 0);
                    PlayerPrefs.Save();
                }
            }
            if (taskText.text.StartsWith("H"))
            {
                if (pointsSnake >= 200)
                {
                    Debug.LogError("third");
                    myButton.GetComponent<ButtonActivation4>().ActivateButton();

                }
                else
                {
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation4>().DezActivateButton();
                    Debug.LogError("third");
                    PlayerPrefs.SetInt("CompletedRace", 0);
                    PlayerPrefs.Save();
                }
            }

        }
        else
        {
            if (isCompletedRace == 0 || isCompletedRace == null)
            {
                Debug.LogError("all good");
            }
            else
            {
                Debug.LogError("TextMeshProUGUI component not assigned to TaskCompletion script.");
            }
        }
    }
}
