using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    private float speed = 2f;
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);

        //Debug.LogWarning(transform.position);

        if (transform.position.x >= 5f)
        {
            //transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
            transform.position = new Vector3(4.99f, 0.02f, 31.67f);
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

        if (transform.position.x <= -37f)
        {
            //transform.Rotate(0, -90 * Time.deltaTime, (float)Space.World);
            transform.position = new Vector3(-36.99f, 0.03f, 28f);
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }


    }
}
