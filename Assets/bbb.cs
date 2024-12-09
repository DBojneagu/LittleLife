using UnityEngine;

public class DisplayCharacter : MonoBehaviour
{
    public GameObject characterPrefab; // Assign the prefab in the Unity Editor
    public Transform panelTransform; // Reference to the panel's transform

    void Start()
    {
        if (characterPrefab == null)
        {
            Debug.LogError("Character Prefab not assigned!");
            return;
        }

        if (panelTransform == null)
        {
            Debug.LogError("Panel Transform not assigned!");
            return;
        }

        // Instantiate the character prefab
        GameObject characterInstance = Instantiate(characterPrefab, panelTransform);

        if (characterInstance == null)
        {
            Debug.LogError("Failed to instantiate character prefab!");
            return;
        }

        // Optionally, you can set the position, rotation, and scale of the instantiated prefab within the panel
        characterInstance.transform.localPosition = Vector3.zero;
        characterInstance.transform.localRotation = Quaternion.identity;
        characterInstance.transform.localScale = Vector3.one;

        Debug.Log("Character instantiated successfully!");
    }
}
