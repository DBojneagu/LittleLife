using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2 : MonoBehaviour
{
    private float speed = 2f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Debug.LogWarning(transform.position);

        if (transform.position.z >= 40f)
        {
            // transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
            transform.position = new Vector3(13.14f, 0.02f, 39.99f);
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        if (transform.position.z <= 3f)
        {
            // transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
            transform.position = new Vector3(16.57f, 0.02f, 3.01f);
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

    }
}
