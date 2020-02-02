using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    /// <summary>
    /// Start position of the background.
    /// </summary>
    private Vector3 startPos;

    /// <summary>
    /// Width at which to repeat at to reset the position of the background.
    /// </summary>
    private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position; // Set the Start position to the background's position.
        repeatWidth = GetComponent<BoxCollider>().size.x / 2; // Set the repeatWidth to half the size of the Box Collider component.
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < startPos.x - repeatWidth) 
        {
            transform.position = startPos; // Reset the position of the background.
        }
    }
}
