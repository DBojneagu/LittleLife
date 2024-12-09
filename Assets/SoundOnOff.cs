using UnityEngine;
using UnityEngine.UI;

public class ToggleSoundButton : MonoBehaviour
{
    public AudioSource audioSource;
    public Sprite soundOnImage;
    public Sprite soundOffImage;

    private bool isAudioOn = true;
    private Image buttonImage;

    void Start()
    {
        // Get the AudioSource component attached to the GameObject
        // You can also assign this in the Inspector if you prefer
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Find the Button component on this GameObject
        Button button = GetComponent<Button>();

        // Get the Image component attached to the button
        buttonImage = GetComponent<Image>();

        // Add a listener to the button click event
        if (button != null)
        {
            button.onClick.AddListener(ToggleSound);
        }

        // Update the button image based on the initial audio state
        UpdateButtonImage();
    }

    void ToggleSound()
    {
        if (audioSource != null)
        {
            if (isAudioOn)
            {
                // If audio is currently on, turn it off
                audioSource.Pause();
            }
            else
            {
                // If audio is currently off, turn it on
                audioSource.Play();
            }

            // Toggle the audio state
            isAudioOn = !isAudioOn;

            // Update the button image based on the new audio state
            UpdateButtonImage();
        }
    }

    void UpdateButtonImage()
    {
        if (buttonImage != null)
        {
            // Set the button image based on the audio state
            buttonImage.sprite = isAudioOn ? soundOnImage : soundOffImage;
        }
    }
}
