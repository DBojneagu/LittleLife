using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Q3 : MonoBehaviour
{
    public List<string> taskTexts3; // List of task texts
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
        taskTexts3 = new List<string>
        {
            "Time to play!\r\nScore at least 100 points at the bakery!",
            "Hungry?\r\nGet at least 200 points at the bakery!",
            "Care for a treat?!\r\nGo to the bakery and play the snake game!",
        };


        int isCompletedSnake = PlayerPrefs.GetInt("CompletedSnake");
        Debug.Log(isCompletedSnake);
        if (isCompletedSnake == 1)
        {
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int isCompletedClaim = PlayerPrefs.GetInt("CompletedClaimSnake");
            if (isCompletedClaim == 0)
            {
                BlurTask();
            }
            else
            {

                //textColor.a = 1f;
                //taskText.color = textColor;
                myButton.GetComponent<ButtonActivation3>().DezActivateButton();
            }
            //PlayerPrefs.SetInt("CompletedClaim", 0);
            //PlayerPrefs.Save();
        }
        //SelectTask();
    }


    public void SelectTask()
    {
        isCompleted = false;
        PlayerPrefs.SetInt("CompletedSnake", 0);
        PlayerPrefs.Save();
        PlayerPrefs.SetInt("CompletedClaimSnake", 0);
        PlayerPrefs.Save();
        Color textColor = taskText.color;
        textColor.a = 1f;
        taskText.color = textColor;
        // Pick a random index from the list
        int randomIndex = UnityEngine.Random.Range(0, taskTexts3.Count);

        // Set the task text based on the random index
        taskText.text = taskTexts3[randomIndex];

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
        taskTexts3 = new List<string>
        {
            "Time to play!\r\nScore at least 100 points at the bakery!",
            "Hungry?\r\nGet at least 200 points at the bakery!",
            "Care for a treat?!\r\nGo to the bakery and play the snake game!",
        };


        int isCompletedSnake = PlayerPrefs.GetInt("CompletedSnake");
        Debug.Log(isCompletedSnake);
        if (isCompletedSnake == 1)
        {
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int isCompletedClaim = PlayerPrefs.GetInt("CompletedClaimSnake");
            if (isCompletedClaim == 0)
            {
                BlurTask();
            }
            else
            {

                //textColor.a = 1f;
                //taskText.color = textColor;
                myButton.GetComponent<ButtonActivation3>().DezActivateButton();
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
        int isCompletedSnake = PlayerPrefs.GetInt("CompletedSnake");
        Debug.LogError(isCompletedSnake);
        Debug.LogError(taskText.text);
        if (taskText != null && isCompletedSnake == 1)
        {
            // Set the alpha (transparency) of the text to 0
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int pointsSnake = PlayerPrefs.GetInt("PointsSnake");

            if (taskText.text.StartsWith("C"))
            {
                Debug.LogError("first");
                myButton.GetComponent<ButtonActivation3>().ActivateButton();
            }
            if (taskText.text.StartsWith("T"))
            {
                if (pointsSnake >= 100)
                {
                    Debug.LogError("second");
                    myButton.GetComponent<ButtonActivation3>().ActivateButton();
                }
                else
                {
                    Debug.LogError(pointsSnake);
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation3>().DezActivateButton();
                    Debug.LogError("second");
                    PlayerPrefs.SetInt("CompletedSnake", 0);
                    PlayerPrefs.Save();
                }
            }
            if (taskText.text.StartsWith("H"))
            {
                if (pointsSnake >= 200)
                {
                    Debug.LogError("third");
                    myButton.GetComponent<ButtonActivation3>().ActivateButton();

                }
                else
                {
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation3>().DezActivateButton();
                    Debug.LogError("third");
                    PlayerPrefs.SetInt("CompletedSnake", 0);
                    PlayerPrefs.Save();
                }
            }

        }
        else
        {
            if (isCompletedSnake == 0 || isCompletedSnake == null)
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
