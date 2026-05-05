using UnityEngine;

public class DamageBounceScript : MonoBehaviour
{
    public WalkScript walkScript;

    public float bounceForce;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        walkScript = GetComponent<WalkScript>();
    }


    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Spike"))
    //    {
    //        Debug.Log("Player hit a spike! Bouncing.");
    //        walkScript.PlayerDirection.y += bounceForce;
    //        gameObject.GetComponent<Rigidbody2D>().linearVelocity.y += bounceForce;
    //    }
    //}
}

