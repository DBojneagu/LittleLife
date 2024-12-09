using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Q1 : MonoBehaviour
{
    public List<string> taskTexts; // List of task texts
    public TextMeshProUGUI taskText;
    public string questName;
    public string questDescription;
    public bool isSelected;
    public bool isCompleted;
    //public bool isCompletedClaim=0;
    public Button myButton;
    public Q2 quest2;
    public Q3 quest3;
    public Q44 quest4;

    private const string LastTaskChangeKey = "LastTaskChangeTime";
    private const float MinutesToWait = 7f; // 24 hours // Change this to 1 for one minute

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
        taskTexts = new List<string>
        {
            "Coffee Time!\r\nGo to the cafe and serve the clients!",
            "Thirsty?\r\nGo to the cafe and get at least 2 stars!",
            "Good Morning!\r\nGo to the cafe and get at least 1 star!",
        };
        Debug.Log("awake");

        int isCompletedCafe = PlayerPrefs.GetInt("CompletedCafe");
        if (isCompletedCafe == 1)
        {
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int isCompletedClaim = PlayerPrefs.GetInt("CompletedClaim");
            if (isCompletedClaim == 0)
            {
                BlurTask();
            }
            else
            {

                //textColor.a = 1f;
                //taskText.color = textColor;
                myButton.GetComponent<ButtonActivation>().DezActivateButton();
            }
            //PlayerPrefs.SetInt("CompletedClaim", 0);
            //PlayerPrefs.Save();
        }
        SelectTask();
    }
    private void Start()
    {
        if (taskText == null)
        {
            Debug.Log("TextMeshProUGUI component not assigned to TaskCompletion script.");
        }

        Debug.Log("start");

        int isCompletedCafe = PlayerPrefs.GetInt("CompletedCafe");
        if (isCompletedCafe == 1)
        {
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int isCompletedClaim = PlayerPrefs.GetInt("CompletedClaim");
            if (isCompletedClaim == 0)
            {
                
                BlurTask();
            }
            else
            {

                //textColor.a = 1f;
                //taskText.color = textColor;
                myButton.GetComponent<ButtonActivation>().DezActivateButton();
            }
            //PlayerPrefs.SetInt("CompletedClaim", 0);
            //PlayerPrefs.Save();
        }
    }
    public void SelectTask()
    {

        //myButton.GetComponent<ButtonActivation>().DezActivateButton();
        if (taskTexts != null && taskTexts.Count > 0)
        {
            DateTime lastTaskChangeTime = GetLastTaskChangeTime();
            DateTime currentTime = DateTime.Now;
            Debug.Log("Changing task");
            // Check if enough time has passed since the last task change
            if ((currentTime - lastTaskChangeTime).TotalMinutes >= MinutesToWait)
            {
                Debug.Log("Task Changed");
                isCompleted = false;
                PlayerPrefs.SetInt("CompletedCafe", 0);
                PlayerPrefs.Save();
                PlayerPrefs.SetInt("CompletedClaim", 0);
                PlayerPrefs.Save();
                Color textColor = taskText.color;
                textColor.a = 1f;
                taskText.color = textColor;
                // Pick a random index from the list
                int randomIndex = UnityEngine.Random.Range(0, taskTexts.Count);

                // Set the task text based on the random index
                taskText.text = taskTexts[randomIndex];
                quest2.SelectTask();
                quest3.SelectTask();
                quest4.SelectTask();
                // Update the last task change time
                SaveLastTaskChangeTime(currentTime);
            }
            else
            {
                Debug.Log("Not enough time has passed to change the task.");
            }
        }
        else
        {
            Debug.LogError("Task text list is empty or null.");
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
        int isCompletedCafe = PlayerPrefs.GetInt("CompletedCafe");
        Debug.Log(isCompletedCafe);
        Debug.Log(taskText.text);
        if (taskText != null && isCompletedCafe == 1)
        {
            // Set the alpha (transparency) of the text to 0
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int stars = PlayerPrefs.GetInt("Stars");

            if (taskText.text.StartsWith("C"))
            {
                Debug.Log("first");
                myButton.GetComponent<ButtonActivation>().ActivateButton();
            }
            if (taskText.text.StartsWith("T"))
            {
                if (stars >= 2)
                {
                    Debug.Log("second");
                    myButton.GetComponent<ButtonActivation>().ActivateButton();
                }
                else
                {
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation>().DezActivateButton();
                    Debug.Log("second");
                    PlayerPrefs.SetInt("CompletedCafe", 0);
                    PlayerPrefs.Save();
                }
            }
            if (taskText.text.StartsWith("G"))
            {
                if (stars >= 1)
                {
                    Debug.Log("third");
                    myButton.GetComponent<ButtonActivation>().ActivateButton();

                }
                else
                {
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation>().DezActivateButton();
                    Debug.Log("third");
                    PlayerPrefs.SetInt("CompletedCafe", 0);
                    PlayerPrefs.Save();
                }
            }

        }
        else
        {
            if (isCompletedCafe == 0 || isCompletedCafe == null)
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