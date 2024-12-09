using UnityEngine;
using System.IO;

public class gameMain : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject bird;
    public GameObject gecko;
    public GameObject deer;
    public GameObject monkey;
    public GameObject fish;
    public GameObject mouse;
    public GameObject squid;
    public GameObject snake;
    private CharacterManager characterManager;
    private void Start()
    {
        // Load character position
        float playerX = PlayerPrefs.GetFloat("PlayerX", 16f);
        float playerY = PlayerPrefs.GetFloat("PlayerY", 0f);
        float playerZ = PlayerPrefs.GetFloat("PlayerZ", -9f);

        // Set the player's position
        playerTransform.position = new Vector3(playerX-2f, playerY, playerZ);
        string userPath = Application.dataPath + "/Data/UserData.json";
        string json = File.ReadAllText(userPath);
        UserData user = JsonUtility.FromJson<UserData>(json);
        characterManager = FindObjectOfType<CharacterManager>();
        Debug.Log(user.SelectedCharacter);
        switch (user.SelectedCharacter)
        {
            case 1:
                characterManager.SwitchCharacter(deer);
                break;
            case 2:
                characterManager.SwitchCharacter(bird);
                break;
            case 3:
                characterManager.SwitchCharacter(monkey);
                break;
            case 4:
                characterManager.SwitchCharacter(mouse);
                break;
            case 5:
                characterManager.SwitchCharacter(snake);
                break;
            case 6:
                characterManager.SwitchCharacter(fish);
                break;
            case 7:
                characterManager.SwitchCharacter(gecko);
                break;
            case 8:
                characterManager.SwitchCharacter(squid);
                break;
        }
    }
    private void OnDestroy()
    {
        // Save character position before changing scenes
        PlayerPrefs.SetFloat("PlayerX", playerTransform.position.x);
        PlayerPrefs.SetFloat("PlayerY", playerTransform.position.y);
        PlayerPrefs.SetFloat("PlayerZ", playerTransform.position.z);
        PlayerPrefs.Save();
    }
}