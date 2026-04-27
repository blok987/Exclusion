using UnityEngine;

public class BullletScript : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = transform.right * speed;
    }

   private void OnCollisionEnter2D(Collision2D collision)
   {
       if (collision.gameObject.CompareTag("Player"))
       {
            Destroy(gameObject);
        }
   }
       
    


}
