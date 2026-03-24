using UnityEngine;

public class PlayerBodyCollision : MonoBehaviour
{
    
    public float damage = 2;
    public Health playerHealth;
    public GameObject playerLeg;



    Collider2D parentCollider;
    Collider2D childCollider;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        parentCollider = GetComponent<Collider2D>();
        childCollider = playerLeg.GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(childCollider, parentCollider);

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics2D.GetIgnoreCollision(parentCollider, childCollider) == true)
        {
            Debug.Log("Collisions Ignored");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("hurt"))
        {
            Debug.Log("Player Body Hit");
            
            playerHealth.TakeDamage(damage);
        }

    }     
}
