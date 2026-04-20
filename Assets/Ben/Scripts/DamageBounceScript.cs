using UnityEngine;

public class DamageBounceScript : MonoBehaviour
{
    public WalkScript walkScript;

    private float bounceForce;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walkScript = GetComponent<WalkScript>();
        
        bounceForce = 6f;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            Debug.Log("Player hit a spike! Bouncing back.");
            gameObject.GetComponent<Rigidbody2D>().linearVelocityY += bounceForce;
        }
    }
}

