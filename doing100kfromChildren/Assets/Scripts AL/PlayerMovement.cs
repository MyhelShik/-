using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to set the player's movement speed
    private Rigidbody playerRigidbody;

    void Start()
    {
        // Get the Rigidbody component attached to the player GameObject
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Call the function to handle player movement in the Update method
        MovePlayer();
    }

    void MovePlayer()
    {
        // Get horizontal and vertical input from the keyboard
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * moveSpeed * Time.deltaTime;

        // Apply the movement to the player's Rigidbody
        playerRigidbody.MovePosition(transform.position + movement);
    }
}
