using UnityEngine;

public class PlayerArm1Collision : MonoBehaviour
{
    
    public float damage = 2;

    public HealthArm1 playerArm1Health;
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
            playerBodyCollision.isArm1Colliding = true;
            Debug.Log("Player Leg Hit");
            
            playerArm1Health.TakeDamage(damage);
        }

    }     
}
