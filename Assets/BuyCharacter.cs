using UnityEngine;
using System.IO;

public class BuyCharacter : MonoBehaviour
{
    private int userMoney = 500; // Initial user money
    private CharacterManager characterManager; // Reference to the CharacterManager script
    public GameObject bird;
    public GameObject gecko;
    public GameObject deer;
    public GameObject monkey;
    public GameObject fish;
    public GameObject mouse;
    public GameObject squid;
    public GameObject snake;


    private void Start()
    {
        // Find the CharacterManager script in the scene
        characterManager = FindObjectOfType<CharacterManager>();

        if (characterManager == null)
        {
            Debug.LogError("CharacterManager not found in the scene!");
        }
    }

    public void BuyDeer()
    {
        BuyCharacters(1, 0, deer);
    }

    public void BuyBird()
    {
        BuyCharacters(2, 50, bird);
    }

    public void BuyMonkey()
    {
        BuyCharacters(3, 100, monkey);
    }

    public void BuyMouse()
    {
        BuyCharacters(4, 150, mouse);
    }

    public void BuySnake()
    {
        BuyCharacters(5, 200, snake);
    }

    public void BuyFish()
    {
        BuyCharacters(6, 250, fish);
    }

    public void BuyGecko()
    {
        BuyCharacters(7, 300, gecko);
    }

    public void BuySquid()
    {
        BuyCharacters(8, 350, squid);
    }

    public void BuyCharacters(int characterId, int characterPrice, GameObject specificCharacter)
    {
        string userPath = Application.dataPath + "/Data/UserData.json";
        string json = File.ReadAllText(userPath);
        UserData user = JsonUtility.FromJson<UserData>(json);

        if (user.Score >= characterPrice)
        {
            // User has enough money to buy the character
            Debug.Log($"Congratulations! You bought {characterId} for ${characterPrice}.");

            if (specificCharacter != null)
            {
                if (!user.Characters.Contains(characterId))
                    user.Characters.Add(characterId);
                //user.SelectedCharacter = characterId;
                user.Score -= characterPrice;

                json = JsonUtility.ToJson(user, true);
                File.WriteAllText(userPath, json);

                characterManager.SwitchCharacter(specificCharacter);
            }
/*            else
            {
                // If no specific character is provided, use the default newCharacterPrefab
                characterManager.SwitchCharacter(newCharacterPrefab);
            }*/
        }
        else
        {
            // User doesn't have enough money or CharacterManager is not initialized
            Debug.Log("Not enough money to buy this character or CharacterManager is not initialized!");
        }
    }
}
