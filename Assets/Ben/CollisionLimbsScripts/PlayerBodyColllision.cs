using UnityEngine;

public class PlayerBodyCollision : MonoBehaviour
{
    
    public float damage = 2;
    public Health playerHealth;
    public GameObject playerLeg;
    
    public bool isLeg1Colliding;
    public bool isLeg2Colliding;

    public bool isArm1Colliding;
    public bool isArm2Colliding;



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
        
    }
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("hurt") && isLeg1Colliding == false && isLeg2Colliding == false && isArm1Colliding == false && isArm2Colliding == false)
        {
            Debug.Log("Player Body Hit");
            
            playerHealth.TakeDamage(damage);
        }

        else if (isLeg1Colliding == true)
        {
            isLeg1Colliding = false;
        }

        else if (isLeg2Colliding == true)
        {
            isLeg2Colliding = false;
        }

        else if (isArm1Colliding == true)
        {
            isArm1Colliding = false;
        }

        else if (isArm2Colliding == true)
        {
            isArm2Colliding = false;
        }

    }     
}
