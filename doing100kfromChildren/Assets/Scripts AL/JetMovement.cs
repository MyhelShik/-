using UnityEngine;

public class JetMovement : MonoBehaviour
{
    public GameObject jet; 
    public float flyingSpeed = 5.0f;
    public float flyDuration = 20.0f;
    public float waitDuration = 40.0f;

    private bool isFlying = false;
    private float timer = 0.0f;

    void Start()
    {
        StartFlying();
    }

    void Update()
    {

        if (isFlying)
        {
            timer += Time.deltaTime;


            transform.Translate(Vector3.forward * flyingSpeed * Time.deltaTime);

            if (timer >= flyDuration)
            {
                isFlying = false;
                timer = 0.0f;

                Invoke("StartFlying", waitDuration);
            }
        }
    }

    void StartFlying()
    {
        jet.transform.position = transform.position;

        jet.SetActive(true);
        
        if(jet.SetActive == true)
            jet.SetActive(true);
            

        isFlying = true;
    }
}
