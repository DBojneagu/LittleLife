using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The character's Transform (Player GameObject)
    public float rotationSpeed = 45f; // Speed of camera rotation
    public float distance = 5f; // Distance between the character and the camera
    public float height = 2f; // Height of the camera above the character

    void Update()
    {
        if (target == null)
        {
            return; // If the target is not set, do nothing.
        }

        // Calculate the desired rotation for the camera
        Quaternion targetRotation = Quaternion.Euler(0f, target.eulerAngles.y, 0f);

        // Calculate the offset based on the desired rotation
        Vector3 offset = targetRotation * new Vector3(0f, height, -distance);

        // Set the camera's position to follow the character with the calculated offset
        transform.position = target.position + offset;

        // Rotate the camera to match the character's rotation
        transform.rotation = targetRotation;

        // Check for right arrow key press and rotate the character accordingly
        if (Input.GetKey(KeyCode.RightArrow))
        {
            // Rotate the character and update the camera rotation accordingly
            target.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        if (target != null)
        {
            // Calculate the desired rotation for the camera
            Quaternion targetRotation = Quaternion.Euler(0f, target.eulerAngles.y, 0f);

            // Calculate the offset based on the desired rotation
            Vector3 offset = targetRotation * new Vector3(0f, height, -distance);

            // Set the camera's position to follow the character with the calculated offset
            transform.position = target.position + offset;

            // Rotate the camera to match the character's rotation
            transform.rotation = targetRotation;
        }
    }

}
