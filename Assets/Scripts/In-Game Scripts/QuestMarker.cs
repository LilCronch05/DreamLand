using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestMarker : MonoBehaviour
{
    public float speed;
    public bool moveUp;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 1, 0);

        if (moveUp == true)
        {
            transform.position += new Vector3(0, speed * Time.deltaTime, 0);
        }
        else
        {
            transform.position -= new Vector3(0, speed * Time.deltaTime, 0);
        }
        if (transform.position.y <= 2f)
        {
            moveUp = true;
        }
        if (transform.position.y >= 2.35f)
        {
            moveUp = false;
        }
    }
}
