using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Float variable for the max height of the player's jump.
    /// </summary>
    public float jumpForce;

    /// <summary>
    /// Float variable to multiply by gravity, if need be.
    /// </summary>
    public float gravityModifier;

    /// <summary>
    /// Check if the player is grounded. False if the player isn't.
    /// </summary>
    public bool isGrounded = true;

    /// <summary>
    /// Reference to the Rigidbody component
    /// </summary>
    private Rigidbody playerRb;

    /// <summary>
    /// If the game is finished, true. If not false.
    /// </summary>
    public bool gameOver = true;

    /// <summary>
    /// Explosion that plays upon player death.
    /// </summary>
    public ParticleSystem explosionParticle;

    /// <summary>
    /// Dirt particle effect that is kicked up by the player.
    /// </summary>
    public ParticleSystem dirtParticle;

    /// <summary>
    /// Player's jump sound effect.
    /// </summary>
    public AudioClip jumpSound;

    /// <summary>
    /// Explosion sound effect that plays upon Player's death.
    /// </summary>
    public AudioClip explosionSound;

    /// <summary>
    /// Mr.T scream sound effect to be played upon Player's death.
    /// </summary>
    public AudioClip screamSound;

    /// <summary>
    /// Reference to the Animator component.
    /// </summary>
    private Animator playerAnim;

    /// <summary>
    /// Reference to the AudioSource component.
    /// </summary>
    private AudioSource playerAudio;


    // Start is called before the first frame update
    void Start()
    {
        /// Assign the references
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();

        Physics.gravity *= gravityModifier; // Change the force of gravity on the Player.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && !gameOver) // If the Space Key is pressed, the Player is grounded, and the game isn't over...
        {
            Jump(); // Call the Jump Method and make the Player jump.
        }
    }

    /// <summary>
    /// Add a force upwards along the y axis.
    /// </summary>
    public void Jump()
    {
        playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Add an instant force upwards along the y axis.
        isGrounded = false; // The player is in the air, set is Grounded to false.
        dirtParticle.Stop(); // Stop the dirt kick up particle effect.
        playerAudio.PlayOneShot(jumpSound, 1.0f); // Play the jump sound effect once at a set volume.
        playerAnim.SetTrigger("Jump_trig"); // Play the jump animation.
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground") // If the player makes contact with the ground.
        {
            isGrounded = true; // The player is touching the ground.
            dirtParticle.Play(); // Play the dirt kick up particle effect 
        }
        else if (collision.gameObject.tag == "Obstacle") // If the player makes contact with an obstacle.
        {
            gameOver = true; // End the game.
            dirtParticle.Stop(); // Stop the dirt kick up particle effect.
            explosionParticle.Play(); // Play the explosion effect.
            playerAudio.PlayOneShot(explosionSound, 1.0f); // Play the explosion's sound effect.
            playerAudio.PlayOneShot(screamSound, 1.5f); // Pity yourself.

            // Set the parameters of and play the Death animation.
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            // Debug.Log("Game Over");
        }
    }
}
