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
        childCollider = GetComponentInChildren<Collider2D>();

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Physics2D.IgnoreCollision(parentCollider, childCollider);
        if (collision.gameObject.CompareTag("hurt"))
        {
            Debug.Log("Player Body Hit");
            
            playerHealth.TakeDamage(damage);
        }

    }     
}
