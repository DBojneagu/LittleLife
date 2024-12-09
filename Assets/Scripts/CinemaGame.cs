using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using TMPro;
using System;
using System.Threading;
using System.Linq;

public class CinemaGame : MonoBehaviour
{
    [System.Serializable]
    public class Question
    {
        public TextMeshProUGUI questionText;  // Change from TextMesh to Text
        public string[] answers;
        public int correctAnswerIndex;
    }

    [SerializeField]
    public TextMeshProUGUI questionText;  // Change from TextMesh to Text
    [SerializeField]
    public Button[] answerButtons;

    private Question[] questions;
    private int currentQuestionIndex = 0;

    public Color correctColor = Color.green;
    public Color incorrectColor = Color.red;
    public Color pressed = Color.gray;

    public Canvas welcomeCanvas;
    public Canvas cinemaCanvas;
    public Canvas endCanvas;

    private int playerScore = 0;
    public TextMeshProUGUI playerScoreText;

    // Start is called before the first frame update
    void Start()
    {
        SwitchCanvasDisplay(cinemaCanvas, 1);
        StartCoroutine(StartGame());
    }

    IEnumerator StartGame()
    {
        // Load questions (you can load them from a scriptable object or another source)
        questions = LoadQuestions();
        playerScore = 0;

        yield return new WaitForSeconds(5f);

        SwitchCanvasDisplay(cinemaCanvas, 0);
        SetCanvasActive(welcomeCanvas, false);

        // Display the first question
        DisplayQuestion();
    }

    private void DisplayQuestion()
    {

        // Check if there are still questions
        if (currentQuestionIndex < questions.Length)
        {
            // Display the question text
            questionText.text = questions[currentQuestionIndex].questionText.text;

            // Display answer choices
            for (int i = 0; i < answerButtons.Length; i++)
            {
                answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = questions[currentQuestionIndex].answers[i];

            }

        }
        else
        {
            // No more questions, quiz is complete
            Debug.Log("Quiz Complete!");

            SetCanvasActive(cinemaCanvas, false);
            SwitchCanvasDisplay(endCanvas, 0);
            playerScoreText.text = playerScore.ToString();
            PlayerPrefs.SetInt("Points", playerScore);

            string userPath = Application.dataPath + "/Data/UserData.json";
            string json = File.ReadAllText(userPath);
            UserData user = JsonUtility.FromJson<UserData>(json);

            user.Score += playerScore;

            json = JsonUtility.ToJson(user, true);
            File.WriteAllText(userPath, json);
        }
    }

    private void SetCanvasActive(Canvas canvas, bool isActive)
    {
        if (canvas != null)
        {
            canvas.gameObject.SetActive(isActive);
        }
    }

    void SwitchCanvasDisplay(Canvas canvas, int targetDisplay)
    {
        if (canvas != null)
        {
            canvas.targetDisplay = targetDisplay;
        }
    }

    public void CheckAnswer(int buttonIndex)
    {
        if (questions[currentQuestionIndex].correctAnswerIndex == buttonIndex)
        {
            Debug.Log("Correct!");
            StartCoroutine(DisplayResult(answerButtons[buttonIndex], correctColor));
            playerScore = playerScore + 50;
        }
        else
        {
            Debug.Log("Incorrect!");
            StartCoroutine(DisplayResult(answerButtons[buttonIndex], incorrectColor));
            StartCoroutine(DisplayResult(answerButtons[questions[currentQuestionIndex].correctAnswerIndex], correctColor));
        }

        // Move to the next question after a delay
        StartCoroutine(MoveToNextQuestion());
    }

    private IEnumerator DisplayResult(Button button, Color color)
    {
        // Change the color of the button
        button.GetComponent<Image>().color = color;

        // Wait for a short duration
        yield return new WaitForSeconds(1.5f); // Adjust the duration as needed

        // Reset the color
        button.GetComponent<Image>().color = Color.white;
    }

    private IEnumerator MoveToNextQuestion()
    {
        // Wait for a short duration before moving to the next question
        yield return new WaitForSeconds(2f); // Adjust the duration as needed

        // Move to the next question
        currentQuestionIndex++;
        DisplayQuestion();
    }

   
    public void OnOptionButtonClick(int buttonIndex)
    {
        SetButtonColor(answerButtons[buttonIndex], pressed);
        CheckAnswer(buttonIndex);
    }


    private void SetButtonColor(Button button, Color color)
    {
        // Change the color of the button
        button.GetComponent<Image>().color = color;
    }

    private void ResetButtonColor()
    {
        foreach (var button in answerButtons)
        {
            button.GetComponent<Image>().color = Color.white;  // Change to the default color
        }
    }




    private Question[] LoadQuestions()
    {

        TextMeshProUGUI questionText1 = Instantiate(questionText);
        TextMeshProUGUI questionText2 = Instantiate(questionText);
        TextMeshProUGUI questionText3 = Instantiate(questionText);
        TextMeshProUGUI questionText4 = Instantiate(questionText);
        TextMeshProUGUI questionText5 = Instantiate(questionText);
        TextMeshProUGUI questionText6 = Instantiate(questionText);
        TextMeshProUGUI questionText7 = Instantiate(questionText);
        TextMeshProUGUI questionText8 = Instantiate(questionText);
        TextMeshProUGUI questionText9 = Instantiate(questionText);
        TextMeshProUGUI questionText10 = Instantiate(questionText);
        TextMeshProUGUI questionText11= Instantiate(questionText);
        TextMeshProUGUI questionText12 = Instantiate(questionText);
        TextMeshProUGUI questionText13 = Instantiate(questionText);
        TextMeshProUGUI questionText14 = Instantiate(questionText);
        TextMeshProUGUI questionText15 = Instantiate(questionText);
        TextMeshProUGUI questionText16 = Instantiate(questionText);
        TextMeshProUGUI questionText17 = Instantiate(questionText);
        TextMeshProUGUI questionText18 = Instantiate(questionText);
        TextMeshProUGUI questionText19 = Instantiate(questionText);
        TextMeshProUGUI questionText20 = Instantiate(questionText);
        TextMeshProUGUI questionText21 = Instantiate(questionText);
        TextMeshProUGUI questionText22 = Instantiate(questionText);
        TextMeshProUGUI questionText23 = Instantiate(questionText);


        Question myQuestion1 = new Question();
        myQuestion1.questionText = questionText1; // Assign the reference from the inspector
        myQuestion1.questionText.text = "What are the names of the two lead characters played by Leonardo DiCaprio and Kate Winslet in the movie \"Titanic\"?";
        myQuestion1.answers = new string[] { "Jack and Rose", "Tom and Daisy", "Harry and Sally", "Mark and Jane" };
        myQuestion1.correctAnswerIndex = 0;

        Question myQuestion2 = new Question();
        myQuestion2.questionText = questionText2; // Assign the reference from the inspector
        myQuestion2.questionText.text = "What are the booby traps Kevin sets up to defend his home from burglars Harry and Marv in the \"Home Alone\" movie?";
        myQuestion2.answers = new string[] { "Sticky bandits and tripwires", "Feather-filled blowers and BB gun" , "Paint cans and tarantulas", "Hot doorknobs and icy stairs"  };
        myQuestion2.correctAnswerIndex = 2;

        Question myQuestion3 = new Question();
        myQuestion3.questionText = questionText3; // Assign the reference from the inspector
        myQuestion3.questionText.text = "Who directed \"Avatar,\" and what other famous film did he direct in 1997?";
        myQuestion3.answers = new string[] { "Steven Spielberg - Jurassic Park", "George Lucas - Star Wars: Episode I - The Phantom Menace", "Christopher Nolan - The Dark Knight", "James Cameron - Titanic" };
        myQuestion3.correctAnswerIndex = 3;

        Question myQuestion4 = new Question();
        myQuestion4.questionText = questionText4; // Assign the reference from the inspector
        myQuestion4.questionText.text = "Who won the Academy Award for Best Actor in a Leading Role for his performance in the 2016 film \"The Revenant\"?";
        myQuestion4.answers = new string[] { "Chris Hemsworth", "Leonardo DiCaprio", "Robert DeNiro", "Brad Pitt" };
        myQuestion4.correctAnswerIndex = 1;

        Question myQuestion5 = new Question();
        myQuestion5.questionText = questionText5; // Assign the reference from the inspector
        myQuestion5.questionText.text = "In which year did the actual Titanic sink, and how does that relate to the timeline in the film?";
        myQuestion5.answers = new string[] { "1912 - The film is set in 1915", "1915 - The film is set in the same year", "1912 - The film is set in the same year", "1920 - The film is set in 1912" };
        myQuestion5.correctAnswerIndex = 2;

        Question myQuestion6 = new Question();
        myQuestion6.questionText = questionText6; // Assign the reference from the inspector
        myQuestion6.questionText.text = "What is the name of the young boy left behind by his family in \"Home Alone\"?";
        myQuestion6.answers = new string[] { "Kevin", "Max", "Marv", "Peter" };
        myQuestion6.correctAnswerIndex = 0;

        Question myQuestion7 = new Question();
        myQuestion7.questionText = questionText7; // Assign the reference from the inspector
        myQuestion7.questionText.text = "What is the name of the fictional moon where \"Avatar\" is set?";
        myQuestion7.answers = new string[] { "Endor", "Tatooine", "Pandora", "Alderaan" };
        myQuestion7.correctAnswerIndex = 2;

        Question myQuestion8 = new Question();
        myQuestion8.questionText = questionText8; // Assign the reference from the inspector
        myQuestion8.questionText.text = "What is the name of Captain Jack Sparrow's ship in the \"Pirates of the Caribbean\" film series?";
        myQuestion8.answers = new string[] { "Flying Dutchman", "Queen Anne's Revenge", "Interceptor", "Black Pearl" };
        myQuestion8.correctAnswerIndex = 3;

        Question myQuestion9 = new Question();
        myQuestion9.questionText = questionText9; // Assign the reference from the inspector
        myQuestion9.questionText.text = "In \"Beauty and the Beast,\" what is the name of the enchanted castle's talking clock?";
        myQuestion9.answers = new string[] { "Cogsworth", "Lumière", "Mrs. Potts", "Chip" };
        myQuestion9.correctAnswerIndex = 0;

        Question myQuestion10 = new Question();
        myQuestion10.questionText = questionText10; // Assign the reference from the inspector
        myQuestion10.questionText.text = "What is the name of Elsa and Anna's kingdom in \"Frozen\"?";
        myQuestion10.answers = new string[] { "Corona", "Arendelle", "DunBroch", "Agrabah" };
        myQuestion10.correctAnswerIndex = 1;

        Question myQuestion11 = new Question();
        myQuestion11.questionText = questionText11; // Assign the reference from the inspector
        myQuestion11.questionText.text = "What magical power does Elsa possess?";
        myQuestion11.answers = new string[] { "Fire manipulation", "Invisibility", "Ice and snow creation", "Telekinesis" };
        myQuestion11.correctAnswerIndex = 2;

        Question myQuestion12 = new Question();
        myQuestion12.questionText = questionText12; // Assign the reference from the inspector
        myQuestion12.questionText.text = "Who portrayed Freddie Mercury in the film \"Bohemian Rhapsody\"?";
        myQuestion12.answers = new string[] { "Ben Hardy", "Gwilym Lee", "Rami Malek", "Joe Mazzello" };
        myQuestion12.correctAnswerIndex = 2;

        Question myQuestion13 = new Question();
        myQuestion13.questionText = questionText13; // Assign the reference from the inspector
        myQuestion13.questionText.text = "Which iconic Queen song provides the title for the film?";
        myQuestion13.answers = new string[] { "We Will Rock You", "Another One Bites the Dust", "Somebody to Love", "Bohemian Rhapsody" };
        myQuestion13.correctAnswerIndex = 3;


        Question myQuestion14 = new Question();
        myQuestion14.questionText = questionText14; // Assign the reference from the inspector
        myQuestion14.questionText.text = "Who is the original founder of the Avengers in the Marvel Cinematic Universe?";
        myQuestion14.answers = new string[] { "Captain America (Steve Rogers)", "Iron Man (Tony Stark)", "Thor", "Black Widow (Natasha Romanoff)" };
        myQuestion14.correctAnswerIndex = 0;

        Question myQuestion15 = new Question();
        myQuestion15.questionText = questionText15; // Assign the reference from the inspector
        myQuestion15.questionText.text = "\"May the Force be with you\" is a famous line from which Star Wars film, and who is the character known for saying it?";
        myQuestion15.answers = new string[] { "Star Wars: Episode V - The Empire Strikes Back - Han Solo", " Star Wars: Episode IV - A New Hope - Princess Leia Organa", " Star Wars: Episode VI - Return of the Jedi - Luke Skywalker", "Star Wars: Episode III - Revenge of the Sith - Obi-Wan Kenobi" };
        myQuestion15.correctAnswerIndex = 1;

        Question myQuestion16 = new Question();
        myQuestion16.questionText = questionText16; // Assign the reference from the inspector
        myQuestion16.questionText.text = "\"Mamma Mia!\" is a musical film featuring songs by the Swedish pop group ABBA. What is the name of the fictional Greek island where the story is set?";
        myQuestion16.answers = new string[] { "Kalokairi", "Santorini", "Mykonos", "Crete" };
        myQuestion16.correctAnswerIndex = 0;

        Question myQuestion17 = new Question();
        myQuestion17.questionText = questionText17; // Assign the reference from the inspector
        myQuestion17.questionText.text = "Who plays the main character, Donna Sheridan, in \"Mamma Mia!\"";
        myQuestion17.answers = new string[] { "Amanda Seyfried", "Julie Walters", "Christine Baranski", "Meryl Streep" };
        myQuestion17.correctAnswerIndex = 3;

        Question myQuestion18 = new Question();
        myQuestion18.questionText = questionText18; // Assign the reference from the inspector
        myQuestion18.questionText.text = "\"La La Land\" is set in Los Angeles and features the song \"City of Stars.\" Which two actors play the main characters, Mia and Sebastian?";
        myQuestion18.answers = new string[] { "Emma Watson and Ryan Gosling", "Emma Stone and Ryan Gosling", "Emma Stone and Ryan Reynolds", "Emma Watson and Ryan Reynolds" };
        myQuestion18.correctAnswerIndex = 2;

        Question myQuestion19 = new Question();
        myQuestion19.questionText = questionText19; // Assign the reference from the inspector
        myQuestion19.questionText.text = "Who directed \"La La Land,\" the musical film that won several Academy Awards, including Best Director?";
        myQuestion19.answers = new string[] { "Christopher Nolan", "Damien Chazelle", "Quentin Tarantino", "Greta Gerwig" };
        myQuestion19.correctAnswerIndex = 1;


        Question myQuestion20 = new Question();
        myQuestion20.questionText = questionText20; // Assign the reference from the inspector
        myQuestion20.questionText.text = "What were the two most waited for movies in 2023?";
        myQuestion20.answers = new string[] { "The Hunger Games: The Ballad of Songbirds & Snakes, Wonka", "Everything Everywhere All at Once, Taylor Swift: The Eras Tour", "Barbie, Oppenheimer", "Five Nights at Freddy's, Killers of the Flower Moon" };
        myQuestion20.correctAnswerIndex = 2;

        Question myQuestion21 = new Question();
        myQuestion21.questionText = questionText21; // Assign the reference from the inspector
        myQuestion21.questionText.text = "Which Disney animated film features the song \"Can You Feel the Love Tonight,\" which won the Academy Award for Best Original Song?";
        myQuestion21.answers = new string[] { "Aladdin", "The Lion King", "Frozen", "Beauty and the Beast" };
        myQuestion21.correctAnswerIndex = 1;

        Question myQuestion22 = new Question();
        myQuestion22.questionText = questionText22; // Assign the reference from the inspector
        myQuestion22.questionText.text = "Adele performed the theme song for which James Bond film?";
        myQuestion22.answers = new string[] { "Skyfall", "Spectre", "Quantum of Solace", "Casino Royale" };
        myQuestion22.correctAnswerIndex = 0;

        Question myQuestion23 = new Question();
        myQuestion23.questionText = questionText23; // Assign the reference from the inspector
        myQuestion23.questionText.text = "Which Celine Dion song is prominently featured in the soundtrack of the movie Titanic?";
        myQuestion23.answers = new string[] { "The Power of Love", "Because You Loved Me", "My Heart Will Go On", "It's All Coming Back to Me Now" };
        myQuestion23.correctAnswerIndex = 2;

        Question[] list = { myQuestion1, myQuestion2, myQuestion3, myQuestion4, myQuestion5, myQuestion5, myQuestion6, myQuestion7, myQuestion8, myQuestion9, myQuestion10, myQuestion11, myQuestion12, myQuestion13, myQuestion14, myQuestion15, myQuestion16, myQuestion17, myQuestion18, myQuestion19, myQuestion20, myQuestion21, myQuestion22, myQuestion23 };
        HashSet<Question> questionSet = new HashSet<Question>();

        // Use the current system time as the seed
        int seed = (int)System.DateTime.Now.Ticks;
        System.Random systemRandom = new System.Random(seed);

        while (questionSet.Count < 6)
        {
            int randomIndex = systemRandom.Next(0, 23);
            questionSet.Add(list[randomIndex]);
        }

        Question[] res = new Question[6];
        questionSet.CopyTo(res);


        return res;
    }







}
