using UnityEngine;

public class JetMovement : MonoBehaviour
{
    public GameObject jet; // Assign your Jet GameObject in the Unity Editor
    public float flyingSpeed = 5.0f;
    public float flyDuration = 20.0f;
    public float waitDuration = 40.0f;

    private bool isFlying = false;
    private float timer = 0.0f;

    void Start()
    {
        // Start the flying process
        StartFlying();
    }

    void Update()
    {
        // Check if it's time to fly
        if (isFlying)
        {
            timer += Time.deltaTime;

            // Move the Jet forward
            transform.Translate(Vector3.forward * flyingSpeed * Time.deltaTime);

            // Check if the flying duration is reached
            if (timer >= flyDuration)
            {
                // Reset timer and wait for the specified duration before starting again
                isFlying = false;
                timer = 0.0f;

                Invoke("StartFlying", waitDuration);
            }
        }
    }

    void StartFlying()
    {
        // Reset the position of the Jet to the start position
        jet.transform.position = transform.position;

        // Set the Jet active
        jet.SetActive(true);

        // Start flying
        isFlying = true;
    }
}
