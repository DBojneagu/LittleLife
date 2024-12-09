using UnityEngine;
using System.IO;
using TMPro; // Import TextMeshPro namespace
using UnityEngine.UI; // Add this line to import the Button component


public class CheckCharacterButton : MonoBehaviour
{
    public int characterIdToCheck; // Set this to the character ID you want to check
    public int characterPrice; // Set this to the price of the Bird character
    public GameObject button; // Reference to the button GameObject
    public string characterName;
    public GameObject character;
    private CharacterManager characterManager; // Reference to the CharacterManager script
    private BuyCharacter buyCharacter;

    private void Start()
    {
        // Find the CharacterManager script in the scene
        characterManager = FindObjectOfType<CharacterManager>();
        buyCharacter = FindObjectOfType<BuyCharacter>();


        if (characterManager == null)
        {
            Debug.Log("CharacterManager not found in the scene!");
        }

        if (button == null)
        {
            Debug.Log("Button reference not set!");
        }
        else
        {
            UpdateButtonText();
        }
    }

    private void OnEnable()
    {
        // Register the OnClick method to be called when the button is clicked
        button.GetComponent<Button>().onClick.AddListener(OnClick);
    }

    private void OnDisable()
    {
        // Unregister the OnClick method to prevent memory leaks
        button.GetComponent<Button>().onClick.RemoveListener(OnClick);
    }

    // Call this method to update the button text
    public void UpdateButtonText()
    {
        string userPath = Application.dataPath + "/Data/UserData.json";
        string json = File.ReadAllText(userPath);
        UserData user = JsonUtility.FromJson<UserData>(json);

        // Check if the character ID is in the list
        if (user.Characters.Contains(characterIdToCheck))
        {
            Debug.Log(characterName);

            // Character is in the list, update button text
            button.GetComponentInChildren<TextMeshProUGUI>().text = characterName;
        }
        else
        {
            // Character is not in the list, set button text to the price
            button.GetComponentInChildren<TextMeshProUGUI>().text = "$" + characterPrice.ToString();
        }
    }

    // Method to be called when the button is clicked
    private void OnClick()
    {
        string userPath = Application.dataPath + "/Data/UserData.json";
        string json = File.ReadAllText(userPath);
        UserData user = JsonUtility.FromJson<UserData>(json);

        // Check if the character ID is in the list
        if (user.Characters.Contains(characterIdToCheck))
        {
            user.SelectedCharacter = characterIdToCheck;
            json = JsonUtility.ToJson(user, true);
            File.WriteAllText(userPath, json);
            // Character is in the list, switch to that character
            characterManager.SwitchCharacter(character);
        }
        else
        {
            // Character is not in the list or CharacterManager is not initialized
            buyCharacter.BuyCharacters(characterIdToCheck, characterPrice, character);
        }
    }
}