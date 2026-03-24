using UnityEngine;

public class PlayerArm2Collision : MonoBehaviour
{
    
    public float damage = 2;

    public HealthArm2 playerArm2Health;
    public PlayerBodyCollision playerBodyCollision;

    Collider2D parentCollider;
    Collider2D childCollider;
    private void Start()
    {
        parentCollider = gameObject.transform.parent.GetComponent<Collider2D>();
        childCollider = GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(childCollider, parentCollider);
        
    }

    private void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("hurt"))
        {
            playerBodyCollision.isArm2Colliding = true;
            Debug.Log("Player Leg Hit");
            
            playerArm2Health.TakeDamage(damage);
        }

    }     
}
