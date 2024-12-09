using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 10f;
    public AudioSource audioSource;

    private Animator animator;  // Reference to the Animator component
    private Rigidbody rb;      // Reference to the Rigidbody component
    private bool isWalking;     // Flag to track whether the character is walking or not

    void Start()
    {
        // Get the Animator component attached to the same GameObject
        animator = GetComponent<Animator>();

        // Get the Rigidbody component attached to the same GameObject
        rb = GetComponent<Rigidbody>();

        // Check if animator and Rigidbody are not null
        if (animator == null || rb == null)
        {
            Debug.LogError("Animator or Rigidbody component not found!");
        }

        // Set Rigidbody constraints to freeze rotation to prevent unwanted rotations
        rb.freezeRotation = true;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 localMovement = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 worldMovement = transform.TransformDirection(localMovement);

        if (worldMovement != Vector3.zero)
        {
            isWalking = true;  // Set the flag to true when there's movement

            Quaternion targetRotation = Quaternion.LookRotation(worldMovement, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Use Rigidbody to move the character
            rb.velocity = worldMovement * moveSpeed;

            // Check if audioSource is not null and the footstep sound is not already playing
            if (audioSource != null && !audioSource.isPlaying)
            {
                // Play the footstep sound
                audioSource.Play();
            }
        }
        else
        {
            isWalking = false;  // Set the flag to false when there's no movement

            // Check if audioSource is not null and the footstep sound is playing, then stop it
            if (audioSource != null && audioSource.isPlaying)
            {
                audioSource.Stop();
            }

            // Set IsSitting to true when not moving
            if (animator != null)
            {

                animator.SetBool("IsSitting", true);
            }

            // Stop the character by setting velocity to zero
            rb.velocity = Vector3.zero;
        }

        // Update the Animator parameter based on the isWalking flag
        if (animator != null)
        {
            animator.SetBool("IsWalking", isWalking);
        }
    }
}
