using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    public GameObject currentCharacter;
    public CameraFollow cameraFollow; // Reference to the CameraFollow script

    private void Start()
    {
        // Example: Initialize currentCharacter by finding the initial character in the scene
        currentCharacter = GameObject.FindWithTag("Player");
        cameraFollow = Camera.main.GetComponent<CameraFollow>();

        // Set the initial character as the target for the camera
        if (currentCharacter != null && cameraFollow != null)
        {
            cameraFollow.SetTarget(currentCharacter.transform);
        }
    }

    public void SwitchCharacter(GameObject newCharacter)
    {
        Debug.LogWarning("entered switch!");
        currentCharacter = GameObject.FindWithTag("Player");
        if (newCharacter != null)
        {
            // Optionally, copy the position and rotation from the current character to the new character
            if (currentCharacter != null)
            {
                /*float yOffset = 0f;
                float f = 0.0f;
                decimal dec = new decimal(f);
                double d = (double)dec; 
                newCharacter.transform.position = new Vector3(
                currentCharacter.transform.position.x,
                (float)d,
                currentCharacter.transform.position.z
            );*/
                newCharacter.transform.position = currentCharacter.transform.position;
                newCharacter.transform.rotation = currentCharacter.transform.rotation;
            }

            // Log current and new character positions and rotations
            Debug.Log($"Current Character Position: {currentCharacter.transform.position}");
            Debug.Log($"Current Character Rotation: {currentCharacter.transform.rotation.eulerAngles}");

            Debug.Log($"New Character Position: {newCharacter.transform.position}");
            Debug.Log($"New Character Rotation: {newCharacter.transform.rotation.eulerAngles}");


            // Deactivate the current character GameObject
            if (currentCharacter != null)
            {
                currentCharacter.SetActive(false);
            }

            // Set the new character as the current character
            currentCharacter = newCharacter;

            // Activate the new character GameObject
            if (currentCharacter != null)
            {
                currentCharacter.SetActive(true);
            }

            // Set the new character as the target for the camera
            if (cameraFollow != null)
            {
                cameraFollow.SetTarget(currentCharacter.transform);
            }
        }
        else
        {
            Debug.LogWarning("New character not assigned!");
        }
    }
}
