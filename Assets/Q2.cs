using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Q2 : MonoBehaviour
{
    public List<string> taskTexts2; // List of task texts
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
        taskTexts2 = new List<string>
        {
            "Film Night!\r\nComplete a quiz at the cinema!",
            "Smarty?\r\nGet at least 250 points at the cinema!",
            "Movie Buff?\r\nGo to the cinema and get at least 100 points!",
        };
        

        int isCompletedMovie = PlayerPrefs.GetInt("CompletedMovie");
        Debug.Log(isCompletedMovie);
        if (isCompletedMovie == 1)
        {
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int isCompletedClaim = PlayerPrefs.GetInt("CompletedClaimMovie");
            if (isCompletedClaim == 0)
            {
                BlurTask();
            }
            else
            {

                //textColor.a = 1f;
                //taskText.color = textColor;
                myButton.GetComponent<ButtonActivation2>().DezActivateButton();
            }
            //PlayerPrefs.SetInt("CompletedClaim", 0);
            //PlayerPrefs.Save();
        }
        //SelectTask();
    }


    public void SelectTask()
    {
                isCompleted = false;
                PlayerPrefs.SetInt("CompletedMovie", 0);
                PlayerPrefs.Save();
                PlayerPrefs.SetInt("CompletedClaimMovie", 0);
                PlayerPrefs.Save();
                Color textColor = taskText.color;
                textColor.a = 1f;
                taskText.color = textColor;

                if (taskTexts2 is not null)
                {
                    // Pick a random index from the list
                    int randomIndex = UnityEngine.Random.Range(0, taskTexts2.Count);

                    if (randomIndex > 0)
                        // Set the task text based on the random index
                        taskText.text = taskTexts2[randomIndex];
        }

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
        taskTexts2 = new List<string>
        {
            "Film Night!\r\nComplete a quiz at the cinema!",
            "Smarty?\r\nGet at least 250 points at the cinema!",
            "Movie Buff?\r\nGo to the cinema and get at least 100 points!",
        };


        int isCompletedMovie = PlayerPrefs.GetInt("CompletedMovie");
        Debug.Log(isCompletedMovie);
        if (isCompletedMovie == 1)
        {
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int isCompletedClaim = PlayerPrefs.GetInt("CompletedClaimMovie");
            if (isCompletedClaim == 0)
            {
                BlurTask();
            }
            else
            {

                //textColor.a = 1f;
                //taskText.color = textColor;
                myButton.GetComponent<ButtonActivation2>().DezActivateButton();
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
        int isCompletedMovie = PlayerPrefs.GetInt("CompletedMovie");
        Debug.Log(isCompletedMovie);
        Debug.Log(taskText.text);
        if (taskText != null && isCompletedMovie == 1)
        {
            // Set the alpha (transparency) of the text to 0
            Color textColor = taskText.color;
            textColor.a = 0.2f;
            taskText.color = textColor;
            int points = PlayerPrefs.GetInt("Points");

            if (taskText.text.StartsWith("F"))
            {
                Debug.Log("first");
                myButton.GetComponent<ButtonActivation2>().ActivateButton();
            }
            if (taskText.text.StartsWith("S"))
            {
                if (points >= 250)
                {
                    Debug.Log("second");
                    myButton.GetComponent<ButtonActivation2>().ActivateButton();
                }
                else
                {
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation2>().DezActivateButton();
                    Debug.Log("second");
                    PlayerPrefs.SetInt("CompletedMovie", 0);
                    PlayerPrefs.Save();
                }
            }
            if (taskText.text.StartsWith("M"))
            {
                Debug.Log(points);
                if (points >= 100)
                {
                    Debug.Log("third");
                    myButton.GetComponent<ButtonActivation2>().ActivateButton();

                }
                else
                {
                    
                    textColor = taskText.color;
                    textColor.a = 1f;
                    taskText.color = textColor;
                    myButton.GetComponent<ButtonActivation2>().DezActivateButton();
                    Debug.Log("third");
                    PlayerPrefs.SetInt("CompletedMovie", 0);
                    PlayerPrefs.Save();
                }
            }

        }
        else
        {
            if (isCompletedMovie == 0 || isCompletedMovie == null)
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
