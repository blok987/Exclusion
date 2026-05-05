using UnityEngine;

public class PlayerLeg2Collision : MonoBehaviour
{
    
    public float damage = 2;

    public HealthLeg2 playerLegHealth2;
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
            playerBodyCollision.isLeg2Colliding = true;
            Debug.Log("Player Leg2Hit");
            
            playerLegHealth2.TakeDamage(damage);
        }

    }     
}
