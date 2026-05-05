using UnityEngine;
using UnityEngine.Rendering;

public class BullletScript : MonoBehaviour
{
    public float bulletSpeed;
    public Rigidbody2D rb;

    public Vector2 directionOfBullet;

   

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        
        rb.linearVelocity = directionOfBullet * bulletSpeed;


    }

   private void OnCollisionEnter2D(Collision2D collision)
   {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("WallGround"))
        {
            Destroy(gameObject);
            Debug.Log("Bullet Destroyed");
        }
   }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("WallGround"))
        {
            Destroy(gameObject);
        }
    }




}
