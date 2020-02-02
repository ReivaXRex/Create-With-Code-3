using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{

    /// <summary>
    /// The obstacle's speed.
    /// </summary>
   [SerializeField] private float speed = 30;
    private float leftBound = -15;

    /// <summary>
    /// Reference to the Player Controller script. 
    /// </summary>
    private PlayerController playerControllerScript;


    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>(); // Assign the reference to the script.
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver == false) // If the gane isn't over...
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed); // Move the obstacle to the left by a customizable speed.
        }

        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle")) // If this gameObject exceeds the left boundary....
        {
            Destroy(gameObject); // Destory it
        }
        
    }
}
