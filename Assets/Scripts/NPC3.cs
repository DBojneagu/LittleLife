using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC3 : MonoBehaviour
{
    private float speed = 2f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        // Debug.LogWarning(transform.position);

        if (transform.position.x >= 27f)
        {
            // transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
            transform.position = new Vector3(26.99f, 0.01f, -7.12f);
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        if (transform.position.x <= -37f)
        {
            // transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
            transform.position = new Vector3(-36.99f, 0.02f, -10.66f);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }


    }
}
