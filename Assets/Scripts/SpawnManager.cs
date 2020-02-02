using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    /// <summary>
    /// Reference to the Obstacle gameObject. Set in inspector.   
    /// </summary>
    public GameObject obstaclePrefab;

    /// <summary>
    /// Spawn position of the obstacle.
    /// </summary>
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    
    /// <summary>
    /// Time to wait before spawning an obstacle once the game has started.
    /// </summary>
    private float startDelay = 2.0f;

    /// <summary>
    /// Rate of how often an obstacle will be spawned.
    /// </summary>
    private float repeatRate = 2.0f;

    /// <summary>
    /// Reference to the Player Controller script.
    /// </summary>
    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate); // Wait for 2 seconds then spawn an obstacle every two seconds.
        playerControllerScript = GameObject.FindWithTag("Player").GetComponent<PlayerController>(); // Assign the reference to the script.
    }

    /// <summary>
    /// Spawn a clone of an obstacle prefab at a preset location.
    /// </summary>
    void SpawnObstacle()
    {
        if (playerControllerScript.gameOver == false) // If the game isn't over
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation); // Spawn a clone of an obstacle.
        }
        
    }
}
