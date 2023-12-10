using UnityEngine;

public class JetMovement : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public GameObject jetPrefab; // Assign your Jet prefab in the Unity Editor
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

            // Move the Jet towards the endPoint using Lerp
            float t = timer / flyDuration;
            transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);

            // Check if the Jet has reached the endPoint
            if (t >= 1.0f)
            {
                // Reset timer and destroy the Jet
                isFlying = false;
                timer = 0.0f;
                DestroyJet();

                // Wait for the specified duration before starting again
                Invoke("StartFlying", waitDuration);
            }
        }
    }

    void StartFlying()
    {
        // Instantiate a new Jet at the start position
        GameObject jetInstance = Instantiate(jetPrefab, startPoint.position, Quaternion.identity);
        // Set the instantiated Jet as a child of this GameObject for movement continuity
        jetInstance.transform.parent = transform;

        // Start flying
        isFlying = true;
    }

    void DestroyJet()
    {
        // Detach the Jet from this GameObject before destroying it
        transform.DetachChildren();
        // Destroy the Jet
        Destroy(gameObject);
    }
}
