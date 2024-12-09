using UnityEngine;

public class ClickSoundPlayer : MonoBehaviour
{
    public AudioSource audioSource;

    void Start()
    {
        // Get the AudioSource component on the same GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Play the click sound
            if (audioSource != null)
            {
                audioSource.Play();
            }
        }
    }
}
